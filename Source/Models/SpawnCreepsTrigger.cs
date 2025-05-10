using Source.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static Source.Models.Enums;

namespace Source.Models
{
  public sealed class SpawnCreepsTrigger
  {
    /// <summary>
    /// Erstellt einen zeitgesteuertem Auslöser für das regelmäßige Erstellen von Einheiten.
    /// </summary>
    /// <param name="player">Computer-Spieler, für den Einheiten erstellt werden</param>
    /// <param name="building">Gebäude, an dessen Lebenszeit dieser Auslöser gebunden ist</param>
    /// <param name="spawnArea">Gebiet, in dem die Einheiten erstellt werden</param>
    /// <param name="unitSpawnType">Klasse der erstellten Einheiten</param>
    /// <param name="interval">Interval in Sekunden, nach dessen Rythmus Einheiten erstellt werden</param>
    /// <param name="targetArea">Zielgebiet, für das erstellte Einheiten einen Angriff/Bewegen-Befehl erhalten</param>
    /// <param name="unitIds">Auflistung an Einheit-Typen zu beginn</param>
    public SpawnCreepsTrigger(CreepCamp creepCamp, SpawnCreepsBuilding building, Area spawnArea, UnitClass unitSpawnType, float interval, Area targetArea, params int[] unitIds)
    {
      CreepCamp = creepCamp;
      Interval = interval;
      //SpawnArea = spawnArea;
      TargetArea = targetArea;
      //Building = building;
      UnitSpawnType = unitSpawnType;
      UnitIds = unitIds.ToList();
    }

    private CreepCamp CreepCamp { get; init; }

    ///// <summary>
    ///// Gebäude, an das der Auslöser gebunden ist.
    ///// Stirbt das Gebäude, werden gebundene Auslöser gestoppt.
    ///// </summary>
    //private SpawnBuilding Building { get; init; }

    private float Interval { get; init; }

    private Area TargetArea { get; init; }

    private List<int> UnitIds { get; init; }

    private timer Timer { get; set; }

    /// <summary>
    /// Typ der erstellenden Einheiten.
    /// </summary>
    public Enums.UnitClass UnitSpawnType { get; init; }

    /// <summary>
    /// Startet den Trigger im angegebenen Interval
    /// </summary>
    public void Run(float delay = 0f)
    {
      // Delay a little since some stuff can break otherwise
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        Start();
      });
    }

    private void Start()
    {
      Timer = timer.Create();
      Timer.Start(Interval, true, Elapsed);
    }

    /// <summary>
    /// Wird vom Trigger im angegeben Interval abgearbeitet.
    /// </summary>
    private void Elapsed()
    {
      try
      {
        foreach (int unitId in UnitIds)
        {
          Program.ShowDebugMessage($"spawn unit {unitId}");
          SpawnedCreep unit = CreepCamp.SpawnUnitInAreaAtRandomPoint(unitId);

          unit.AttackMove(TargetArea);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    /// <summary>
    /// Stoppt den Trigger und zerstört ihn für den GC.
    /// </summary>
    public void Stop()
    {
      Timer.Pause();
      Timer.Dispose();
      Timer = null;
    }
  }
}

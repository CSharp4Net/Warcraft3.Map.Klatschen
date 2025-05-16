using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static Source.Models.Enums;

namespace Source.Models
{
  public sealed class SpawnUnitsTrigger
  {
    /// <summary>
    /// Erstellt einen zeitgesteuertem Auslöser für das regelmäßige Erstellen von Einheiten.
    /// </summary>
    /// <param name="player">Computer-Spieler, für den Einheiten erstellt werden</param>
    /// <param name="spawnArea">Gebiet, in dem die Einheiten erstellt werden</param>
    /// <param name="spawnInterval">Klasse der erstellten Einheiten</param>
    /// <param name="targetArea">Zielgebiet, für das erstellte Einheiten einen Angriff/Bewegen-Befehl erhalten</param>
    /// <param name="unitIds">Auflistung an Einheit-Typen zu beginn</param>
    public SpawnUnitsTrigger(ComputerPlayer player, Area spawnArea, SpawnInterval spawnInterval, Area targetArea, params int[] unitIds)
    {
      Player = player;
      SpawnArea = spawnArea;
      TargetArea = targetArea;
      UnitSpawnType = spawnInterval;
      UnitIds = unitIds.ToList();
      IsNeutralPlayer = false;
      Interval = Program.GetIntervalSeconds(spawnInterval);
    }

    /// <summary>
    /// Computer-Spieler, für den Einheiten erstellt werden.
    /// </summary>
    private ComputerPlayer Player { get; init; }

    ///// <summary>
    ///// Gebäude, an das der Auslöser gebunden ist.
    ///// Stirbt das Gebäude, werden gebundene Auslöser gestoppt.
    ///// </summary>
    //private SpawnBuilding Building { get; init; }

    private float Interval { get; init; }

    private Area SpawnArea { get; init; }
    private Area TargetArea { get; init; }

    private List<int> UnitIds { get; init; }

    private timer Timer { get; set; }

    public bool IsNeutralPlayer { get; init; }

    /// <summary>
    /// Typ der erstellenden Einheiten.
    /// </summary>
    public Enums.SpawnInterval UnitSpawnType { get; init; }

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
          SpawnedUnit unit = Player.CreateUnit(unitId, SpawnArea);

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

    public void Add(SpawnUnitCommand spawnCommand)
    {
      UnitIds.Add(spawnCommand.UnitId);
    }

    public void Upgrade(SpawnUnitCommand spawnCommand)
    {
      for (int i = 0; i < UnitIds.Count; i++)
      {
        if (UnitIds[i] == spawnCommand.UnitIdToUpgrade)
          UnitIds[i] = spawnCommand.UnitId;
      }
    }
  }
}

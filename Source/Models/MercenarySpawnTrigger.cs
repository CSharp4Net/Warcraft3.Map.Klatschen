using Source.Abstracts;
using Source.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using WCSharp.Shared.Data;
using static Source.Models.Enums;

namespace Source.Models
{
  public sealed class MercenarySpawnTrigger
  {
    /// <summary>
    /// Erstellt einen zeitgesteuertem Auslöser für das regelmäßige Erstellen von Einheiten.
    /// </summary>
    /// <param name="force">Computer-Spieler, für den Einheiten erstellt werden</param>
    /// <param name="spawnInterval">Klasse der erstellten Einheiten</param>
    /// <param name="targetArea">Zielgebiet, für das erstellte Einheiten einen Angriff/Bewegen-Befehl erhalten</param>
    /// <param name="unitIds">Auflistung an Einheit-Typen zu beginn</param>
    public MercenarySpawnTrigger(NeutralForce force, SpawnInterval spawnInterval, Area spawnArea, Area targetArea, params int[] unitIds)
    {
      Force = force;
      SpawnArea = spawnArea;
      TargetArea = targetArea;
      UnitIds = unitIds.ToList();
      SpawnInterval = spawnInterval;
      Interval = Program.GetIntervalSeconds(spawnInterval);
    }

    private NeutralForce Force { get; init; }

    private float Interval { get; init; }

    private Area SpawnArea { get; init; }
    private Area TargetArea { get; init; }

    private List<int> UnitIds { get; init; }

    private timer Timer { get; set; }

    /// <summary>
    /// Typ der erstellenden Einheiten.
    /// </summary>
    public Enums.SpawnInterval SpawnInterval { get; init; }

    /// <summary>
    /// Startet den Trigger im angegebenen Interval
    /// </summary>
    internal void Run(float delay = 0f)
    {
      // Delay a little since some stuff can break otherwise
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

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
          Point randomPoint = SpawnArea.Wc3Rectangle.GetRandomPoint();
          SpecialEffects.CreateSpecialEffect("UI\\Feedback\\GoldCredit\\GoldCredit.mdl", randomPoint, 1f, 1f);
          Force.SpawnUnitAtPoint(randomPoint, unitId).AttackMove(TargetArea, 1f);
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
    internal void Stop()
    {
      Timer.Pause();
      Timer.Dispose();
      Timer = null;
    }

    internal void AddUnit(int unitId)
    {
      UnitIds.Add(unitId);
    }
  }
}

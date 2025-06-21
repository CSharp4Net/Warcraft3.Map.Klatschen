using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static Source.Models.Enums;

namespace Source.Models
{
  public sealed class UnitSpawnTrigger
  {
    /// <summary>
    /// Erstellt einen zeitgesteuertem Auslöser für das regelmäßige Erstellen von Einheiten.
    /// </summary>
    /// <param name="player">Computer-Spieler, für den Einheiten erstellt werden</param>
    /// <param name="spawnArea">Gebiet, in dem die Einheiten erstellt werden</param>
    /// <param name="spawnInterval">Klasse der erstellten Einheiten</param>
    /// <param name="targetArea">Zielgebiet, für das erstellte Einheiten einen Angriff/Bewegen-Befehl erhalten</param>
    /// <param name="unitTypeIds">Auflistung an Einheit-Typen zu beginn</param>
    public UnitSpawnTrigger(ComputerPlayer player, SpawnInterval spawnInterval, SpawnAttackRoute route, params int[] unitTypeIds)
    {
      Player = player;
      Route = route;
      SpawnInterval = spawnInterval;
      UnitTypeIds = unitTypeIds.ToList();
      Interval = Program.GetIntervalSeconds(spawnInterval);
    }

    /// <summary>
    /// Computer-Spieler, für den Einheiten erstellt werden.
    /// </summary>
    private ComputerPlayer Player { get; init; }

    /// <summary>
    /// Intervall in Sekunden
    /// </summary>
    private float Interval { get; init; }

    /// <summary>
    /// Gebiet, in dem Einheiten ryhtmisch erstellt werden.
    /// </summary>
    internal SpawnAttackRoute Route { get; init; }

    /// <summary>
    /// Auflistung von Einheittyp-Ids, welche beim Auslösen erstelltt werden.
    /// </summary>
    private List<int> UnitTypeIds { get; init; }

    /// <summary>
    /// Timer, welcher die Erstellung rythmisch auslöst.
    /// </summary>
    private timer Timer { get; set; }

    /// <summary>
    /// Typ der erstellenden Einheiten.
    /// </summary>
    public Enums.SpawnInterval SpawnInterval { get; init; }

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
        timer.Dispose();
        timer = null;

        Start();
      });
    }

    /// <summary>
    /// Startet den Timer zum ryhtmischen Erstellen von Einheiten.
    /// </summary>
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
        foreach (int unitId in UnitTypeIds)
        {
          SpawnedUnit unit = Player.CreateUnit(unitId, Route.SpawnArea);

          unit.AttackMove(Route.TargetArea);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    /// <summary>
    /// Stoppt den Timer und zerstört ihn für den GC.
    /// </summary>
    public void Stop()
    {
      Timer.Pause();
      Timer.Dispose();
      Timer = null;
    }

    /// <summary>
    /// Fügt der Auflistung von Einheitentyp-Ids einen Eintrag hinzu.
    /// </summary>
    /// <param name="spawnCommand"></param>
    public void Add(UnitUpgradeByResearchCommand spawnCommand)
    {
      UnitTypeIds.Add(spawnCommand.UnitId);
    }
    /// <summary>
    /// Fügt der Auflistung von Einheitentyp-Ids einen Eintrag hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    public void Add(int unitTypeId)
    {
      UnitTypeIds.Add(unitTypeId);
    }

    /// <summary>
    /// Aktualisiert einen oder mehrere Einträge in der Auflistung von Einheitentyp-Ids.
    /// </summary>
    /// <param name="spawnCommand"></param>
    public void Upgrade(UnitUpgradeByResearchCommand spawnCommand)
    {
      for (int i = 0; i < UnitTypeIds.Count; i++)
      {
        if (UnitTypeIds[i] == spawnCommand.UnitIdToUpgrade)
          UnitTypeIds[i] = spawnCommand.UnitId;
      }
    }
    /// <summary>
    /// Aktualisiert einen oder mehrere Einträge in der Auflistung von Einheitentyp-Ids.
    /// </summary>
    /// <param name="spawnCommand"></param>
    public void Upgrade(int oldUnitTypeId, int newUnitTypeId)
    {
      for (int i = 0; i < UnitTypeIds.Count; i++)
      {
        if (UnitTypeIds[i] == oldUnitTypeId)
          UnitTypeIds[i] = newUnitTypeId;
      }
    }
  }
}

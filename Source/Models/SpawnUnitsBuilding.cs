using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnUnitsBuilding
  {
    public SpawnUnitsBuilding(ComputerPlayer computer, int unitTypeId, Area creationArea, float face = 0f)
    {
      Wc3Unit = Common.CreateUnitAtLoc(computer.Wc3Player, unitTypeId, creationArea.Wc3CenterLocation, face);
      Computer = computer;
      SpawnTriggers = new List<SpawnUnitsTrigger>();
    }

    /// <summary>
    /// WC3-Einheit zu diesem Gebäude.
    /// </summary>
    public unit Wc3Unit { get; init; }
    /// <summary>
    /// WC3-Trigger für das Sterbe-Event.
    /// </summary>
    private trigger Wc3Trigger { get; set; }

    /// <summary>
    /// Der Computer-Spieler, dem dieses Gebäude gehört.
    /// </summary>
    private ComputerPlayer Computer { get; init; }

    /// <summary>
    /// Auflistung von Spawn-Triggers.
    /// </summary>
    private List<SpawnUnitsTrigger> SpawnTriggers { get; init; }

    /// <summary>
    /// Fügt dem Gebäude einen Spawn-Trigger hinzu, welcher solange existiert ist, bis das Gebäude via <see cref="Destroy"/> zerstört wird.
    /// </summary>
    /// <param name="interval">Sekunden</param>
    /// <param name="spawnArea">Spawn-Gebiet</param>
    /// <param name="unitIds">Auflistung an Einheiten-Ids</param>
    /// <returns></returns>
    public SpawnUnitsTrigger AddSpawnTrigger(Area spawnArea, Enums.SpawnInterval spawnInterval, Area targetArea, params int[] unitIds)
    {
      SpawnUnitsTrigger trigger = new SpawnUnitsTrigger(Computer, spawnArea, spawnInterval, targetArea, unitIds);
      SpawnTriggers.Add(trigger);
      return trigger;
    }

    /// <summary>
    /// Deregistriert das Sterbe-Event, stoppt alle Spawn-Trigger und tötet (falls noch nötig) die WC3-Einheit.
    /// </summary>
    public void Destroy()
    {
      DeRegisterOnDies();

      for (int i = SpawnTriggers.Count - 1; i >= 0; i--)
      {
        SpawnUnitsTrigger trigger = SpawnTriggers[i];

        trigger.Stop();

        SpawnTriggers.RemoveAt(i);
      }

      if (Wc3Unit.Alive)
      {
        // Da diese Funktion auch beim Tod des Gebäudes ausgelöst werden kann,
        // töte Gebäude bei Bedarf, d.h. wenn Team verliert und Spieler entfernt werden.
        Wc3Unit.Kill();
      }
    }

    /// <summary>
    /// Registriert das Sterbe-Event.
    /// </summary>
    /// <param name="eventHandler"></param>
    public void RegisterOnDies(Action eventHandler)
    {
      Wc3Trigger = trigger.Create();
      Wc3Trigger.RegisterUnitEvent(Wc3Unit, unitevent.Death);
      Wc3Trigger.AddAction(eventHandler);
    }

    /// <summary>
    /// Deregistriert das Sterbe-Event.
    /// </summary>
    private void DeRegisterOnDies()
    {
      if (Wc3Trigger == null)
        return;

      Wc3Trigger.Disable();
      Wc3Trigger.Dispose();
      Wc3Trigger = null;
    }

    /// <summary>
    /// Fügt passenden Spawn-Triggern von diesem Gebäude eine neue Einheit hinzu.
    /// </summary>
    /// <param name="spawnCommand"></param>
    public void AddUnitSpawn(SpawnUnitCommand spawnCommand)
    {
      foreach (SpawnUnitsTrigger trigger in SpawnTriggers)
      {
        if (trigger.UnitSpawnType == spawnCommand.UnitSpawnType)
          trigger.Add(spawnCommand);
      }
    }

    /// <summary>
    /// Überschreibt eine bestehende Einheit in passenden Spawn-Triggern.
    /// </summary>
    /// <param name="spawnCommand"></param>
    public void UpgradeUnitSpawn(SpawnUnitCommand spawnCommand)
    {
      foreach (SpawnUnitsTrigger trigger in SpawnTriggers)
      {
        if (trigger.UnitSpawnType == spawnCommand.UnitSpawnType)
          trigger.Upgrade(spawnCommand);
      }
    }
  }
}

using Source.Extensions;
using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnedBuilding
  {
    public SpawnedBuilding(ComputerPlayer computer, int unitTypeId, Area creationArea, float face = 0f)
    {
      Wc3Unit = Common.CreateUnitAtLoc(computer.Wc3Player, unitTypeId, creationArea.Wc3CenterLocation, face);
      Computer = computer;
      SpawnTriggers = new List<SpawnTrigger>();
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
    private List<SpawnTrigger> SpawnTriggers { get; init; }

    /// <summary>
    /// Fügt dem Gebäude einen Spawn-Trigger hinzu, welcher solange existiert ist, bis das Gebäude via <see cref="Destroy"/> zerstört wird.
    /// </summary>
    /// <param name="interval">Sekunden</param>
    /// <param name="spawnArea">Spawn-Gebiet</param>
    /// <param name="unitIds">Auflistung an Einheiten-Ids</param>
    /// <returns></returns>
    public SpawnTrigger AddSpawnTrigger(float interval, Area spawnArea, params int[] unitIds)
    {
      SpawnTrigger trigger = new SpawnTrigger(Computer, interval, spawnArea, this, unitIds);
      SpawnTriggers.Add(trigger);
      return trigger;
    }

    /// <summary>
    /// Deregistriert das Sterbe-Event, stoppt alle Spawn-Trigger und tötet (falls noch nötig) die WC3-Einheit.
    /// </summary>
    public void Destroy()
    {
      DeRegisterOnDies();

      foreach (SpawnTrigger trigger in SpawnTriggers)
      {
        trigger.Stop();
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
    /// Fügt allen Spawn-Triggern von diesem Gebäude die Einheit hinzu.
    /// </summary>
    /// <param name="unitId"></param>
    public void AddUnitSpawn(int unitId)
    {
      foreach (SpawnTrigger trigger in SpawnTriggers)
      {
        trigger.Add(unitId);
      }
    }
  }
}

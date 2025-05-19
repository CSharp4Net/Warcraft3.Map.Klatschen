using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnCreepsBuilding
  {
    public SpawnCreepsBuilding(CreepCamp creepCamp, int unitTypeId, Area creationArea, float face = 0f)
    {
      Wc3Unit = Common.CreateUnitAtLoc(creepCamp.Wc3Player, unitTypeId, creationArea.Wc3CenterLocation, face);
      CreepCamp = creepCamp;
    }

    /// <summary>
    /// WC3-Einheit zu diesem Gebäude.
    /// </summary>
    public unit Wc3Unit { get; private set; }
    /// <summary>
    /// WC3-Trigger für das Sterbe-Event.
    /// </summary>
    private trigger Wc3Trigger { get; set; }

    /// <summary>
    /// Das CreepCamp, dem dieses Gebäude gehört.
    /// </summary>
    private CreepCamp CreepCamp { get; init; }

    private SpawnCreepsTrigger SpawnTrigger { get; set; }

    /// <summary>
    /// Fügt dem Gebäude einen Spawn-Trigger hinzu, welcher solange existiert ist, bis das Gebäude via <see cref="Destroy"/> zerstört wird.
    /// </summary>
    /// <param name="interval">Sekunden</param>
    /// <param name="spawnArea">Spawn-Gebiet</param>
    /// <param name="unitIds">Auflistung an Einheiten-Ids</param>
    /// <returns></returns>
    public SpawnCreepsTrigger InitializeSpawnTrigger(Enums.SpawnInterval spawnInterval, Area targetArea)
    {
      return SpawnTrigger = new SpawnCreepsTrigger(CreepCamp, spawnInterval, targetArea);
    }

    public void AddUnitToSpawnTrigger(int unitId)
    {
      SpawnTrigger.AddUnit(unitId);
    }

    /// <summary>
    /// Deregistriert das Sterbe-Event, stoppt alle Spawn-Trigger und tötet (falls noch nötig) die WC3-Einheit.
    /// </summary>
    public void Destroy()
    {
      DeRegisterOnDies();

      if (SpawnTrigger != null)
        SpawnTrigger.Stop();

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
  }
}

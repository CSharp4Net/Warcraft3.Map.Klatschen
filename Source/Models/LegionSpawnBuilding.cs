using Source.Abstracts;
using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class LegionSpawnBuilding
  {
    public LegionSpawnBuilding(int unitTypeId, Area creationArea, float face = 0f)
    {
      CreationArea = creationArea;
      Wc3Unit = Common.CreateUnitAtLoc(Program.Legion.Wc3Player, unitTypeId, creationArea.Wc3CenterLocation, face);
    }

    /// <summary>
    /// WC3-Einheit zu diesem Gebäude.
    /// </summary>
    public unit Wc3Unit { get; private set; }
    /// <summary>
    /// WC3-Trigger für das Sterbe-Event.
    /// </summary>
    private trigger Wc3Trigger { get; set; }

    public Area CreationArea { get; init; }

    private List<LegionSpawnTrigger> SpawnTriggers { get; set; } = new List<LegionSpawnTrigger>();

    /// <summary>
    /// Fügt dem Gebäude einen Spawn-Trigger hinzu, welcher solange existiert ist, bis das Gebäude via <see cref="Destroy"/> zerstört wird.
    /// </summary>
    /// <param name="interval">Sekunden</param>
    /// <param name="spawnArea">Spawn-Gebiet</param>
    /// <param name="unitIds">Auflistung an Einheiten-Ids</param>
    /// <returns></returns>
    public LegionSpawnTrigger AddSpawnTrigger(Enums.SpawnInterval spawnInterval, Area spawnArea, Area targetArea)
    {
      LegionSpawnTrigger spawnTrigger = new LegionSpawnTrigger(spawnInterval, spawnArea, targetArea);
      SpawnTriggers.Add(spawnTrigger);
      return spawnTrigger;
    }

    public void AddUnitToSpawnTriggers(int unitId)
    {
      for (int i = SpawnTriggers.Count - 1; i >= 0; i--)
      {
        SpawnTriggers[i].AddUnit(unitId);
      }
    }

    /// <summary>
    /// Deregistriert das Sterbe-Event, stoppt alle Spawn-Trigger und tötet (falls noch nötig) die WC3-Einheit.
    /// </summary>
    public void Destroy()
    {
      DeRegisterOnDies();

      for (int i = SpawnTriggers.Count - 1; i >= 0; i--)
      {
        SpawnTriggers[i].Stop();
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
  }
}

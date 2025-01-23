using Source.Extensions;
using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class Building
  {
    public Building(ComputerPlayer player, int unitTypeId, Area area, float face = 0f)
    {
      Unit = Common.CreateUnitAtLoc(player.Player, unitTypeId, area.CenterLocation, face);
      Player = player;
      SpawnTriggers = new List<SpawnTrigger>();
    }

    public unit Unit { get; init; }
    public ComputerPlayer Player { get; init; }
    public List<SpawnTrigger> SpawnTriggers { get; init; }

    public void RegisterOnDies(Action onDiesEventHandler)
    {
      Unit.RegisterOnDies(onDiesEventHandler);
    }

    public SpawnTrigger AddSpawnTrigger(float interval, Area spawnArea, params int[] unitIds)
    {
      SpawnTrigger trigger = new SpawnTrigger(Player, interval, spawnArea, this, unitIds);
      SpawnTriggers.Add(trigger);
      trigger.Run();
      return trigger;
    }

    internal void Destroy()
    {
      foreach (SpawnTrigger trigger in SpawnTriggers)
      {
        trigger.Stop();
      }

      if (Unit.Alive)
        // Da diese Funktion auch beim Tod des Gebäudes ausgelöst werden kann,
        // töte Gebäude bei Bedarf, d.h. wenn Team verliert und Spieler entfernt werden.
        Unit.Kill();
    }
  }
}

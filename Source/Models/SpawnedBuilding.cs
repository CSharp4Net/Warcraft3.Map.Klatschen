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

    public unit Wc3Unit { get; init; }
    public trigger Wc3Trigger { get; private set; }

    public ComputerPlayer Computer { get; init; }
    public List<SpawnTrigger> SpawnTriggers { get; init; }

    public SpawnTrigger AddSpawnTrigger(float interval, Area spawnArea, params int[] unitIds)
    {
      SpawnTrigger trigger = new SpawnTrigger(Computer, interval, spawnArea, this, unitIds);
      SpawnTriggers.Add(trigger);
      trigger.Run();
      return trigger;
    }

    internal void Destroy()
    {
      Console.WriteLine($"Deregister Death-Event of {Wc3Unit.Name}");
      DeRegisterOnDies();

      Console.WriteLine($"Stop spawn triggers of {Wc3Unit.Name}");
      foreach (SpawnTrigger trigger in SpawnTriggers)
      {
        trigger.Stop();
      }

      if (Wc3Unit.Alive)
      {
        Console.WriteLine($"Kill unit {Wc3Unit.Name}");
        // Da diese Funktion auch beim Tod des Gebäudes ausgelöst werden kann,
        // töte Gebäude bei Bedarf, d.h. wenn Team verliert und Spieler entfernt werden.
        Wc3Unit.Kill();
      }

      Console.WriteLine($"Destroy completed {Wc3Unit.Name}");
    }

    public void RegisterOnDies(Action eventHandler)
    {
      Wc3Trigger = trigger.Create();
      Wc3Trigger.RegisterUnitEvent(Wc3Unit, unitevent.Death);
      Wc3Trigger.AddAction(eventHandler);
    }

    public void DeRegisterOnDies()
    {
      if (Wc3Trigger == null)
        return;

      Wc3Trigger.Disable();
      Wc3Trigger.Dispose();
      Wc3Trigger = null;
    }
  }
}

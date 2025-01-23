using Source.Abstracts;
using Source.Extensions;
using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class ComputerPlayer : PlayerBase
  {
    public ComputerPlayer(player player, Team team)
      : base(player)
    {
      Team = team;
    }

    public Team Team { get; init; }

    public List<Building> Buildings { get; init; } = new List<Building>();

    //private List<SpawnTrigger> SpawnTriggers { get; init; } = new List<SpawnTrigger>();

    public Building CreateBuilding(int unitTypeId, Area area, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      Building building = new Building(this, unitTypeId, area, face);
      Buildings.Add(building);
      return building;
    }

    //public void AddSpawnTrigger(float interval, Area spawnArea, unit spawningBuilding, params int[] unitIds)
    //{
    //  SpawnTrigger trigger = new SpawnTrigger(this, interval, spawnArea, unitIds);
    //  SpawnTriggers.Add(trigger);
    //  trigger.Run();
    //}

    public override void Defeat()
    {
      //foreach (SpawnTrigger trigger in SpawnTriggers)
      //{
      //  trigger.Stop();
      //}

      Console.WriteLine($"Destroy buildings");
      foreach (Building building in Buildings)
      {
        building.Destroy();
      }

      base.Defeat();
    }
  }
}

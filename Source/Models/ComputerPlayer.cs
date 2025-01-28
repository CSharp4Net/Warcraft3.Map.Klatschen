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

    private List<SpawnedBuilding> Buildings { get; init; } = new List<SpawnedBuilding>();

    public SpawnedBuilding CreateBuilding(int unitTypeId, Area creationArea, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      SpawnedBuilding building = new SpawnedBuilding(this, unitTypeId, creationArea, face);
      Buildings.Add(building);
      return building;
    }

    public bool IsOwnerOfBuilding(unit wc3Unit, out SpawnedBuilding foundBuilding)
    {
      foreach (SpawnedBuilding building in Buildings)
      {
        if (building.Wc3Unit == wc3Unit)
        {
          foundBuilding = building;
          return true;
        }
      }

      foundBuilding = null;
      return false;
    }

    public void RemoveBuilding(SpawnedBuilding building)
    {
      Program.ShowDebugMessage("ComputerPlayer.RemoveBuilding", $"Remove building {building.Wc3Unit.Name}");
      Buildings.Remove(building);
    }

    public override void Defeat()
    {
      // Alle gespawnten Gebäude zerstören
      foreach (SpawnedBuilding building in Buildings)
      {
        Program.ShowDebugMessage("ComputerPlayer.Defeat", $"Destroy building {building.Wc3Unit.Name}");
        building.Destroy();
      }

      base.Defeat();
    }
  }
}

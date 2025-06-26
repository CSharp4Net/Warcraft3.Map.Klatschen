using Source.Abstracts;
using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class ComputerPlayer : PlayerBase
  {
    public ComputerPlayer(player player, TeamBase team)
      : base(player)
    {
      Team = team;
    }

    public TeamBase Team { get; init; }

    public MainBuilding MainBuilding { get; private set; }

    private List<UnitSpawnBuilding> BarrackBuildings { get; init; } = new List<UnitSpawnBuilding>();

    public MainBuilding CreateMainBuilding(int unitTypeId, Area creationArea, string specialEffectPath)
    {
      return MainBuilding = new MainBuilding(this, unitTypeId, creationArea, specialEffectPath);
    }

    public UnitSpawnBuilding CreateBarrackBuilding(int unitTypeId, Area creationArea, Area spawnArea, Area targetArea)
    {
      // Ort anhand Zentrum einer Region erstellen
      UnitSpawnBuilding building = new UnitSpawnBuilding(this, unitTypeId, creationArea, spawnArea, targetArea);

      BarrackBuildings.Add(building);

      return building;
    }

    public bool IsOwnerOfBuilding(unit wc3Unit, out UnitSpawnBuilding foundBuilding)
    {
      foreach (UnitSpawnBuilding building in BarrackBuildings)
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

    public void RemoveBuilding(UnitSpawnBuilding building)
    {
      //Program.ShowDebugMessage("ComputerPlayer.RemoveBuilding", $"Remove building {building.Wc3Unit.Name}");
      BarrackBuildings.Remove(building);
    }

    public override void Defeat()
    {
      // Alle gespawnten Gebäude zerstören
      for (int i = BarrackBuildings.Count - 1; i >= 0; i--)
      {
        UnitSpawnBuilding building = BarrackBuildings[i];

        building.Destroy();

        RemoveBuilding(building);
      }

      base.Defeat();
    }

    public void AddSpawnUnit(UnitUpgradeByResearchCommand spawnCommand)
    {
      foreach (UnitSpawnBuilding building in BarrackBuildings)
      {
        if (building.Wc3Unit.UnitType == spawnCommand.UnitIdOfBuilding)
          building.AddUnitSpawn(spawnCommand);
      }
    }

    public void UpgradeSpawnUnit(UnitUpgradeByResearchCommand spawnCommand)
    {
      foreach (UnitSpawnBuilding building in BarrackBuildings)
      {
        if (building.Wc3Unit.UnitType == spawnCommand.UnitIdOfBuilding)
          building.UpgradeUnitSpawn(spawnCommand);
      }
    }
  }
}

using Source.Abstracts;
using System.Collections.Generic;

namespace Source.Models
{
  public sealed class UnitSpawnBuilding : BuildingBase
  {
    public UnitSpawnBuilding(ComputerPlayer computer, int unitTypeId, Area creationArea, Area spawnArea, Area targetArea)
      : base(computer, unitTypeId, creationArea)
    {
      SpawnTriggers = new List<UnitSpawnTrigger>();
      Route = new SpawnAttackRoute(spawnArea, targetArea);
    }

    private SpawnAttackRoute Route { get; init; }

    private List<UnitSpawnTrigger> SpawnTriggers { get; init; }

    public UnitSpawnTrigger AddSpawnTrigger(Enums.SpawnInterval spawnInterval, params int[] unitIds)
    {
      UnitSpawnTrigger trigger = new UnitSpawnTrigger(Computer, spawnInterval, Route, unitIds);
      SpawnTriggers.Add(trigger);
      return trigger;
    }

    public void AddUnitSpawn(UnitUpgradeByResearchCommand spawnCommand)
    {
      foreach (UnitSpawnTrigger trigger in SpawnTriggers)
      {
        if (trigger.SpawnInterval == spawnCommand.UnitSpawnType)
          trigger.Add(spawnCommand);
      }
    }

    public void UpgradeUnitSpawn(UnitUpgradeByResearchCommand spawnCommand)
    {
      foreach (UnitSpawnTrigger trigger in SpawnTriggers)
      {
        if (trigger.SpawnInterval == spawnCommand.UnitSpawnType)
          trigger.Upgrade(spawnCommand);
      }
    }

    public void UpgradeSpawningUnits(UnitUpgradeBySoldCommand command)
    {
      foreach (UnitSpawnTrigger trigger in SpawnTriggers)
      {
        if (trigger.SpawnInterval == command.SpawnInterval)
        {
          if (command.IsAddCommand)
            trigger.Add(command.NewUnitTypeId);
          else
            trigger.Upgrade(command.OldUnitTypeId, command.NewUnitTypeId);
        }
      }
    }

    public override void Destroy()
    {
      for (int i = SpawnTriggers.Count - 1; i >= 0; i--)
      {
        UnitSpawnTrigger trigger = SpawnTriggers[i];

        trigger.Stop();

        SpawnTriggers.RemoveAt(i);
      }

      base.Destroy();
    }
  }
}

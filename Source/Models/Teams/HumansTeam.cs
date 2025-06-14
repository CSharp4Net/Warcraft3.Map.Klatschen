﻿using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class HumansTeam : TeamBase
  {
    public HumansTeam(player wc3ComputerPlayer)
      : base(Common.Player(0), Areas.HumanBase)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Red}{wc3ComputerPlayer.Name}|r";
    }

    public override Enums.ResearchType GetTechType(int techId, int techLevel, out SpawnUnitCommand spawnCommand)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_CAPTIAN_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SOLDIER_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_KNIGHT_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_CAPTIAN_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_RIFLEMAN_BESERK_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_RIFLEMAN_ELITE_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_BESERK_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_CASTLE_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_FALCON_RIDER_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FLYING_MACHINE_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_GRIFFIN_RIDER_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FALCON_RIDER_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_CASTLE_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SORCERESS_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_PRIEST_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SPELLBREAKER_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SORCERESS_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_CASTLE_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SIEGE_SQUAD_HUMAN;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SIEGE_ENGINE_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SIEGE_SQUAD_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        default: // Einfache Verbeserungen bestehender Einheiten
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }

    public override Enums.ItemType GetItemTypeOfItem(int itemTypeId, out AddOrUpgradeSpawnUnitCommand spawnCommand)
    {
      switch (itemTypeId)
      {
        case Constants.ITEM_MELEE_UNIT_LEVEL_2:
          spawnCommand = new AddOrUpgradeSpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            NewUnitTypeId = Constants.UNIT_CAPTIAN_HUMAN,
            OldUnitTypeId = Constants.UNIT_SOLDIER_HUMAN,
          };
          return Enums.ItemType.UpgradeTeamUnits;
        case Constants.ITEM_MELEE_UNIT_LEVEL_3:
          spawnCommand = new AddOrUpgradeSpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            NewUnitTypeId = Constants.UNIT_KNIGHT_HUMAN,
            OldUnitTypeId = Constants.UNIT_CAPTIAN_HUMAN,
          };
          return Enums.ItemType.UpgradeTeamUnits;
      }

      spawnCommand = null;
      return Enums.ItemType.Unknown;
    }
  }
}

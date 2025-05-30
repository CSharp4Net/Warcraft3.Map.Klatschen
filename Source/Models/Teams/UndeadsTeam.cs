using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class UndeadsTeam : TeamBase
  {
    public UndeadsTeam(player wc3ComputerPlayer, Area teamBaseArea)
      : base(wc3ComputerPlayer, teamBaseArea)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Maroon}{wc3ComputerPlayer.Name}|r";
    }

    public override Enums.ResearchType GetTechType(int techId, int techLevel, out SpawnUnitCommand spawnCommand)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            UnitIdOfBuilding = Constants.UNIT_CRYPT_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SKELETON_WARRIOR_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_GHOUL_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_ABOMINATION_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SKELETON_WARRIOR_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_CRYPT_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_DESTROYER_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_GARGOYLE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_FROST_WYRM_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_DESTROYER_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_NECROMANCER_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SKELETAL_MAGE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_BANSHEE_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_NECROMANCER_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_MEAT_WAGON_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}
using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class HumansTeam : TeamBase
  {
    public HumansTeam(player wc3ComputerPlayer, Area teamBaseArea)
      : base(wc3ComputerPlayer, teamBaseArea)
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
              spawnCommand.UnitId = Constants.UNIT_SOLDIER_IMPROVED_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_PRIEST_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SOLDIER_ELITE_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SOLDIER_IMPROVED_HUMAN;
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
              spawnCommand.UnitId = Constants.UNIT_RIFLEMAN_IMPROVED_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_RIFLEMAN_ELITE_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_IMPROVED_HUMAN;
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
  }
}

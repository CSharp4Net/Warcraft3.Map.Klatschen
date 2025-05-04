using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class ElfTeam : TeamBase
  {
    public ElfTeam(player wc3ComputerPlayer)
      : base(wc3ComputerPlayer)
    {

    }

    public override Enums.ResearchType GetTechType(int techId, int techLevel, out SpawnUnitCommand spawnCommand)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Meelee,
            UnitIdOfBuilding = Constants.UNIT_KASERNE_ELF,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_NAHKAMPFEINHEIT_STUFE_2_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_NAHKAMPFEINHEIT_STUFE_3_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_NAHKAMPFEINHEIT_STUFE_2_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_KASERNE_ELF,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_FERNKAMPFEINHEIT_STUFE_2_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_FERNKAMPFEINHEIT_STUFE_3_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FERNKAMPFEINHEIT_STUFE_2_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_TELDRASSIL_ELF,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_FLUGEINHEIT_STUFE_2_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FLUGEINHEIT_STUFE_1_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_FLUGEINHEIT_STUFE_3_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FLUGEINHEIT_STUFE_2_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_TELDRASSIL_ELF
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_MAGIEEINHEIT_STUFE_2_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_MAGIEEINHEIT_STUFE_1_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_MAGIEEINHEIT_STUFE_3_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_MAGIEEINHEIT_STUFE_2_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Artillery,
            UnitIdOfBuilding = Constants.UNIT_TELDRASSIL_ELF
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_BELAGERUNGSEINHEIT_STUFE_1_ELF;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_BELAGERUNGSEINHEIT_STUFE_2_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_BELAGERUNGSEINHEIT_STUFE_1_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}
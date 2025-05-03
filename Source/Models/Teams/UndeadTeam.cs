using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class UndeadTeam : TeamBase
  {
    public UndeadTeam(player wc3ComputerPlayer)
      : base(wc3ComputerPlayer)
    {

    }

    public override Enums.ResearchType GetTechType(int techId, int techLevel, out SpawnUnitCommand spawnCommand)
    {
      switch (techId)
      {
        case Constants.UPGRADE_EINHEIT_SOLDAT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Meelee,
            UnitIdOfBuilding = Constants.UNIT_GRUFT_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SOLDAT_STUFE_2_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SOLDAT_STUFE_1_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SOLDAT_STUFE_3_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SOLDAT_STUFE_2_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_SCH_TZE_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_GRUFT_UNDEAD,
            UnitId = Constants.UNIT_SCH_TZE_STUFE_2_UNDEAD,
            UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_1_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SCH_TZE_STUFE_2_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_1_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SCH_TZE_STUFE_3_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_2_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_REITER_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHWARZE_ZITADELLE_UNDEAD,
            UnitId = Constants.UNIT_REITER_STUFE_1_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_REITER_STUFE_2_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_REITER_STUFE_1_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_REITER_STUFE_3_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_REITER_STUFE_2_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_MAGIER_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHWARZE_ZITADELLE_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_MAGIER_STUFE_2_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_MAGIER_STUFE_1_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_MAGIER_STUFE_3_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_MAGIER_STUFE_2_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_BELAGERUNGSMASCHINE_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Artillery,
            UnitIdOfBuilding = Constants.UNIT_SCHWARZE_ZITADELLE_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_BELAGERUNGSMASCHINE_STUFE_1_UNDEAD;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_BELAGERUNGSMASCHINE_STUFE_1_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_BELAGERUNGSMASCHINE_STUFE_2_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        // TODO : Add more technolgies 

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}
using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class OrcTeam : TeamBase
  {
    public OrcTeam(player wc3ComputerPlayer)
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
            UnitIdOfBuilding = Constants.UNIT_KASERNE_ORC,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_GRUNZER_STUFE_2_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_GRUNZER_STUFE_1_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_GRUNZER_STUFE_3_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_GRUNZER_STUFE_2_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_SCH_TZE_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_KASERNE_ORC,
            UnitId = Constants.UNIT_SCH_TZE_STUFE_2_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_1_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SCH_TZE_STUFE_2_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_1_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SCH_TZE_STUFE_3_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_2_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_REITER_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_FESTUNG_ORC,
            UnitId = Constants.UNIT_REITER_STUFE_1_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_REITER_STUFE_2_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_REITER_STUFE_1_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_REITER_STUFE_3_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_REITER_STUFE_2_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_MAGIER_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_FESTUNG_ORC
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_MAGIER_STUFE_2_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_MAGIER_STUFE_1_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_MAGIER_STUFE_3_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_MAGIER_STUFE_2_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_EINHEIT_BELAGERUNGSMASCHINE_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Artillery,
            UnitIdOfBuilding = Constants.UNIT_FESTUNG_ORC
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_BELAGERUNGSMASCHINE_STUFE_1_ORC;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_BELAGERUNGSMASCHINE_STUFE_1_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_BELAGERUNGSMASCHINE_STUFE_2_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}

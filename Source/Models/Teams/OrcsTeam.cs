using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class OrcsTeam : TeamBase
  {
    public OrcsTeam(player wc3ComputerPlayer)
      : base(wc3ComputerPlayer, Areas.OrcBase)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Yellow}{wc3ComputerPlayer.Name}|r";
    }

    public override Enums.ResearchType GetTechType(int techId, int techLevel, out SpawnUnitCommand spawnCommand)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_ORC,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_BESERK_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_GRUNT_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_TAUREN_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_BESERK_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_ORC,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_HEADHUNTER_BESERK_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_HEADHUNTER_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_HEADHUNTER_ELITE_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_HEADHUNTER_BESERK_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_FORTRESS_ORC,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_WIND_RIDER_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_BATRIDER_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SPIRIT_WIND_RIDER_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_WIND_RIDER_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_FORTRESS_ORC
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SHAMAN_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_WITCH_DOCTOR_ORC;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_WARLOCK_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SHAMAN_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_FORTRESS_ORC
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_KODO_BEAST_ORC;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_DEMOLISHER_ORC;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_KODO_BEAST_ORC;
              return Enums.ResearchType.UpgradeUnit;
          }

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}

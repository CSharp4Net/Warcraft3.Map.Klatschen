using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class ElvesTeam : TeamBase
  {
    public ElvesTeam()
      : base(Common.Player(8), Areas.ElfBase)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Gray}{Common.Player(8).Name}|r";
    }

    public override void CreateBuildings()
    {
      // Hauptgebäude
      MainBuilding mainBuilding = Computer.CreateMainBuilding(Constants.UNIT_TREE_OF_ETERNITY_ELF, Areas.ElfBase);

      mainBuilding.RegisterOnDies(TeamMainBuilding.OnDies);
      mainBuilding.AddSpawnAttackRoute(Areas.ElfBaseToCenterSpawn, Areas.OrcBase);
      mainBuilding.AddSpawnAttackRoute(Areas.ElfBaseToHumanSpawn, Areas.HumanBase);
      mainBuilding.AddSpawnAttackRoute(Areas.ElfBaseToUndeadSpawn, Areas.UndeadBase);

      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_GUARDIAN_GOLEM_ELF, 1, 1);

      // Kasernen
      UnitSpawnBuilding building = Computer.CreateBarrackBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF,
        Areas.ElfBarracksToCenter, Areas.ElfBarracksToCenterSpawn, Areas.OrcBase);

      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_SENTRY_ELF, Constants.UNIT_SENTRY_ELF).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_SENTRY_ELF).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long, Constants.UNIT_DRUID_OF_THE_TALON_ELF).Run(2f);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF,
        Areas.ElfBarracksToHuman, Areas.ElfBarracksToHumanSpawn, Areas.HumanBase);

      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_SENTRY_ELF, Constants.UNIT_SENTRY_ELF).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_ARCHER_ELF).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long, Constants.UNIT_DRUID_OF_THE_TALON_ELF).Run(2f);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF,
        Areas.ElfBarracksToUndead, Areas.ElfBarracksToUndeadSpawn, Areas.UndeadBase);

      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_SENTRY_ELF, Constants.UNIT_SENTRY_ELF).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_ARCHER_ELF).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long, Constants.UNIT_DRUID_OF_THE_TALON_ELF).Run(2f);
    }

    public override Enums.ResearchType GetTechType(int techId, int techLevel, out SpawnUnitCommand spawnCommand)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            UnitIdOfBuilding = Constants.UNIT_ANCIENT_OF_WAR_ELF,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_DRUID_OF_THE_CLAW_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SENTRY_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_MOUNTAIN_GIANT_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_DRUID_OF_THE_CLAW_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_ANCIENT_OF_WAR_ELF,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_ARCHER_BESERK_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_ARCHER_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_ARCHER_ELITE_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_ARCHER_BESERK_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_TREE_OF_ETERNITY_ELF,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_HIPPOGRYPH_RIDER_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FAERIE_DRAGON_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_CHIMAERA_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_HIPPOGRYPH_RIDER_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_TREE_OF_ETERNITY_ELF
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_WARDEN_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_DRUID_OF_THE_TALON_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SPIRIT_OF_VENGEANCE_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_WARDEN_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_TREE_OF_ETERNITY_ELF
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_PRISON_WAGON_ELF;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_GLAIVE_THROWER_ELF;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_PRISON_WAGON_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}
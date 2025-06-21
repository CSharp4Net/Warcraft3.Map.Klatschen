using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class ElvesTeam : TeamBase
  {
    public ElvesTeam() : base(Common.Player(8), Areas.ElfBase)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Gray}{Common.Player(8).Name}|r";
    }

    /// <inheritdoc/>
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
      UnitSpawnBuilding building = Computer.CreateBarrackBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF, Areas.ElfBarracksToCenter, Areas.ElfBarracksToCenterSpawn, Areas.OrcBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF, Areas.ElfBarracksToHuman, Areas.ElfBarracksToHumanSpawn, Areas.HumanBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF, Areas.ElfBarracksToUndead, Areas.ElfBarracksToUndeadSpawn, Areas.UndeadBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);
    }

    /// <inheritdoc/>
    public override Enums.ResearchType GetUnitUpgradeByResearch(int techId, int techLevel, out UnitUpgradeByResearchCommand command)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            UnitIdOfBuilding = Constants.UNIT_ANCIENT_OF_WAR_ELF,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_DRUID_OF_THE_CLAW_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_SENTRY_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_MOUNTAIN_GIANT_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_DRUID_OF_THE_CLAW_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_ANCIENT_OF_WAR_ELF,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_ARCHER_BESERK_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_ARCHER_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_ARCHER_ELITE_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_ARCHER_BESERK_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_ANCIENT_OF_WAR_ELF,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_HIPPOGRYPH_RIDER_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_FAERIE_DRAGON_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_CHIMAERA_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_HIPPOGRYPH_RIDER_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_ANCIENT_OF_WAR_ELF
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_WARDEN_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_DRUID_OF_THE_TALON_ELF;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_SPIRIT_OF_VENGEANCE_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_WARDEN_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_ANCIENT_OF_WAR_ELF
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_PRISON_WAGON_ELF;
              return Enums.ResearchType.AddUnit;

            default:
              command.UnitId = Constants.UNIT_GLAIVE_THROWER_ELF;
              command.UnitIdToUpgrade = Constants.UNIT_PRISON_WAGON_ELF;
              return Enums.ResearchType.UpgradeUnit;
          }

        default:
          command = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }

    /// <inheritdoc/>
    public override Enums.UnitUpgradeType GetUnitUpgradeBySold(int baseUnitTypeId, out UnitUpgradeBySoldCommand command)
    {
      switch (baseUnitTypeId)
      {
        case Constants.UNIT_DRUID_OF_THE_CLAW_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_SENTRY_ELF, baseUnitTypeId, Constants.UNIT_MOUNTAIN_GIANT_ELF);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_MOUNTAIN_GIANT_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_DRUID_OF_THE_CLAW_ELF, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_ARCHER_BESERK_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_ARCHER_ELF, baseUnitTypeId, Constants.UNIT_ARCHER_ELITE_ELF);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_ARCHER_ELITE_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_ARCHER_BESERK_ELF, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_WARDEN_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_DRUID_OF_THE_TALON_ELF, baseUnitTypeId, Constants.UNIT_SPIRIT_OF_VENGEANCE_ELF);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_SPIRIT_OF_VENGEANCE_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_WARDEN_ELF, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_FAERIE_DRAGON_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, baseUnitTypeId, Constants.UNIT_HIPPOGRYPH_RIDER_ELF);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_HIPPOGRYPH_RIDER_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_FAERIE_DRAGON_ELF, baseUnitTypeId, Constants.UNIT_CHIMAERA_ELF);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_CHIMAERA_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_HIPPOGRYPH_RIDER_ELF, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_PRISON_WAGON_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, baseUnitTypeId, Constants.UNIT_GLAIVE_THROWER_ELF);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_GLAIVE_THROWER_ELF:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, Constants.UNIT_PRISON_WAGON_ELF, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        default: // Einheiten-Typ ist nicht bekannt
          return base.GetUnitUpgradeBySold(baseUnitTypeId, out command);
      }
    }

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_SENTRY_ELF, Constants.UNIT_SENTRY_ELF, Constants.UNIT_ARCHER_ELF).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_DRUID_OF_THE_TALON_ELF).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_DRUID_OF_THE_CLAW_ELF, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_ARCHER_BESERK_ELF, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_WARDEN_ELF, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_FAERIE_DRAGON_ELF, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_PRISON_WAGON_ELF, 1, 1);
    }
  }
}
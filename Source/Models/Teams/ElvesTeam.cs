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
      MainBuilding mainBuilding = Computer.CreateMainBuilding(Constants.UNIT_TREE_OF_ETERNITY_ELF, Areas.ElfBase, "Abilities\\Spells\\Undead\\DeathPact\\DeathPactTarget.mdl");

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
              command.UnitId = Constants.UNIT_DRUID_OF_THE_CLAW_ELF_MELEE_2;
              command.UnitIdToUpgrade = Constants.UNIT_SENTRY_ELF_MELEE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_MOUNTAIN_GIANT_ELF_MELEE_3;
              command.UnitIdToUpgrade = Constants.UNIT_DRUID_OF_THE_CLAW_ELF_MELEE_2;
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
              command.UnitId = Constants.UNIT_ARCHER_BESERK_ELF_DISTANCE_2;
              command.UnitIdToUpgrade = Constants.UNIT_ARCHER_ELF_DISTANCE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_ARCHER_ELITE_ELF_DISTANCE_3;
              command.UnitIdToUpgrade = Constants.UNIT_ARCHER_BESERK_ELF_DISTANCE_2;
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
              command.UnitId = Constants.UNIT_HIPPOGRYPH_RIDER_ELF_FLY_2;
              command.UnitIdToUpgrade = Constants.UNIT_FAERIE_DRAGON_ELF_FLY_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_CHIMAERA_ELF_FLY_3;
              command.UnitIdToUpgrade = Constants.UNIT_HIPPOGRYPH_RIDER_ELF_FLY_2;
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
              command.UnitId = Constants.UNIT_WARDEN_ELF_MAGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_DRUID_OF_THE_TALON_ELF_MAGE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_SPIRIT_OF_VENGEANCE_ELF_MAGE_3;
              command.UnitIdToUpgrade = Constants.UNIT_WARDEN_ELF_MAGE_2;
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
              command.UnitId = Constants.UNIT_PRISON_WAGON_ELF_SIEGE_1;
              return Enums.ResearchType.AddUnit;

            default:
              command.UnitId = Constants.UNIT_GLAIVE_THROWER_ELF_SIEGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_PRISON_WAGON_ELF_SIEGE_1;
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
        case Constants.UNIT_DRUID_OF_THE_CLAW_ELF_MELEE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_SENTRY_ELF_MELEE_1, baseUnitTypeId, Constants.UNIT_MOUNTAIN_GIANT_ELF_MELEE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_MOUNTAIN_GIANT_ELF_MELEE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_DRUID_OF_THE_CLAW_ELF_MELEE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_ARCHER_BESERK_ELF_DISTANCE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_ARCHER_ELF_DISTANCE_1, baseUnitTypeId, Constants.UNIT_ARCHER_ELITE_ELF_DISTANCE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_ARCHER_ELITE_ELF_DISTANCE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_ARCHER_BESERK_ELF_DISTANCE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_WARDEN_ELF_MAGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_DRUID_OF_THE_TALON_ELF_MAGE_1, baseUnitTypeId, Constants.UNIT_SPIRIT_OF_VENGEANCE_ELF_MAGE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_SPIRIT_OF_VENGEANCE_ELF_MAGE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_WARDEN_ELF_MAGE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_FAERIE_DRAGON_ELF_FLY_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, baseUnitTypeId, Constants.UNIT_HIPPOGRYPH_RIDER_ELF_FLY_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_HIPPOGRYPH_RIDER_ELF_FLY_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_FAERIE_DRAGON_ELF_FLY_1, baseUnitTypeId, Constants.UNIT_CHIMAERA_ELF_FLY_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_CHIMAERA_ELF_FLY_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_HIPPOGRYPH_RIDER_ELF_FLY_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_PRISON_WAGON_ELF_SIEGE_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, baseUnitTypeId, Constants.UNIT_GLAIVE_THROWER_ELF_SIEGE_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_GLAIVE_THROWER_ELF_SIEGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, Constants.UNIT_PRISON_WAGON_ELF_SIEGE_1, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        default: // Einheiten-Typ ist nicht bekannt
          return base.GetUnitUpgradeBySold(baseUnitTypeId, out command);
      }
    }

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_SENTRY_ELF_MELEE_1, Constants.UNIT_SENTRY_ELF_MELEE_1, Constants.UNIT_ARCHER_ELF_DISTANCE_1).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_DRUID_OF_THE_TALON_ELF_MAGE_1).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_DRUID_OF_THE_CLAW_ELF_MELEE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_ARCHER_BESERK_ELF_DISTANCE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_WARDEN_ELF_MAGE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_FAERIE_DRAGON_ELF_FLY_1, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_PRISON_WAGON_ELF_SIEGE_1, 1, 1);
    }
  }
}
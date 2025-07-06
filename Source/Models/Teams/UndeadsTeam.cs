using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class UndeadsTeam : TeamBase
  {
    public UndeadsTeam() : base(Common.Player(12), Areas.UndeadBase, "Abilities\\Spells\\Undead\\RaiseSkeletonWarrior\\RaiseSkeleton.mdl")
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Maroon}{Common.Player(12).Name}|r";
    }

    /// <inheritdoc/>
    public override void CreateBuildings()
    {
      // Hauptgebäude
      MainBuilding mainBuilding = Computer.CreateMainBuilding(Constants.UNIT_BLACK_CITADEL_UNDEAD, Areas.UndeadBase);

      mainBuilding.RegisterOnDies(TeamMainBuilding.OnDies);
      mainBuilding.AddSpawnAttackRoute(Areas.UndeadBaseToCenterSpawn, Areas.HumanBase);
      mainBuilding.AddSpawnAttackRoute(Areas.UndeadBaseToElfSpawn, Areas.ElfBase);
      mainBuilding.AddSpawnAttackRoute(Areas.UndeadBaseToOrcsSpawn, Areas.OrcBase);

      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_FLESH_GOLEM_UNDEAD, 1, 1);
      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_NETHER_DRAGON_UNDEAD, 1, 1);

      // Kasernen
      UnitSpawnBuilding building = Computer.CreateBarrackBuilding(Constants.UNIT_CRYPT_UNDEAD, Areas.UndeadBarracksToCenter, Areas.UndeadBarracksToCenterSpawn, Areas.HumanBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_CRYPT_UNDEAD, Areas.UndeadBarracksToElf, Areas.UndeadBarracksToElfSpawn, Areas.ElfBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_CRYPT_UNDEAD, Areas.UndeadBarracksToOrcs, Areas.UndeadBarracksToOrcsSpawn, Areas.OrcBase);
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
            UnitIdOfBuilding = Constants.UNIT_CRYPT_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_SKELETON_WARRIOR_UNDEAD_MELEE_2;
              command.UnitIdToUpgrade = Constants.UNIT_GHOUL_UNDEAD_MELEE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_ABOMINATION_UNDEAD_MELEE_3;
              command.UnitIdToUpgrade = Constants.UNIT_SKELETON_WARRIOR_UNDEAD_MELEE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_CRYPT_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD_DISTANCE_2;
              command.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_UNDEAD_DISTANCE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD_DISTANCE_3;
              command.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD_DISTANCE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_DESTROYER_UNDEAD_FLY_2;
              command.UnitIdToUpgrade = Constants.UNIT_GARGOYLE_UNDEAD_FLY_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_FROST_WYRM_UNDEAD_FLY_3;
              command.UnitIdToUpgrade = Constants.UNIT_DESTROYER_UNDEAD_FLY_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_NECROMANCER_UNDEAD_MAGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_SKELETAL_MAGE_UNDEAD_MAGE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_BANSHEE_UNDEAD_MAGE_3;
              command.UnitIdToUpgrade = Constants.UNIT_NECROMANCER_UNDEAD_MAGE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD_SIEGE_1;
              return Enums.ResearchType.AddUnit;

            default:
              command.UnitId = Constants.UNIT_MEAT_WAGON_UNDEAD_SIEGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD_SIEGE_1;
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
        case Constants.UNIT_SKELETON_WARRIOR_UNDEAD_MELEE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_GHOUL_UNDEAD_MELEE_1, baseUnitTypeId, Constants.UNIT_ABOMINATION_UNDEAD_MELEE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_ABOMINATION_UNDEAD_MELEE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_SKELETON_WARRIOR_UNDEAD_MELEE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD_DISTANCE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_CRYPT_FIEND_UNDEAD_DISTANCE_1, baseUnitTypeId, Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD_DISTANCE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD_DISTANCE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD_DISTANCE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_NECROMANCER_UNDEAD_MAGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_SKELETAL_MAGE_UNDEAD_MAGE_1, baseUnitTypeId, Constants.UNIT_BANSHEE_UNDEAD_MAGE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_BANSHEE_UNDEAD_MAGE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_NECROMANCER_UNDEAD_MAGE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_GARGOYLE_UNDEAD_FLY_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, baseUnitTypeId, Constants.UNIT_DESTROYER_UNDEAD_FLY_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_DESTROYER_UNDEAD_FLY_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_GARGOYLE_UNDEAD_FLY_1, baseUnitTypeId, Constants.UNIT_FROST_WYRM_UNDEAD_FLY_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_FROST_WYRM_UNDEAD_FLY_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_DESTROYER_UNDEAD_FLY_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_OBSIDIAN_STATUE_UNDEAD_SIEGE_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, baseUnitTypeId, Constants.UNIT_MEAT_WAGON_UNDEAD_SIEGE_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_MEAT_WAGON_UNDEAD_SIEGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, Constants.UNIT_OBSIDIAN_STATUE_UNDEAD_SIEGE_1, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        default: // Einheiten-Typ ist nicht bekannt
          return base.GetUnitUpgradeBySold(baseUnitTypeId, out command);
      }
    }

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_GHOUL_UNDEAD_MELEE_1, Constants.UNIT_GHOUL_UNDEAD_MELEE_1, Constants.UNIT_CRYPT_FIEND_UNDEAD_DISTANCE_1).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_SKELETAL_MAGE_UNDEAD_MAGE_1).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_SKELETON_WARRIOR_UNDEAD_MELEE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD_DISTANCE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_NECROMANCER_UNDEAD_MAGE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_GARGOYLE_UNDEAD_FLY_1, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_OBSIDIAN_STATUE_UNDEAD_SIEGE_1, 1, 1);
    }
  }
}
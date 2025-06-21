using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class UndeadsTeam : TeamBase
  {
    public UndeadsTeam() : base(Common.Player(12), Areas.UndeadBase)
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
              command.UnitId = Constants.UNIT_SKELETON_WARRIOR_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_GHOUL_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_ABOMINATION_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_SKELETON_WARRIOR_UNDEAD;
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
              command.UnitId = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD;
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
              command.UnitId = Constants.UNIT_DESTROYER_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_GARGOYLE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_FROST_WYRM_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_DESTROYER_UNDEAD;
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
              command.UnitId = Constants.UNIT_NECROMANCER_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_SKELETAL_MAGE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_BANSHEE_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_NECROMANCER_UNDEAD;
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
              command.UnitId = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD;
              return Enums.ResearchType.AddUnit;

            default:
              command.UnitId = Constants.UNIT_MEAT_WAGON_UNDEAD;
              command.UnitIdToUpgrade = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD;
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
        case Constants.UNIT_SKELETON_WARRIOR_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_GHOUL_UNDEAD, baseUnitTypeId, Constants.UNIT_ABOMINATION_UNDEAD);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_ABOMINATION_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_SKELETON_WARRIOR_UNDEAD, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_CRYPT_FIEND_UNDEAD, baseUnitTypeId, Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_NECROMANCER_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_SKELETAL_MAGE_UNDEAD, baseUnitTypeId, Constants.UNIT_BANSHEE_UNDEAD);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_BANSHEE_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_NECROMANCER_UNDEAD, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_GARGOYLE_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, baseUnitTypeId, Constants.UNIT_DESTROYER_UNDEAD);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_DESTROYER_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_GARGOYLE_UNDEAD, baseUnitTypeId, Constants.UNIT_FROST_WYRM_UNDEAD);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_FROST_WYRM_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_DESTROYER_UNDEAD, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_OBSIDIAN_STATUE_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, baseUnitTypeId, Constants.UNIT_MEAT_WAGON_UNDEAD);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_MEAT_WAGON_UNDEAD:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, Constants.UNIT_OBSIDIAN_STATUE_UNDEAD, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        default: // Einheiten-Typ ist nicht bekannt
          return base.GetUnitUpgradeBySold(baseUnitTypeId, out command);
      }
    }

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_GHOUL_UNDEAD, Constants.UNIT_GHOUL_UNDEAD, Constants.UNIT_CRYPT_FIEND_UNDEAD).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_SKELETAL_MAGE_UNDEAD).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_SKELETON_WARRIOR_UNDEAD, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_NECROMANCER_UNDEAD, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_GARGOYLE_UNDEAD, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_OBSIDIAN_STATUE_UNDEAD, 1, 1);
    }
  }
}
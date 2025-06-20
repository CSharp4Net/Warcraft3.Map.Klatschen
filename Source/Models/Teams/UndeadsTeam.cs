using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class UndeadsTeam : TeamBase
  {
    public UndeadsTeam()
      : base(Common.Player(12), Areas.UndeadBase)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Maroon}{Common.Player(12).Name}|r";
    }

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

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_GHOUL_UNDEAD, Constants.UNIT_GHOUL_UNDEAD, Constants.UNIT_CRYPT_FIEND_UNDEAD).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_SKELETAL_MAGE_UNDEAD).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
      // TODO
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_CAPTAIN_HUMAN, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_RIFLEMAN_BESERK_HUMAN, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_SORCERESS_HUMAN, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_FLYING_MACHINE_HUMAN, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_SIEGE_SQUAD_HUMAN, 1, 1);
    }

    public override Enums.ResearchType GetTechType(int techId, int techLevel, out SpawnUnitCommand spawnCommand)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            UnitIdOfBuilding = Constants.UNIT_CRYPT_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SKELETON_WARRIOR_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_GHOUL_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_ABOMINATION_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SKELETON_WARRIOR_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_CRYPT_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_CRYPT_FIEND_ELITE_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_CRYPT_FIEND_BESERK_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_DESTROYER_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_GARGOYLE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_FROST_WYRM_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_DESTROYER_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_NECROMANCER_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SKELETAL_MAGE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_BANSHEE_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_NECROMANCER_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_BLACK_CITADEL_UNDEAD
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_MEAT_WAGON_UNDEAD;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_OBSIDIAN_STATUE_UNDEAD;
              return Enums.ResearchType.UpgradeUnit;
          }

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}
using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class HumansTeam : TeamBase
  {
    public HumansTeam() : base(Common.Player(0), Areas.HumanBase)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Red}{Common.Player(0).Name}|r";
    }

    public override void CreateBuildings()
    {
      // Hauptgebäude
      MainBuilding mainBuilding = Computer.CreateMainBuilding(Constants.UNIT_CASTLE_HUMAN, Areas.HumanBase);

      mainBuilding.RegisterOnDies(TeamMainBuilding.OnDies);
      mainBuilding.AddSpawnAttackRoute(Areas.HumanBaseToCenterSpawn, Areas.UndeadBase);
      mainBuilding.AddSpawnAttackRoute(Areas.HumanBaseToElfSpawn, Areas.ElfBase);
      mainBuilding.AddSpawnAttackRoute(Areas.HumanBaseToOrcsSpawn, Areas.OrcBase);

      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_WAR_GOLEM_HUMAN, 1, 1);

      // Kasernen
      UnitSpawnBuilding building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_HUMAN, Areas.HumanBarracksToCenter, Areas.HumanBarracksToCenterSpawn, Areas.UndeadBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_HUMAN, Areas.HumanBarracksToElf, Areas.HumanBarracksToElfSpawn, Areas.ElfBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_HUMAN, Areas.HumanBarracksToOrcs, Areas.HumanBarracksToOrcsSpawn, Areas.OrcBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);
    }

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_SOLDIER_HUMAN, Constants.UNIT_SOLDIER_HUMAN, Constants.UNIT_RIFLEMAN_HUMAN).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_PRIEST_HUMAN).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
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
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_CAPTAIN_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SOLDIER_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_KNIGHT_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_CAPTAIN_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_RIFLEMAN_BESERK_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_RIFLEMAN_ELITE_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_BESERK_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_FALCON_RIDER_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FLYING_MACHINE_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_GRIFFIN_RIDER_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_FALCON_RIDER_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SORCERESS_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_PRIEST_HUMAN;
              return Enums.ResearchType.UpgradeUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SPELLBREAKER_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SORCERESS_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              spawnCommand.UnitId = Constants.UNIT_SIEGE_SQUAD_HUMAN;
              return Enums.ResearchType.AddUnit;

            default:
              spawnCommand.UnitId = Constants.UNIT_SIEGE_ENGINE_HUMAN;
              spawnCommand.UnitIdToUpgrade = Constants.UNIT_SIEGE_SQUAD_HUMAN;
              return Enums.ResearchType.UpgradeUnit;
          }

        default: // Einfache Verbeserungen bestehender Einheiten
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }

    public override Enums.UnitUpgradeType DetermineTypeOfUnitUpgrade(int baseUnitTypeId, out UpgradeUnitCommand upgradeUnitCommand)
    {
      switch (baseUnitTypeId)
      {
        case Constants.UNIT_CAPTAIN_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Short, Constants.UNIT_SOLDIER_HUMAN, baseUnitTypeId, Constants.UNIT_KNIGHT_HUMAN);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_KNIGHT_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Short, Constants.UNIT_CAPTAIN_HUMAN, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_RIFLEMAN_BESERK_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Short, Constants.UNIT_RIFLEMAN_HUMAN, baseUnitTypeId, Constants.UNIT_RIFLEMAN_ELITE_HUMAN);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_RIFLEMAN_ELITE_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Short, Constants.UNIT_RIFLEMAN_BESERK_HUMAN, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_SORCERESS_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Middle, Constants.UNIT_RIFLEMAN_HUMAN, baseUnitTypeId, Constants.UNIT_SPELLBREAKER_HUMAN);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_SPELLBREAKER_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Middle, Constants.UNIT_SORCERESS_HUMAN, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_FLYING_MACHINE_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Middle, baseUnitTypeId, Constants.UNIT_FALCON_RIDER_HUMAN);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_FALCON_RIDER_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Middle, Constants.UNIT_FLYING_MACHINE_HUMAN, baseUnitTypeId, Constants.UNIT_GRIFFIN_RIDER_HUMAN);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_GRIFFIN_RIDER_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Middle, Constants.UNIT_FALCON_RIDER_HUMAN, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_SIEGE_SQUAD_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Long, baseUnitTypeId, Constants.UNIT_SIEGE_ENGINE_HUMAN);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_SIEGE_ENGINE_HUMAN:
          upgradeUnitCommand = new UpgradeUnitCommand(Enums.SpawnInterval.Long, Constants.UNIT_SIEGE_SQUAD_HUMAN, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        default: // Einheiten-Typ ist nicht bekannt
          return base.DetermineTypeOfUnitUpgrade(baseUnitTypeId, out upgradeUnitCommand);
      }
    }
  }
}
using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class HumansTeam : TeamBase
  {
    public HumansTeam() : base(Common.Player(0), Areas.HumanBase, "Abilities\\Spells\\Human\\HolyBolt\\HolyBoltSpecialArt.mdl")
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Red}{Common.Player(0).Name}|r";
    }

    /// <inheritdoc/>
    public override void CreateBuildings()
    {
      // Hauptgebäude
      MainBuilding mainBuilding = Computer.CreateMainBuilding(Constants.UNIT_CASTLE_HUMAN, Areas.HumanBase);

      mainBuilding.RegisterOnDies(TeamMainBuilding.OnDies);
      mainBuilding.AddSpawnAttackRoute(Areas.HumanBaseToCenterSpawn, Areas.UndeadBase);
      mainBuilding.AddSpawnAttackRoute(Areas.HumanBaseToElfSpawn, Areas.ElfBase);
      mainBuilding.AddSpawnAttackRoute(Areas.HumanBaseToOrcsSpawn, Areas.OrcBase);

      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_WAR_GOLEM_HUMAN, 1, 1);
      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_BLUE_WHELP_HUMAN_DRAGON_1, 4, 4);
      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_BLUE_JUVENILE_HUMAN_DRAGON_2, 3, 3);
      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_BLUE_DRAGON_HUMAN_DRAGON_3, 2, 2);
      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_BLUE_DRAKE_HUMAN_DRAGON_4, 1, 1);

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

    /// <inheritdoc/>
    public override Enums.ResearchType GetUnitUpgradeByResearch(int techId, int techLevel, out UnitUpgradeByResearchCommand command)
    {
      switch (techId)
      {
        case Constants.UPGRADE_MELEE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Short,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_CAPTAIN_HUMAN_MELEE_2;
              command.UnitIdToUpgrade = Constants.UNIT_SOLDIER_HUMAN_MELEE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_KNIGHT_HUMAN_MELEE_3;
              command.UnitIdToUpgrade = Constants.UNIT_CAPTAIN_HUMAN_MELEE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_RIFLEMAN_BESERK_HUMAN_DISTANCE_2;
              command.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_HUMAN_DISTANCE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_RIFLEMAN_ELITE_HUMAN_DISTANCE_3;
              command.UnitIdToUpgrade = Constants.UNIT_RIFLEMAN_BESERK_HUMAN_DISTANCE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_FALCON_RIDER_HUMAN_FLY_2;
              command.UnitIdToUpgrade = Constants.UNIT_FLYING_MACHINE_HUMAN_FLY_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_GRYPHON_RIDER_HUMAN_FLY_3;
              command.UnitIdToUpgrade = Constants.UNIT_FALCON_RIDER_HUMAN_FLY_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_SORCERESS_HUMAN_MAGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_PRIEST_HUMAN_MAGE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_SPELLBREAKER_HUMAN_MAGE_3;
              command.UnitIdToUpgrade = Constants.UNIT_SORCERESS_HUMAN_MAGE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_HUMAN
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_SIEGE_SQUAD_HUMAN_SIEGE_1;
              return Enums.ResearchType.AddUnit;

            default:
              command.UnitId = Constants.UNIT_SIEGE_ENGINE_HUMAN_SIEGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_SIEGE_SQUAD_HUMAN_SIEGE_1;
              return Enums.ResearchType.UpgradeUnit;
          }

        default: // Einfache Verbeserungen bestehender Einheiten
          command = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }

    /// <inheritdoc/>
    public override Enums.UnitUpgradeType GetUnitUpgradeBySold(int baseUnitTypeId, out UnitUpgradeBySoldCommand command)
    {
      switch (baseUnitTypeId)
      {
        case Constants.UNIT_CAPTAIN_HUMAN_MELEE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_SOLDIER_HUMAN_MELEE_1, baseUnitTypeId, Constants.UNIT_KNIGHT_HUMAN_MELEE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_KNIGHT_HUMAN_MELEE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_CAPTAIN_HUMAN_MELEE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_RIFLEMAN_BESERK_HUMAN_DISTANCE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_RIFLEMAN_HUMAN_DISTANCE_1, baseUnitTypeId, Constants.UNIT_RIFLEMAN_ELITE_HUMAN_DISTANCE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_RIFLEMAN_ELITE_HUMAN_DISTANCE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_RIFLEMAN_BESERK_HUMAN_DISTANCE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_SORCERESS_HUMAN_MAGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_PRIEST_HUMAN_MAGE_1, baseUnitTypeId, Constants.UNIT_SPELLBREAKER_HUMAN_MAGE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_SPELLBREAKER_HUMAN_MAGE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_SORCERESS_HUMAN_MAGE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_FLYING_MACHINE_HUMAN_FLY_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, baseUnitTypeId, Constants.UNIT_FALCON_RIDER_HUMAN_FLY_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_FALCON_RIDER_HUMAN_FLY_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_FLYING_MACHINE_HUMAN_FLY_1, baseUnitTypeId, Constants.UNIT_GRYPHON_RIDER_HUMAN_FLY_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_GRYPHON_RIDER_HUMAN_FLY_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_FALCON_RIDER_HUMAN_FLY_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_SIEGE_SQUAD_HUMAN_SIEGE_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, baseUnitTypeId, Constants.UNIT_SIEGE_ENGINE_HUMAN_SIEGE_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_SIEGE_ENGINE_HUMAN_SIEGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, Constants.UNIT_SIEGE_SQUAD_HUMAN_SIEGE_1, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        default: // Einheiten-Typ ist nicht bekannt
          return base.GetUnitUpgradeBySold(baseUnitTypeId, out command);
      }
    }

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_SOLDIER_HUMAN_MELEE_1, Constants.UNIT_SOLDIER_HUMAN_MELEE_1, Constants.UNIT_RIFLEMAN_HUMAN_DISTANCE_1).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_PRIEST_HUMAN_MAGE_1).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_CAPTAIN_HUMAN_MELEE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_RIFLEMAN_BESERK_HUMAN_DISTANCE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_SORCERESS_HUMAN_MAGE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_FLYING_MACHINE_HUMAN_FLY_1, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_SIEGE_SQUAD_HUMAN_SIEGE_1, 1, 1);
    }
  }
}
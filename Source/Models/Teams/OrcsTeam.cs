using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class OrcsTeam : TeamBase
  {
    public OrcsTeam() : base(Common.Player(4), Areas.OrcBase, "Abilities\\Spells\\Items\\AIam\\AIamTarget.mdl")
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Yellow}{Common.Player(4).Name}|r";
    }

    /// <inheritdoc/>
    public override void CreateBuildings()
    {
      // Hauptgebäude
      MainBuilding mainBuilding = Computer.CreateMainBuilding(Constants.UNIT_FORTRESS_ORC, Areas.OrcBase);

      mainBuilding.RegisterOnDies(TeamMainBuilding.OnDies);
      mainBuilding.AddSpawnAttackRoute(Areas.OrcBaseToCenterSpawn, Areas.ElfBase);
      mainBuilding.AddSpawnAttackRoute(Areas.OrcBaseToHumanSpawn, Areas.HumanBase);
      mainBuilding.AddSpawnAttackRoute(Areas.OrcBaseToUndeadSpawn, Areas.UndeadBase);

      mainBuilding.Wc3Unit.AddUnitToStock(Constants.UNIT_MUD_GOLEM_ORC, 1, 1);

      // Kasernen
      UnitSpawnBuilding building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_ORC, Areas.OrcBarracksToCenter, Areas.OrcBarracksToCenterSpawn, Areas.ElfBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_ORC, Areas.OrcBarracksToHuman, Areas.OrcBarracksToHumanSpawn, Areas.HumanBase);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);

      AddInitialSpawnTriggers(building);
      AddInitialUnitUpgradesToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_ORC, Areas.OrcBarracksToUndead, Areas.OrcBarracksToUndeadSpawn, Areas.UndeadBase);
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
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_ORC,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_BESERK_ORC_MELEE_2;
              command.UnitIdToUpgrade = Constants.UNIT_GRUNT_ORC_MELEE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_TAUREN_ORC_MELEE_3;
              command.UnitIdToUpgrade = Constants.UNIT_BESERK_ORC_MELEE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_DISTANCE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_ORC,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_HEADHUNTER_BESERK_ORC_DISTANCE_2;
              command.UnitIdToUpgrade = Constants.UNIT_HEADHUNTER_ORC_DISTANCE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_HEADHUNTER_ELITE_ORC_DISTANCE_3;
              command.UnitIdToUpgrade = Constants.UNIT_HEADHUNTER_BESERK_ORC_DISTANCE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_FLIGHT_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_ORC,
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_WIND_RIDER_ORC_FLY_2;
              command.UnitIdToUpgrade = Constants.UNIT_BATRIDER_ORC_FLY_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_SPIRIT_WIND_RIDER_ORC_FLY_3;
              command.UnitIdToUpgrade = Constants.UNIT_WIND_RIDER_ORC_FLY_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_MAGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Middle,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_ORC
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_SHAMAN_ORC_MAGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_WITCH_DOCTOR_ORC_MAGE_1;
              return Enums.ResearchType.UpgradeUnit;

            default:
              command.UnitId = Constants.UNIT_WARLOCK_ORC_MAGE_3;
              command.UnitIdToUpgrade = Constants.UNIT_SHAMAN_ORC_MAGE_2;
              return Enums.ResearchType.UpgradeUnit;
          }

        case Constants.UPGRADE_SIEGE_UNIT_TEAM:
          command = new UnitUpgradeByResearchCommand()
          {
            UnitSpawnType = Enums.SpawnInterval.Long,
            UnitIdOfBuilding = Constants.UNIT_BARRACKS_ORC
          };

          switch (techLevel)
          {
            case 1:
              command.UnitId = Constants.UNIT_KODO_BEAST_ORC_SIEGE_1;
              return Enums.ResearchType.AddUnit;

            default:
              command.UnitId = Constants.UNIT_DEMOLISHER_ORC_SIEGE_2;
              command.UnitIdToUpgrade = Constants.UNIT_KODO_BEAST_ORC_SIEGE_1;
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
        case Constants.UNIT_BESERK_ORC_MELEE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_GRUNT_ORC_MELEE_1, baseUnitTypeId, Constants.UNIT_TAUREN_ORC_MELEE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_TAUREN_ORC_MELEE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_BESERK_ORC_MELEE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_HEADHUNTER_BESERK_ORC_DISTANCE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_HEADHUNTER_ORC_DISTANCE_1, baseUnitTypeId, Constants.UNIT_HEADHUNTER_ELITE_ORC_DISTANCE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_HEADHUNTER_ELITE_ORC_DISTANCE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Short, Constants.UNIT_HEADHUNTER_BESERK_ORC_DISTANCE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_SHAMAN_ORC_MAGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_WITCH_DOCTOR_ORC_MAGE_1, baseUnitTypeId, Constants.UNIT_WARLOCK_ORC_MAGE_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_WARLOCK_ORC_MAGE_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_SHAMAN_ORC_MAGE_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_BATRIDER_ORC_FLY_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, baseUnitTypeId, Constants.UNIT_WIND_RIDER_ORC_FLY_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_WIND_RIDER_ORC_FLY_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_BATRIDER_ORC_FLY_1, baseUnitTypeId, Constants.UNIT_SPIRIT_WIND_RIDER_ORC_FLY_3);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;
        case Constants.UNIT_SPIRIT_WIND_RIDER_ORC_FLY_3:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Middle, Constants.UNIT_WIND_RIDER_ORC_FLY_2, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        case Constants.UNIT_KODO_BEAST_ORC_SIEGE_1:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, baseUnitTypeId, Constants.UNIT_DEMOLISHER_ORC_SIEGE_2);
          return Enums.UnitUpgradeType.AddNewUnitToSpawn;
        case Constants.UNIT_DEMOLISHER_ORC_SIEGE_2:
          command = new UnitUpgradeBySoldCommand(Enums.SpawnInterval.Long, Constants.UNIT_KODO_BEAST_ORC_SIEGE_1, baseUnitTypeId, 0);
          return Enums.UnitUpgradeType.UpgradeUnitInSpawn;

        default: // Einheiten-Typ ist nicht bekannt
          return base.GetUnitUpgradeBySold(baseUnitTypeId, out command);
      }
    }

    private void AddInitialSpawnTriggers(UnitSpawnBuilding building)
    {
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_GRUNT_ORC_MELEE_1, Constants.UNIT_GRUNT_ORC_MELEE_1, Constants.UNIT_HEADHUNTER_ORC_DISTANCE_1).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_WITCH_DOCTOR_ORC_MAGE_1).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long).Run(2f);
    }

    private void AddInitialUnitUpgradesToStock(UnitSpawnBuilding building)
    {
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_BESERK_ORC_MELEE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_HEADHUNTER_BESERK_ORC_DISTANCE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_SHAMAN_ORC_MAGE_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_BATRIDER_ORC_FLY_1, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_KODO_BEAST_ORC_SIEGE_1, 1, 1);
    }
  }
}
using Source.Abstracts;
using Source.Events.Buildings;
using WCSharp.Api;

namespace Source.Models.Teams
{
  public sealed class OrcsTeam : TeamBase
  {
    public OrcsTeam()
      : base(Common.Player(4), Areas.OrcBase)
    {
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Yellow}{Common.Player(4).Name}|r";
    }

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
      UnitSpawnBuilding building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_ORC,
        Areas.OrcBarracksToCenter, Areas.OrcBarracksToCenterSpawn, Areas.ElfBase);

      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_GRUNT_ORC, Constants.UNIT_GRUNT_ORC).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_HEADHUNTER_ORC).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long, Constants.UNIT_WITCH_DOCTOR_ORC).Run(2f);

      AddBaseUnitsToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_ORC,
        Areas.OrcBarracksToHuman, Areas.OrcBarracksToHumanSpawn, Areas.HumanBase);

      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_GRUNT_ORC, Constants.UNIT_GRUNT_ORC).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_HEADHUNTER_ORC).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long, Constants.UNIT_WITCH_DOCTOR_ORC).Run(2f);

      AddBaseUnitsToStock(building);

      building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_ORC,
        Areas.OrcBarracksToUndead, Areas.OrcBarracksToUndeadSpawn, Areas.UndeadBase);

      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Enums.SpawnInterval.Short, Constants.UNIT_GRUNT_ORC, Constants.UNIT_GRUNT_ORC).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Middle, Constants.UNIT_HEADHUNTER_ORC).Run(1f);
      building.AddSpawnTrigger(Enums.SpawnInterval.Long, Constants.UNIT_WITCH_DOCTOR_ORC).Run(2f);

      AddBaseUnitsToStock(building);

#if DEBUG
      building = Computer.CreateBarrackBuilding(Constants.UNIT_BARRACKS_ORC,
        Areas.TestArea3, Areas.HumanBarracksToOrcsSpawn, Areas.OrcBase);

      AddBaseUnitsToStock(building);
#endif
    }

    private void AddBaseUnitsToStock(UnitSpawnBuilding building)
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

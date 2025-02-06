using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Handler.GenericEvents
{
  internal static class Research
  {
    internal static void OnFinished()
    {
      try
      {
        unit unit = Common.GetResearchingUnit();
        int researchedTechId = Common.GetResearched();
        int researchedTechIdCount = Common.GetPlayerTechCount(unit.Owner, researchedTechId, true);

        Console.WriteLine($"Forschung {researchedTechId} (Stufe {researchedTechIdCount}) abgeschlossen von {unit.Owner.Name}!");

        player owner = unit.Owner;
        Enums.ResearchType researchType = TryGetSpawnUnitCommandByResearchedTech(researchedTechId,
          out SpawnUnitCommand spawnCommand);

        //if (Program.Humans.ContainsPlayer(unit.Owner, out UserPlayer foundUser))
        {
          Program.Humans.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Humans.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Humans.Computer.UpgradeSpawnUnit(spawnCommand);
            Program.Humans.Computer.AddSpawnUnit(spawnCommand); // TEST
          }
        }
        //else if (Program.Orcs.ContainsPlayer(unit.Owner, out foundUser))
        {
          Program.Orcs.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Orcs.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Orcs.Computer.UpgradeSpawnUnit(spawnCommand);
            Program.Orcs.Computer.AddSpawnUnit(spawnCommand); // TEST
          }
        }
        //else if (Program.Elves.ContainsPlayer(unit.Owner, out foundUser))
        {
          Program.Elves.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Elves.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Elves.Computer.UpgradeSpawnUnit(spawnCommand);
            Program.Elves.Computer.AddSpawnUnit(spawnCommand); // TEST
          }
        }
        //else if (Program.Undeads.ContainsPlayer(unit.Owner, out foundUser))
        {
          Program.Undeads.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Undeads.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Undeads.Computer.UpgradeSpawnUnit(spawnCommand);
            Program.Undeads.Computer.AddSpawnUnit(spawnCommand); // TEST
          }
        }
      }
      catch (Exception ex)
      {
        Program.ShowDebugMessage("Research.OnFinished", ex);
      }
    }

    private static Enums.ResearchType TryGetSpawnUnitCommandByResearchedTech(int researchedTechId, out SpawnUnitCommand spawnCommand)
    {
      switch (researchedTechId)
      {
        case Constants.UPGRADE_REKRUTIERUNG_SOLDATEN_STUFE_2_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Meelee,
            UnitIdOfBuilding = Constants.UNIT_KASERNE_HUMAN,
            UnitId = Constants.UNIT_SOLDAT_STUFE_2_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_SOLDAT_STUFE_1_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;
        case Constants.UPGRADE_REKRUTIERUNG_SOLDATEN_STUFE_3_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Meelee,
            UnitIdOfBuilding = Constants.UNIT_KASERNE_HUMAN,
            UnitId = Constants.UNIT_SOLDAT_STUFE_3_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_SOLDAT_STUFE_2_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;

        case Constants.UPGRADE_REKRUTIERUNG_SCH_TZEN_STUFE_2_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_KASERNE_HUMAN,
            UnitId = Constants.UNIT_SCH_TZE_STUFE_2_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_1_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;
        case Constants.UPGRADE_REKRUTIERUNG_SCH_TZEN_STUFE_3_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_KASERNE_HUMAN,
            UnitId = Constants.UNIT_SCH_TZE_STUFE_3_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_SCH_TZE_STUFE_2_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;

        case Constants.UPGRADE_REKRUTIERUNG_LUFTEINHEIT_STUFE_1_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHLOSS_HUMAN,
            UnitId = Constants.UNIT_LUFTEINHEIT_STUFE_1_HUMAN
          };
          return Enums.ResearchType.AddUnit;
        case Constants.UPGRADE_REKRUTIERUNG_LUFTEINHEIT_STUFE_2_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHLOSS_HUMAN,
            UnitId = Constants.UNIT_LUFTEINHEIT_STUFE_2_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_LUFTEINHEIT_STUFE_1_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;
        case Constants.UPGRADE_REKRUTIERUNG_LUFTEINHEIT_STUFE_3_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHLOSS_HUMAN,
            UnitId = Constants.UNIT_LUFTEINHEIT_STUFE_3_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_LUFTEINHEIT_STUFE_2_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;

        case Constants.UPGRADE_REKRUTIERUNG_MAGIER_STUFE_2_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHLOSS_HUMAN,
            UnitId = Constants.UNIT_MAGIER_STUFE_2_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_MAGIER_STUFE_1_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;
        case Constants.UPGRADE_REKRUTIERUNG_MAGIER_STUFE_3_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHLOSS_HUMAN,
            UnitId = Constants.UNIT_MAGIER_STUFE_3_HUMAN,
            UnitIdToUpgrade = Constants.UNIT_MAGIER_STUFE_2_HUMAN
          };
          return Enums.ResearchType.UpgradeUnit;

        case Constants.UPGRADE_REKRUTIERUNG_BELAGERUNGSMASCHINEN_HUMAN:
          spawnCommand = new SpawnUnitCommand()
          {
            UnitSpawnType = Enums.UnitSpawnType.Distance,
            UnitIdOfBuilding = Constants.UNIT_SCHLOSS_HUMAN,
            UnitId = Constants.UNIT_BELAGERUNGSMASCHINE_STUFE_1_HUMAN
          };
          return Enums.ResearchType.AddUnit;

        // TODO

        default:
          spawnCommand = null;
          return Enums.ResearchType.CommonUpgrade;
      }
    }
  }
}

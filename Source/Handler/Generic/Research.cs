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
        ResearchType researchType = TryGetResearchedUnit(researchedTechId, out int reseachedUnitId, out int spawnBuildingUnitId);

        if (Program.Humans.ContainsPlayer(unit.Owner, out UserPlayer foundUser))
        {
          Program.Humans.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == ResearchType.AddUnit)
            Program.Humans.Computer.AddSpawnUnit(spawnBuildingUnitId, reseachedUnitId);
          else if (researchType == ResearchType.UpgradeUnit)
            Program.Humans.Computer.AddSpawnUnit(spawnBuildingUnitId, reseachedUnitId);
        }
        else if (Program.Orcs.ContainsPlayer(unit.Owner, out foundUser))
        {
          Program.Orcs.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == ResearchType.AddUnit)
            Program.Orcs.Computer.AddSpawnUnit(spawnBuildingUnitId, reseachedUnitId);
        }
        else if (Program.Elves.ContainsPlayer(unit.Owner, out foundUser))
        {
          Program.Elves.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == ResearchType.AddUnit)
            Program.Elves.Computer.AddSpawnUnit(spawnBuildingUnitId, reseachedUnitId);
        }
        else if (Program.Undeads.ContainsPlayer(unit.Owner, out foundUser))
        {
          Program.Undeads.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == ResearchType.AddUnit)
            Program.Undeads.Computer.AddSpawnUnit(spawnBuildingUnitId, reseachedUnitId);
        }
      }
      catch (Exception ex)
      {
        Program.ShowDebugMessage("Research.OnFinished", ex);
      }
    }

    private static ResearchType TryGetResearchedUnit(int researchedTechId, out int reseachedUnitId, out int spawnBuildingUnitId)
    {
      switch (researchedTechId)
      {
        case Constants.UPGRADE_NAHKAMPF_TRAINING_1_HUMAN:
          reseachedUnitId = Constants.UNIT_RITTER_HUMAN;
          spawnBuildingUnitId = Constants.UNIT_SCHLOSS_HUMAN;
          return ResearchType.UpgradeUnit;
        case Constants.UPGRADE_NAHKAMPF_TRAINING_2_HUMAN:
          reseachedUnitId = Constants.UNIT_RITTER_HUMAN;
          spawnBuildingUnitId = Constants.UNIT_SCHLOSS_HUMAN;
          return ResearchType.UpgradeUnit;

        // TODO

        default:
          reseachedUnitId = 0;
          spawnBuildingUnitId = 0;
          return ResearchType.CommonUpgrade;
      }
    }

    private enum ResearchType
    {
      CommonUpgrade = 0,
      AddUnit = 1,
      UpgradeUnit = 2,
    }
  }
}

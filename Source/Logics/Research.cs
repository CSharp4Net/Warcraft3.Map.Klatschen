using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Logics
{
  internal static class Research
  {
    internal static void HandleResearchFinished(unit researchingUnit, int researchedTechId)
    {
      try
      {
        int researchedTechIdCount = Common.GetPlayerTechCount(researchingUnit.Owner, researchedTechId, true);

        player player = researchingUnit.Owner;
        int playerId = player.Id;
        Enums.ResearchType researchType;

        if (Program.Humans.ContainsPlayer(playerId, out UserPlayer foundUser))
        {
          researchType = Program.Humans.GetTechType(researchedTechId, researchedTechIdCount, out SpawnUnitCommand spawnCommand);

          Program.Humans.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Humans.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Humans.Computer.UpgradeSpawnUnit(spawnCommand);
          }
        }
        else if (Program.Orcs.ContainsPlayer(playerId, out foundUser))
        {
          researchType = Program.Orcs.GetTechType(researchedTechId, researchedTechIdCount, out SpawnUnitCommand spawnCommand);

          Program.Orcs.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Orcs.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Orcs.Computer.UpgradeSpawnUnit(spawnCommand);
          }
        }
        else if (Program.Elves.ContainsPlayer(playerId, out foundUser))
        {
          researchType = Program.Elves.GetTechType(researchedTechId, researchedTechIdCount, out SpawnUnitCommand spawnCommand);

          Program.Elves.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Elves.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Elves.Computer.UpgradeSpawnUnit(spawnCommand);
          }
        }
        else if (Program.Undeads.ContainsPlayer(playerId, out foundUser))
        {
          researchType = Program.Undeads.GetTechType(researchedTechId, researchedTechIdCount, out SpawnUnitCommand spawnCommand);

          Program.Undeads.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);

          if (researchType == Enums.ResearchType.AddUnit)
            Program.Undeads.Computer.AddSpawnUnit(spawnCommand);
          else if (researchType == Enums.ResearchType.UpgradeUnit)
          {
            Program.Undeads.Computer.UpgradeSpawnUnit(spawnCommand);
          }
        }
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Research.OnFinished", ex);
      }
    }
  }
}

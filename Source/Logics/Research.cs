using Source.Abstracts;
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

    internal static void HandleUnitUpgradeBuyed(unit buyingUnit, unit soldUnit, unit sellingUnit, TeamBase team)
    {
      int unitTypeId = soldUnit.UnitType;

      // Gekaufte Einheit sofort entfernen
      Common.RemoveUnit(soldUnit);

      Program.ShowDebugMessage($"Remove unit {unitTypeId} from stock of {sellingUnit.Name}");
      // Gekaufte Upgrade-Item von soldItemTypeId entfernen
      sellingUnit.RemoveUnitFromStock(unitTypeId);

      Program.ShowDebugMessage($"Determince upgrade unit command");
      Enums.UnitUpgradeType upgradeType = team.DetermineTypeOfUnitUpgrade(unitTypeId, out UpgradeUnitCommand command);

      if (upgradeType == Enums.UnitUpgradeType.Unknown)
      {
        Program.ShowErrorMessage("UserHero.HandleUnitUpgradeBuyed", $"No upgrade unit command can determined by unit {soldUnit.Name}!");
        return;
      }

      // Prüfe ob es Nachfolger gibt, wenn ja zu Gebäude hinzufügen
      if (command.NextUnitTypeId > 0)
      {
        Program.ShowDebugMessage($"Add unit {command.NextUnitTypeId} to stock of {sellingUnit.Name}");
        sellingUnit.AddUnitToStock(command.NextUnitTypeId, 1, 1);
      }

      if (!team.Computer.IsOwnerOfBuilding(sellingUnit, out UnitSpawnBuilding building))
      {
        Program.ShowErrorMessage("UserHero.HandleUnitUpgradeBuyed", "Spawn building which sells the item is unknown!");
        return;
      }

      building.UpgradeSpawningUnits(command);
    }
  }
}

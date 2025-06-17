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

    internal static void HandleUpgradeByBuyedItem(unit buyingUnit, item soldItem, unit sellingUnit)
    {
      int soldItemTypeId = soldItem.TypeId;

      Program.ShowDebugMessage($"Remove item {soldItemTypeId} from stock of {sellingUnit.Name}");
      // Gekaufte Upgrade-Item von soldItemTypeId entfernen
      sellingUnit.RemoveItemFromStock(soldItem.TypeId);

      // Prüfe ob es Nachfolger gibt, wenn ja zu Gebäude hinzufügen
      if (TryGetNextStepItem(soldItemTypeId, out int nextItemTypeId))
      {
        Program.ShowDebugMessage($"Add item {nextItemTypeId} to stock of {sellingUnit.Name}");
        sellingUnit.AddItemToStock(nextItemTypeId, 1, 1);
      }

      if (!Program.TryGetTeamByUnit(sellingUnit, out TeamBase team))
      {
        Program.ShowErrorMessage("UserHero.HandleItemBuyed", "Selling unit has no known team!");
        return;
      }

      if (!team.Computer.IsOwnerOfBuilding(sellingUnit, out SpawnUnitsBuilding building))
      {
        Program.ShowErrorMessage("UserHero.HandleItemBuyed", "Spawn building which sells the item is unknown!");
        return;
      }

      Program.ShowDebugMessage($"Get type of upgrade item {soldItemTypeId}");
      Enums.UpgradeUnitByItemType itemType = team.GetUpgradeUnitByItemTypem(soldItemTypeId, out AddOrUpgradeSpawnUnitCommand command);

      if (itemType == Enums.UpgradeUnitByItemType.Unknown)
      {
        Program.ShowErrorMessage("UserHero.HandleItemBuyed", "Item type of sold upgrade item is unknown!");
        return;
      }

      Program.ShowDebugMessage($"Update units by item");
      building.UpgradeSpawningUnits(command);
    }

    private static bool TryGetNextStepItem(int soldItemTypeId, out int nextItemTypeId)
    {
      switch (soldItemTypeId)
      {
        case Constants.ITEM_MELEE_UNIT_LEVEL_2:
          nextItemTypeId = Constants.ITEM_MELEE_UNIT_LEVEL_3;
          break;

        default:
          nextItemTypeId = 0;
          break;
      }

      return nextItemTypeId > 0;
    }
  }
}

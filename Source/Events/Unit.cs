using Source.Extensions;
using Source.Models;
using Source.Models.Teams;
using System;
using WCSharp.Api;

namespace Source.Events
{
  internal static class Unit
  {
    internal static void OnDies()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding)
        {
          // Wenn Gebäude sterben, haben diese wenn überhaupt eigene Trigger
          return;
        }

        if (unit.IsUnitType(unittype.Hero))
        {
          // Wenn Helden sterben, werden diese abhängig vom SlotStatus gesondert behandelt
          if (unit.IsUnitOfUser())
          {
            Logics.UserHero.HandleDied(unit);
          }
          else if (unit.IsUnitOfComputer())
          {
            Logics.ComputerHero.HandleDied(unit);
          }
          else if (unit.IsUnitOfCreep())
          {
            // do nothing :)
            // TODO 001
          }
          else
          {
            Console.WriteLine($"UNKNOWN hero {unit.Name} died!!!");
          }
        }
        else
          Logics.ComputerUnit.HandleDied(unit);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnDies", ex);
      }
    }

    internal static void OnReceivesOrder()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding)
        {
          // Befehle für Gebäude nicht behandeln
          return;
        }

        if (unit.IsHero() && unit.IsUnitOfUser())
        {
          // Befehle für Benutzer-Helden nicht behandeln
          return;
        }

        if (Common.GetUnitTypeId(unit) == Constants.UNIT_DUMMY)
        {
          // Befehle für Dummy-Units nicht behandeln
          return;
        }

        Logics.ComputerUnit.HandleOrderReceived(unit);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnReceivesOrder", ex);
      }
    }

    internal static void OnSpellEffect()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (!unit.IsHero() || !unit.IsUnitOfUser())
          return;

        int abilityId = Common.GetSpellAbilityId();

        switch (abilityId)
        {
          case Constants.ABILITY_CHARM_HERO_10:
            Logics.UserHero.HandleCharmCasted(abilityId);
            break;
        }
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnSpellEffect", ex);
      }
    }

    internal static void OnBuysUnit()
    {
      try
      {
        unit buyingUnit = Common.GetBuyingUnit();
        unit soldUnit = Common.GetSoldUnit();
        unit sellingUnit = Common.GetSellingUnit();

        int sellingUnitTypeId = sellingUnit.UnitType;

        if (sellingUnit.Race == race.Other)
        {
          // Rasse "Andere" wird für neutrale Gebäude (i.d.R. Creep Camps) verwendet
          Program.ShowDebugMessage($"Unit {buyingUnit.Name} buyed a {soldUnit.Name} in camp {sellingUnit.Name}");
          Logics.UserHero.HandleCreepSpawnBuyed(buyingUnit, soldUnit, sellingUnit);
          return;
        }
        else if (sellingUnit.Race == race.Human)
        {
          // Verkauf durch Gebäude der Menschen
          switch (sellingUnitTypeId)
          {
            case Constants.UNIT_BARRACKS_HUMAN:
              Logics.Research.HandleUnitUpgradeBuyed(buyingUnit, soldUnit, sellingUnit, Program.Humans);
              break;

            case Constants.UNIT_CASTLE_HUMAN:
              Logics.ComputerBuilding.HandleSingleSpawnBuyed(buyingUnit, soldUnit, sellingUnit, Program.Humans);
              break;

            default:
              Program.ShowErrorMessage("Unit.OnBuysUnit", $"{sellingUnit.Name} is an unknown human building?!");
              break;
          }
        }
        else if (sellingUnit.Race == race.Orc)
        {
          // Verkauf durch Gebäude der Orks
          switch (sellingUnitTypeId)
          {
            case Constants.UNIT_BARRACKS_ORC:
              Logics.Research.HandleUnitUpgradeBuyed(buyingUnit, soldUnit, sellingUnit, Program.Orcs);
              break;

            case Constants.UNIT_FORTRESS_ORC:
              Logics.ComputerBuilding.HandleSingleSpawnBuyed(buyingUnit, soldUnit, sellingUnit, Program.Orcs);
              break;

            default:
              Program.ShowErrorMessage("Unit.OnBuysUnit", $"{sellingUnit.Name} is an unknown orc building?!");
              break;
          }
        }
        else if (sellingUnit.Race == race.NightElf)
        {
          // Verkauf durch Gebäude der Elfen
          switch (sellingUnitTypeId)
          {
            case Constants.UNIT_HUNTER_S_HALL_ELF:
              Logics.Research.HandleUnitUpgradeBuyed(buyingUnit, soldUnit, sellingUnit, Program.Elves);
              break;

            case Constants.UNIT_TREE_OF_ETERNITY_ELF:
              Logics.ComputerBuilding.HandleSingleSpawnBuyed(buyingUnit, soldUnit, sellingUnit, Program.Elves);
              break;

            default:
              Program.ShowErrorMessage("Unit.OnBuysUnit", $"{sellingUnit.Name} is an unknown elf building?!");
              break;
          }
        }
        else if (sellingUnit.Race == race.Undead)
        {
          // Verkauf durch Gebäude der Untoten
          switch (sellingUnitTypeId)
          {
            case Constants.UNIT_CRYPT_UNDEAD:
              Logics.Research.HandleUnitUpgradeBuyed(buyingUnit, soldUnit, sellingUnit, Program.Undeads);
              break;

            case Constants.UNIT_BLACK_CITADEL_UNDEAD:
              Logics.ComputerBuilding.HandleSingleSpawnBuyed(buyingUnit, soldUnit, sellingUnit, Program.Undeads);
              break;

            default:
              Program.ShowErrorMessage("Unit.OnBuysUnit", $"{sellingUnit.Name} is an unknown undead building?!");
              break;
          }
        }
        else
        {
          Program.ShowErrorMessage("Unit.OnBuysUnit", $"{buyingUnit.Name} buyed an unit {soldUnit.Name} from unknown race?!");
        }
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnBuysUnit", ex);
      }
    }

    internal static void OnSellsItem()
    {
      try
      {
        unit buyingUnit = Common.GetBuyingUnit();

        if (!buyingUnit.IsHero() || !buyingUnit.IsUnitOfUser())
          return;

        item buyedItem = Common.GetSoldItem();
        unit sellingUnit = Common.GetSellingUnit();

        Logics.UserHero.HandleItemBuyed(buyingUnit, buyedItem, sellingUnit);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnSellsItem", ex);
      }
    }

    internal static void OnFinishesResearch()
    {
      try
      {
        unit researchingUnit = Common.GetResearchingUnit();
        int researchedTechId = Common.GetResearched();

        Logics.Research.HandleResearchFinished(researchingUnit, researchedTechId);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnFinishesResearch", ex);
      }
    }
  }
}

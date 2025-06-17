using Source.Abstracts;
using Source.Extensions;
using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events
{
  /// <summary>
  /// Stellt statische Methoden zum Behandeln von Einheiten-Events bereit.
  /// </summary>
  internal static class Unit
  {
    /// <summary>
    /// Behandelt den Tod einer Einheit.
    /// </summary>
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

    /// <summary>
    /// Behandelt den Befehlswechsel einer Einheit.
    /// </summary>
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

    /// <summary>
    /// Behandelt den Zaubervorgang einer Einheit.
    /// </summary>
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

    /// <summary>
    /// Behandelt den Kaufvorgang einer Einheit.
    /// </summary>
    internal static void OnBuysUnit()
    {
      try
      {
        unit buyingUnit = Common.GetBuyingUnit();
        unit soldUnit = Common.GetSoldUnit();
        unit sellingUnit = Common.GetSellingUnit();

        if (sellingUnit.Race == race.Other)
        {
          // Rasse "Andere" wird für neutrale Gebäude (i.d.R. Creep Camps) verwendet
          Program.ShowDebugMessage($"Unit {buyingUnit.Name} buyed a {soldUnit.Name} in camp {sellingUnit.Name}");
          Logics.UserHero.HandleCreepSpawnBuyed(buyingUnit, soldUnit, sellingUnit);
          return;
        }
        else if (sellingUnit.Race == race.Human)
        {
          // Verkauf durch eine Kaserne
          Logics.UserHero.HandleSingleSpawnBuyed(buyingUnit, soldUnit, sellingUnit);
        }


          //if (Common.GetUnitTypeId(buyingUnit) == Constants.UNIT_HEROIC_SOUL_HERO_SELECTOR)
          //{
          //  // Helden-Selector kauft Benutzerhelden
          //  Logics.HeroSelector.HandleHeroBuyed(buyingUnit, soldUnit);
          //  return;
          //}

        //  int sellingUnitTypeId = sellingUnit.UnitType;

        //Console.WriteLine($"Race of selling unit: {sellingUnit.Race}");
        //Console.WriteLine($"Race of human: {race.Human}");
        //Console.WriteLine($"Race of other: {race.Other}");

        //if (sellingUnitTypeId == Constants.UNIT_BANDIT_CAMP_CREEP ||
        //  sellingUnitTypeId == Constants.UNIT_CENTAUR_CAMP_CREEP ||
        //  sellingUnitTypeId == Constants.UNIT_FURBOLG_CAMP_CREEP ||
        //  sellingUnitTypeId == Constants.UNIT_MUR_GUL_CAMP_CREEP ||
        //  sellingUnitTypeId == Constants.UNIT_NERUBIAN_CAMP_CREEP ||
        //  sellingUnitTypeId == Constants.UNIT_OGRE_CAMP_CREEP ||
        //  sellingUnitTypeId == Constants.UNIT_TUSKARR_CAMP_CREEP ||
        //  sellingUnitTypeId == Constants.UNIT_WILDEKIN_CAMP_CREEP)
        //{
        //  // Verkauf durch ein Söldner-Lager

        //  // TODO 001
        //  //if (soldUnit.IsHero())
        //  //  Logics.UserHero.HandleCreepHeroBuyed(buyingUnit, soldUnit, sellingUnit);
        //  //else
          
        //}
        //else if (sellingUnitTypeId == Constants.UNIT_BARRACKS_HUMAN ||
        //  sellingUnitTypeId == Constants.UNIT_BARRACKS_HUMAN ||
        //  sellingUnitTypeId == Constants.UNIT_ANCIENT_OF_WAR_ELF ||
        //  sellingUnitTypeId == Constants.UNIT_CRYPT_UNDEAD)
        //{
      
        //}
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnBuysUnit", ex);
      }
    }

    /// <summary>
    /// Behandelt den Gegenstandskauf einer Einheit.
    /// </summary>
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

    /// <summary>
    /// Behandelt den Forschungsabschluss einer Einheit.
    /// </summary>
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

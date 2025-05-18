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
          // Wenn Gebäude sterben, haben diese wenn überhaupt eigene Trigger - TODO ??
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
          // TODO 001
          //else if (unit.IsUnitOfCreep())
          //{
          //  Logics.CreepHero.HandleDied(unit);
          //}
          else
          {
            Console.WriteLine("UNKNOWN hero died!!!");
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
          case Constants.ABILITY_BEZAUBERUNG_HERO_10:
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

        if (Common.GetUnitTypeId(buyingUnit) == Constants.UNIT_HELDENSEELE_HERO_SELECTOR)
        {
          // Helden-Selector kauft Benutzerhelden
          Logics.HeroSelector.HandleHeroBuyed(buyingUnit, soldUnit);
          return;
        }

        // TODO 001
        //if (soldUnit.IsHero())
        //  Logics.UserHero.HandleCreepHeroBuyed(buyingUnit, soldUnit, sellingUnit);
        //else
        Logics.UserHero.HandleCreepSpawnBuyed(buyingUnit, soldUnit, sellingUnit);
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

        Logics.UserHero.HandleItemBuyed(buyingUnit, buyedItem);
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

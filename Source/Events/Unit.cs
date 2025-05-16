using Source.Extensions;
using Source.Models;
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
          // Wenn Gebäude sterben, haben diese wenn überhaupt eigene Trigger - TODO ??
          return;
        }

        if (unit.IsUnitType(unittype.Hero))
        {
          // Wenn Helden sterben, werden diese abhängig vom SlotStatus gesondert behandelt
          if (unit.Owner.Controller == mapcontrol.User)
            Logics.UserHero.HandleDied(unit);
          else
            Logics.ComputerHero.HandleDied(unit);

          return;
        }

        player owner = unit.Owner;

        // Getötete Einheit von Spieler entfernen
        if (Program.Humans.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
        {
          Program.Humans.Computer.RemoveUnit(spawnedUnit);
        }
        else if (Program.Orcs.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
        {
          Program.Orcs.Computer.RemoveUnit(spawnedUnit);
        }
        else if (Program.Elves.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
        {
          Program.Elves.Computer.RemoveUnit(spawnedUnit);
        }
        else if (Program.Undeads.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
        {
          Program.Undeads.Computer.RemoveUnit(spawnedUnit);
        }
        //else
        //  Bspw. der Tod der Heldenseele bei Kauf löst diesen Fall aus.
        //  Program.ShowDebugMessage("Unit.OnDies", $"Unit {unit.Name} not found in unit lists of computer players!");

        // Verstorbene Einheit nach kurzer Zeit aus Spiel entfernen um RAM zu sparen
        var timer = Common.CreateTimer();
        Common.TimerStart(timer, 10f, false, () =>
        {
          Common.DestroyTimer(timer);
          Common.RemoveUnit(unit);
          // Sicherheitshalber Verweis auf Einheit für GC freigeben
          unit.Dispose();
          unit = null;
        });
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

    internal static void OnBuysUnit()
    {
      try
      {
        unit buyingUnit = Common.GetBuyingUnit();
        unit soldUnit = Common.GetSoldUnit();

        if (Common.GetUnitTypeId(buyingUnit) == Constants.UNIT_HELDENSEELE_HERO_SELECTOR)
        {
          // Helden-Selector kauft Benutzerhelden
          Logics.HeroSelector.HandleHeroBuyed(buyingUnit, soldUnit);
        }

        // TODO : CreepCamps
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

        Logics.UserHero.HandleItemBuyed(buyingUnit, buyedItem);
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

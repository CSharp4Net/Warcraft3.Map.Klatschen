using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Logics
{
  internal static class UserHero
  {
    internal static void HandleDied(unit unit)
    {
      player player = unit.Owner;
      int playerId = unit.Owner.Id;
      Area respawnArea = null;

      if (Program.Humans.ContainsPlayer(playerId, out UserPlayer user))
      {
        respawnArea = Areas.HumanBaseHeroRespawn;
      }
      else if (Program.Orcs.ContainsPlayer(playerId, out user))
      {
        respawnArea = Areas.OrcBaseHeroRespawn;
      }
      else if (Program.Elves.ContainsPlayer(playerId, out user))
      {
        respawnArea = Areas.ElfBaseHeroRespawn;
      }
      else if (Program.Undeads.ContainsPlayer(playerId, out user))
      {
        respawnArea = Areas.UndeadBaseHeroRespawn;
      }
      else
        Program.ShowDebugMessage("UserHero.OnDies", $"Player {player.Name} of hero {unit.Name} not found in teams!");

      if (user == null)
        return;

      // Verstorbenen Held nach gegebener Zeit wieder belegen
      timer timer = Common.CreateTimer();
      // Währenddessen Timer-Dialog anzeigen
      timerdialog timerdialog = timer.CreateDialog();
      timerdialog.SetTitle($"{unit.Name} erscheint erneut...");
      timerdialog.IsDisplayed = true;

      Common.TimerStart(timer, unit.HeroLevel + 2, false, () =>
      {
        try
        {
          // Timer wieder zerstören
          Common.DestroyTimer(timer);
          timer.Dispose();
          timer = null;

          // Timer-Dialog wieder zerstören
          timerdialog.Dispose();
          timerdialog = null;

          Common.ReviveHero(unit, respawnArea.CenterX, respawnArea.CenterY, true);

          user.ApplyCamera(respawnArea);

          Blizzard.SelectUnitForPlayerSingle(unit, unit.Owner);
        }
        catch (Exception ex)
        {
          Program.ShowExceptionMessage("UserHero.OnDies", ex);
        }
      });
    }

    internal static void HandleItemBuyed(unit buyingUnit, item soldItem)
    {
      int itemId = soldItem.TypeId;

      if (itemId == Constants.ITEM_GLYPHE_DER_OPFERUNG)
      {
        int playerId = buyingUnit.Owner.Id;
        if (Program.TryGetUserById(playerId, out UserPlayer user))
        {
          // Merke Heldenstufe
          user.HeroLevelCounter = buyingUnit.HeroLevel;
          // Entferne Käufer/Helden aus Spiel
          Common.RemoveUnit(buyingUnit);

          // Heldenseele erstellen und Kamera verschieben
          Program.CreateHeroSelectorForPlayerAndAdjustCamera(user);
        }
      }
    }

    internal static void HandleCharmCasted(int castedAbilityId)
    {
      try
      {
        // Zauberdefinition
        ability ability = Common.GetSpellAbility();

        // Zaubernde Einheit
        unit castingUnit = Common.GetSpellAbilityUnit();

        // Stufe & Reichweite des Zaubers
        int spellLevel = castingUnit.GetAbilityLevel(castedAbilityId);
        int spellRange = 250 + spellLevel * 50;

        // Ziel & Position des Zauberziels
        unit targetUnit = Common.GetSpellTargetUnit();
        location targetLocation = Common.GetUnitLoc(targetUnit);

        // Alle Einheiten um die Position des Ziels durchlaufen
        group group = Blizzard.GetUnitsInRangeOfLocAll(spellRange, targetLocation);

        int charmedUnits = 0;
        for (int i = group.Count - 1; i >= 0; i--)
        {
          unit groupUnit = group.UnitAtOrDefault(i);

          if (groupUnit.IsABuilding)
            continue;

          if (groupUnit.IsUnitType(unittype.Hero))
            continue;

          // Einheit in Gruppe ist Feind (oder Neutral) der Zaubernden Einheit?
          if (groupUnit.Owner.IsEnemy(castingUnit.Owner) || groupUnit.Owner.Controller == mapcontrol.Creep)
          {
            unit dummyUnit = Common.CreateUnitAtLoc(castingUnit.Owner, Constants.UNIT_DUMMY, targetLocation, 0f);

            dummyUnit.AddAbility(Constants.ABILITY_BEZAUBERUNG_DUMMY);
            dummyUnit.IssueOrder(Constants.ORDER_CHARM, groupUnit);

            // Dummy nach Gebrauch sofort wieder zerstören und freigeben
            Common.RemoveUnit(dummyUnit);
            dummyUnit.Dispose();
            dummyUnit = null;

            charmedUnits++;

            if (charmedUnits >= spellLevel)
              // Wenn die maximale Anzahl erreicht wurde, Schleife abbrechen
              break;
          }
        }

        Common.DestroyGroup(group);
        group.Dispose();
        group = null;
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Ability.HandleCharmCasted", ex);
      }
    }

    private static void HandleAnythingCasted(int castedAbilityId)
    {
      try
      {
        // Zauberdefinition
        ability ability = Common.GetSpellAbility();

        // Zaubernde Einheit
        unit castingUnit = Common.GetSpellAbilityUnit();

        // Stufe des Zaubers
        int spellLevel = castingUnit.GetAbilityLevel(castedAbilityId);
        int spellRange = 100 * spellLevel;
        Program.ShowDebugMessage($"Ability {ability.Name} with level: {spellLevel}");

        // Ziel des Zaubers
        unit targetUnit = Common.GetSpellTargetUnit();

        // Position des Ziels
        location targetLocation = Common.GetUnitLoc(targetUnit);

        // Alle Einheiten um die Position des Ziels durchlaufen
        group group = Blizzard.GetUnitsInRangeOfLocAll(spellRange, targetLocation);

        int charmedUnits = 0;
        for (int i = group.Count - 1; i >= 0; i--)
        {
          if (charmedUnits >= spellLevel)
            // Wenn die maximale Anzahl erreicht wurde, Schleife abbrechen
            break;

          unit groupUnit = group.UnitAtOrDefault(i);

          // Einheit in Gruppe ist Feind der Zaubernden Einheit?
          if (groupUnit.Owner.IsEnemy(castingUnit.Owner))
          {
            // Dummy erstellen
            unit dummyUnit = Common.CreateUnitAtLoc(castingUnit.Owner, Constants.UNIT_DUMMY, targetLocation, 0f);
            dummyUnit.AddAbility(Constants.ABILITY_BEZAUBERUNG_DUMMY);

            // Dummy einen Dummy-Zauber (keine Manakosten) ausführen lassen
            dummyUnit.IssueOrder(Constants.ORDER_CHARM, groupUnit);

            // Effekt erstellen
            effect effect = Common.AddSpecialEffectTarget("Abilities\\Spells\\Other\\Charm\\CharmTarget.mdl", groupUnit, "overhead");

            // Effekte sofort wieder zerstören, um RAM freizugeben
            effect.Dispose();
            effect = null;

            // Dummy sofort wieder zerstören, um RAM freizuegeben
            Program.ShowDebugMessage($"- Destroy dummy");
            dummyUnit.Dispose();
            dummyUnit = null;

            charmedUnits++;
          }
        }

        Common.DestroyGroup(group);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Ability.HandleAnythingCasted", ex);
      }
    }

    internal static void HandleCreepSpawnBuyed(unit buyingUnit, unit soldUnit, unit sellingUnit)
    {
      int soldUnitId = Common.GetUnitTypeId(soldUnit);

      // Gekaufte Einheit sofort entfernen
      Common.RemoveUnit(soldUnit);

      // Sicherheitshalber Verweis auf Einheit für GC freigeben
      soldUnit.Dispose();
      soldUnit = null;

      int playerId = buyingUnit.Owner.Id;

      if (!Program.TryGetCreepCampByBuilding(sellingUnit, out CreepCamp creepCamp))
      {

        Console.WriteLine($"HandleCreepSpawnBuyed, invalid selling creep unit {sellingUnit.Name}!");
        return;
      }

      creepCamp.Building.AddUnitToSpawnTrigger(soldUnitId);
    }

    internal static void HandleCreepHeroBuyed(unit buyingUnit, unit soldUnit, unit sellingUnit)
    {
      int soldUnitId = Common.GetUnitTypeId(soldUnit);

      // Gekaufte Einheit sofort entfernen
      Common.RemoveUnit(soldUnit);

      // Sicherheitshalber Verweis auf Einheit für GC freigeben
      soldUnit.Dispose();
      soldUnit = null;

      int playerId = buyingUnit.Owner.Id;

      if (!Program.TryGetCreepCampByBuilding(sellingUnit, out CreepCamp creepCamp))
      {

        Console.WriteLine($"HandleCreepSpawnBuyed, invalid selling creep unit {sellingUnit.Name}!");
        return;
      }

      if (creepCamp.Hero == null)
        creepCamp.CreateHero(soldUnitId);
      else
        creepCamp.ReviveHero();
    }
  }
}
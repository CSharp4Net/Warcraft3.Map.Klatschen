using System;
using WCSharp.Api;

namespace Source.Events.Generic
{
  internal static class Ability
  {
    public static void OnCasted()
    {
      int abilityId = Common.GetSpellAbilityId();

      switch (abilityId)
      {
        case Constants.ABILITY_BEZAUBERUNG_HERO_10:
          HandleCharmCasted(abilityId);
          break;
      }
    }

    private static void HandleCharmCasted(int abilityId)
    {
      try
      {
        // Zauberdefinition
        ability ability = Common.GetSpellAbility();

        // Zaubernde Einheit
        unit castingUnit = Common.GetSpellAbilityUnit();

        // Stufe & Reichweite des Zaubers
        int spellLevel = castingUnit.GetAbilityLevel(abilityId);
        int spellRange = 250 + (spellLevel * 50);

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

    private static void HandleAnythingCasted(int abilityId)
    {
      try
      {
        // Zauberdefinition
        ability ability = Common.GetSpellAbility();

        // Zaubernde Einheit
        unit castingUnit = Common.GetSpellAbilityUnit();

        // Stufe des Zaubers
        int spellLevel = castingUnit.GetAbilityLevel(abilityId);
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
  }
}
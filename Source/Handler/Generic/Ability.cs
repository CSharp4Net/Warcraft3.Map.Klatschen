using System;
using WCSharp.Api;
using WCSharp.Dummies;

namespace Source.Handler.Generic
{
  internal static class Ability
  {
    public static void OnFinished()
    {
      //  int abilityId = Common.GetSpellAbilityId();

      //  switch (abilityId)
      //  {
      //    case Constants.ABILITY_BEZAUBERUNG_HERO_10:
      //      try
      //      {
      //        // Zauberdefinition
      //        ability ability = Common.GetSpellAbility();
      //        Program.ShowDebugMessage($"ability {ability.Name}");

      //        // Zaubernde Einheit
      //        unit castingUnit = Common.GetSpellAbilityUnit();

      //        // Stufe des Zaubers
      //        int spellLevel = castingUnit.GetAbilityLevel(abilityId);
      //        Program.ShowDebugMessage($"ability level {spellLevel}");

      //        // Ziel des Zaubers
      //        unit targetUnit = Common.GetSpellTargetUnit();

      //        // Position des Ziels
      //        location targetLocation = Common.GetUnitLoc(targetUnit);

      //        // Alle Einheiten um die Position des Ziels durchlaufen
      //        group group = Blizzard.GetUnitsInRangeOfLocAll(300, targetLocation);

      //        for (int i = group.Count - 1; i >= 0; i--)
      //        {
      //          unit groupUnit = group.UnitAtOrDefault(i);
      //          Program.ShowDebugMessage($"unit {i}: {groupUnit.Name}, {groupUnit.Owner}");

      //          // Einheit in Gruppe ist Feind der Zaubernden Einheit?
      //          if (groupUnit.Owner.IsEnemy(castingUnit.Owner))
      //          {

      //            unit dummyUnit = DummySystem.GetDummy(targetLocation.X, targetLocation.Y, 0, castingUnit.Owner); //Common.CreateUnitAtLoc(castingUnit.Owner, Constants.UNIT_DUMMY, targetLocation, 0f);
      //            Program.ShowDebugMessage($"dummy {dummyUnit.Name} created");

      //            dummyUnit.AddAbility(abilityId);
      //            Program.ShowDebugMessage($"dummy ability {abilityId} added");

      //            Program.ShowDebugMessage($"dummy call charm!");
      //            dummyUnit.IssueOrder(Constants.ORDER_CHARM, groupUnit);

      //            DummySystem.RecycleDummy(dummyUnit, 2);
      //            Program.ShowDebugMessage($"dummy recycle");
      //          }
      //        }

      //        Common.DestroyGroup(group);
      //      }
      //      catch (Exception ex)
      //      {
      //        Program.ShowExceptionMessage("Spell.OnFinished", ex);
      //      }

      //      break;
      //  }
    }
  }
}
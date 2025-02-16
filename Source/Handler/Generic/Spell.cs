//using WCSharp.Api;

//namespace Source.Handler.Generic
//{
//  internal static class Spell
//  {
//    public static void OnFinished()
//    {
//      //ability spell = Common.GetSpellAbility();

//      int spellId = Common.GetSpellAbilityId();

//      switch (spellId)
//      {
//        case Constants.ABILITY_TASCHENFABRIK_HERO_5:
//          Program.ShowDebugMessage($"{spellId}");

//          unit unit = Common.GetSpellAbilityUnit();
//          Program.ShowDebugMessage($"{spellId} - unit {unit.Name}");

//          // Zauberdefinition
//          ability ability = Common.GetSpellAbility();
//          Program.ShowDebugMessage($"{spellId} - ability {ability.Name}");

//          // Stufe des Zaubers
//          int spellLevel = unit.GetAbilityLevel(spellId);
//          Program.ShowDebugMessage($"{spellId} - ability level {spellLevel}");

//          // Einheitentyp der erstellten Einheit
//          int unitId = ability.GetFactoryUnitId_Nsyu(spellLevel);
//          Program.ShowDebugMessage($"{spellId} - ability created unit id {unitId}");

//          //unit tUnit = Common.GetSpellTargetUnit();
//          //Program.ShowDebugMessage($"Taschenfabrik {spellId} - unit {tUnit.Name}");
//          break;
//      }
//    }
//  }
//}
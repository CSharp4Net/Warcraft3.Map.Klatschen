using Source.Abstracts;
using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Logics
{
  internal static class ComputerHero
  {
    internal static void HandleDied(unit unit)
    {
      int playerId = unit.Owner.Id;
      int respawnTime = 0;

      // Prüfe vor Wiedergeburt-Einleitung, ob der Computer-Spieler noch unbesiegt ist
      if (Program.TryGetTeamByUnit(unit, out TeamBase team))
      {
        if (team.Computer.Defeated)
          return;
      }

      respawnTime = 30;

      // Verstorbenen Held nach gegebener Zeit wieder belegen
      timer timer = Common.CreateTimer();

      Common.TimerStart(timer, respawnTime, false, () =>
      {
        try
        {
          // Timer wieder zerstören
          Common.DestroyTimer(timer);
          timer.Dispose();
          timer = null;

          // Prüfe vor Wiedergeburt-Abschluss, ob der Computer-Spieler noch unbesiegt ist
          if (Program.TryGetTeamByUnit(unit, out TeamBase team))
          {
            if (team.Computer.Defeated)
              return;
          }

          Area respawnArea = null;

          if (team.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
          {
            respawnArea = spawnedUnit.SpawnArea;
            Common.ReviveHero(unit, respawnArea.CenterX, respawnArea.CenterY, true);

            // Computer-Helden starten stets mit vollem Mana
            unit.Mana = unit.MaxMana;

            spawnedUnit.RepeatAttackMove();
          }
        }
        catch (Exception ex)
        {
          Program.ShowExceptionMessage("ComputerHero.OnDies", ex);
        }
      });
    }

    internal static void HandleLeveled(unit unit)
    {   
      int unitId = Common.GetUnitTypeId(unit);

      //ability ability0 = unit.GetAbilityByIndex(0);
      //ability ability1 = unit.GetAbilityByIndex(1);
      //ability ability2 = unit.GetAbilityByIndex(2);
      //ability ability3 = unit.GetAbilityByIndex(3);
      //ability ability4 = unit.GetAbilityByIndex(4);
      //ability ability5 = unit.GetAbilityByIndex(5);
      //ability ability6 = unit.GetAbilityByIndex(6);
      //ability ability7 = unit.GetAbilityByIndex(7);
      //ability ability8 = unit.GetAbilityByIndex(8);
      //ability ability9 = unit.GetAbilityByIndex(9);

      //Console.WriteLine($"Unit: {unit.HeroName} ({unit.Name}) {unit.HeroLevel}");
      //Console.WriteLine($"Abiltity 0: {ability0} = {ability0.Name}, {ability0.HeroAbility}");
      //Console.WriteLine($"Abiltity 1: {ability1} = {ability1.Name}, {ability1.HeroAbility}");
      //Console.WriteLine($"Abiltity 2: {ability2} = {ability2.Name}, {ability2.HeroAbility}");
      //Console.WriteLine($"Abiltity 3: {ability3} = {ability3.Name}, {ability3.HeroAbility}");
      //Console.WriteLine($"Abiltity 4: {ability4} = {ability4.Name}, {ability4.HeroAbility}");
      //Console.WriteLine($"Abiltity 5: {ability5} = {ability5.Name}, {ability5.HeroAbility}");
      //Console.WriteLine($"Abiltity 6: {ability6} = {ability6.Name}, {ability6.HeroAbility}");
      //Console.WriteLine($"Abiltity 7: {ability7} = {ability7.Name}, {ability7.HeroAbility}");
      //Console.WriteLine($"Abiltity 8: {ability8} = {ability8.Name}, {ability8.HeroAbility}");
      //Console.WriteLine($"Abiltity 9: {ability9} = {ability9.Name}, {ability9.HeroAbility}");

      if (unitId == Constants.UNIT_W_CHTER_HUMAN || unitId == Constants.UNIT_W_CHTER_ORC || 
        unitId == Constants.UNIT_W_CHTER_ELF || unitId == Constants.UNIT_W_CHTER_UNDEAD)
      {
        ProcessWaechterLevelUp(unit);
      }
    }

    private static void ProcessWaechterLevelUp(unit unit)
    {
      string level = unit.HeroLevel.ToString();
      int abilityId = 0;

      if (level.EndsWith("1") || level.EndsWith("6"))
      {
        abilityId = Constants.ABILITY_SPOTT_GUARD_20;
      }
      else if (level.EndsWith("2") || level.EndsWith("7"))
      {
        abilityId = Constants.ABILITY_BEFEHLSAURA_GUARD_20;
      }
      else if (level.EndsWith("3") || level.EndsWith("8"))
      {
        abilityId = Constants.ABILITY_DONNERSCHLAG_GUARD_20;
      }
      else if (level.EndsWith("4") || level.EndsWith("9"))
      {
        abilityId = Constants.ABILITY_AUSDAUERAURA_GUARD_20;
      }
      else // 5 oder 0
      {
        abilityId = Constants.ABILITY_ERH_HTE_ATTRIBUTE_HERO_50;
      }

      ability ability = unit.GetAbility(abilityId);
      if (ability.Id == 0)
      {
        // Held hat Fähigkeit noch nicht gelernt
        unit.AddAbility(abilityId);
      }
      else
      {
        // Skill kann verbessert werden
        int abilityLevel = unit.IncrementAbilityLevel(abilityId);
      }
    }
  }
}
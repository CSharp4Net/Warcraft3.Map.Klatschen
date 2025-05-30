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

      if (team == null)
      {
        // Helden neutrale Spieler (Legion) nicht automatisch wieder beleben
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

      if (unitId == Constants.UNIT_GUARDIAN_HUMAN || unitId == Constants.UNIT_GUARDIAN_ORC || 
        unitId == Constants.UNIT_GUARDIAN_ELF || unitId == Constants.UNIT_GUARDIAN_UNDEAD)
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
        abilityId = Constants.ABILITY_TAUNT_GUARD_20;
      }
      else if (level.EndsWith("2") || level.EndsWith("7"))
      {
        abilityId = Constants.ABILITY_COMMAND_AURA_GUARD_20;
      }
      else if (level.EndsWith("3") || level.EndsWith("8"))
      {
        abilityId = Constants.ABILITY_THUNDER_CLAP_GUARD_20;
      }
      else if (level.EndsWith("4") || level.EndsWith("9"))
      {
        abilityId = Constants.ABILITY_ENDURANCE_AURA_GUARD_20;
      }
      else // 5 oder 0
      {
        abilityId = Constants.ABILITY_ATTRIBUTE_BONUS_HERO_50;
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
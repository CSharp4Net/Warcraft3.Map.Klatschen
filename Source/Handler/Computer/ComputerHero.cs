using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Handler.Computer
{
  internal static class ComputerHero
  {
    internal static void OnDies(unit unit)
    {
      int playerId = unit.Owner.Id;

      // TODO : Verstorbener PC-Hero wird nicht automatisch wieder geboren, sondern muss gekauft werden!

      // Prüfe vor Wiedergeburt, ob der Computer-Spieler noch unbesiegt ist
      if (playerId == Program.Humans.Computer.PlayerId)
      {
        if (Program.Humans.Computer.Defeated)
          return;
      }
      else if (playerId == Program.Orcs.Computer.PlayerId)
      {
        if (Program.Orcs.Computer.Defeated)
          return;
      }
      else if (playerId == Program.Elves.Computer.PlayerId)
      {
        if (Program.Elves.Computer.Defeated)
          return;
      }
      else if (playerId == Program.Undeads.Computer.PlayerId)
      {
        if (Program.Undeads.Computer.Defeated)
          return;
      }

      // TODO
      //if (playerId == Program.HumanCreepToElf.Wc3Player.Id)
      //{
      //   unit killingUnit = Common.GetKillingUnit();
      //}

      // Verstorbenen Held nach gegebener Zeit wieder belegen
      timer timer = Common.CreateTimer();

      Common.TimerStart(timer, unit.HeroLevel + 2, false, () =>
      {
        try
        {
          // Timer wieder zerstören
          Common.DestroyTimer(timer);
          timer.Dispose();
          timer = null;

          // Prüfe vor Wiedergeburt, ob der Computer-Spieler noch unbesiegt ist
          if (playerId == Program.Humans.Computer.PlayerId)
          {
            if (Program.Humans.Computer.Defeated)
              return;
          }
          else if (playerId == Program.Orcs.Computer.PlayerId)
          {
            if (Program.Orcs.Computer.Defeated)
              return;
          }
          else if (playerId == Program.Elves.Computer.PlayerId)
          {
            if (Program.Elves.Computer.Defeated)
              return;
          }
          else if (playerId == Program.Undeads.Computer.PlayerId)
          {
            if (Program.Undeads.Computer.Defeated)
              return;
          }

          player owner = unit.Owner;
          Area respawnArea = null;

          if (Program.Humans.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
          {
            respawnArea = Areas.HumanBaseHeroRespawn;
          }
          else if (Program.Orcs.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            respawnArea = Areas.OrcBaseHeroRespawn;
          }
          else if (Program.Elves.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            respawnArea = Areas.ElfBaseHeroRespawn;
          }
          else if (Program.Undeads.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            respawnArea = Areas.UndeadBaseHeroRespawn;
          }

          if (spawnedUnit != null)
          {
            Common.ReviveHero(unit, respawnArea.CenterX, respawnArea.CenterY, true);
            spawnedUnit.RepeatAttackMove();
          }
        }
        catch (Exception ex)
        {
          Program.ShowExceptionMessage("ComputerHero.OnDies", ex);
        }
      });
    }

    internal static void OnLevels()
    {
      unit unit = Common.GetLevelingUnit();

      if (unit.Owner.Controller != mapcontrol.Computer)
        return;

      int unitId = Common.GetUnitTypeId(unit);

      if (unitId == Constants.UNIT_W_CHTER_HUMAN)
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
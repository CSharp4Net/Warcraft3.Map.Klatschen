using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events.Computer
{
  internal static class ComputerHero
  {
    internal static void OnDies(unit unit)
    {
      int playerId = unit.Owner.Id;
      int respawnTime = 0;

      // TODO : Verstorbener PC-Hero wird nicht automatisch wieder geboren, sondern muss gekauft werden!

      // Prüfe vor Wiedergeburt, ob der Computer-Spieler noch unbesiegt ist
      if (playerId == Program.Humans.Computer.PlayerId)
      {
        if (Program.Humans.Computer.Defeated)
          return;
        else
          respawnTime = 30;
      }
      else if (playerId == Program.Orcs.Computer.PlayerId)
      {
        if (Program.Orcs.Computer.Defeated)
          return;
        else
          respawnTime = 30;
      }
      else if (playerId == Program.Elves.Computer.PlayerId)
      {
        if (Program.Elves.Computer.Defeated)
          return;
        else
          respawnTime = 30;
      }
      else if (playerId == Program.Undeads.Computer.PlayerId)
      {
        if (Program.Undeads.Computer.Defeated)
          return;
        else
          respawnTime = 30;
      }
      else if (playerId == player.NeutralAggressiveId)
      {
        int unitType = Common.GetUnitTypeId(unit);

        foreach (CreepFragtion fragtion in Program.Creeps)
        {
          // Prüfe primär die Einheit-Id, da ein UNIT-Vergleich nicht empfohlen wird!
          if (fragtion.Hero.UnitType == unitType && fragtion.Hero == unit)
          {
            Program.ShowDebugMessage("Creep hero killed!");
            break;
          }
        }
      }

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
            respawnArea = spawnedUnit.SpawnArea;
          }
          else if (Program.Orcs.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            respawnArea = spawnedUnit.SpawnArea;
          }
          else if (Program.Elves.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            respawnArea = spawnedUnit.SpawnArea;
          }
          else if (Program.Undeads.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            respawnArea = spawnedUnit.SpawnArea;
          }

          if (spawnedUnit != null)
          {
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
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

      //if (Common.GetUnitTypeId(unit) == Constants.UNIT_W_CHTER_HUMAN)
      //{
      //  switch (unit.HeroLevel)
      //  {
      //    case 6:
      //      unit.AddAbility()
      //      break;
      //    case 12:

      //      break;
      //    case 18:

      //      break;
      //    case 24:

      //      break;
      //  }
      //}

      int randomIndex = Common.GetRandomInt(1, 5);
      ability ability = unit.Hero(randomIndex);
      int abilityId = ability.Id;
      int abilityLevel = unit.GetAbilityLevel(abilityId);

      // TODO : Level des Helden und Skill-Level-Skip beachten?
      if (abilityLevel == 0)
      {
        unit.AddAbility(abilityId);
        Program.ShowDebugMessage($"Heldenfähigkeiten {ability.Name} gelernt!");
      }
      else if (abilityLevel < ability.Levels)
      {
        // Skill kann verbessert werden
        unit.IncrementAbilityLevel(abilityId);
        Program.ShowDebugMessage($"Heldenfähigkeiten {ability.Name} verbessert!");
      }
    }
  }
}
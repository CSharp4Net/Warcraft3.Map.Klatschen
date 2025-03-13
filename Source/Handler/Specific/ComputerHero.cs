using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Handler.Specific
{
  internal static class ComputerHero
  {
    internal static void OnDies(unit unit)
    {
      if (unit.Owner.SlotState == playerslotstate.Left) // TODO TEST
        return;

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
          else
            Program.ShowDebugMessage("ComputerHero.OnDies", $"Unit {unit.Name} not found unit list of computer players!");

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
  }
}
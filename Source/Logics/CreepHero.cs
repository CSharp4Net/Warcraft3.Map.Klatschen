using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Logics
{
  internal static class CreepHero
  {
    internal static void HandleDied(unit unit)
    {
      int playerId = unit.Owner.Id;
      int respawnTime = 0;

      // Prüfe vor Wiedergeburt-Einleitung, ob der Computer-Spieler noch unbesiegt ist
      if (!Program.TryGetCreepCampByHero(unit, out CreepCamp creepCamp))
      {
        Program.ShowErrorMessage("CreepHero.HandleDied", $"Creep camp of unit {unit.Name} not found!");
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
          if (!Program.TryGetCreepCampByHero(unit, out CreepCamp creepCamp))
          {
            Program.ShowErrorMessage("CreepHero.HandleDied", $"Creep camp of unit {unit.Name} not found!");
            return;
          }

          unit.SetOwner(creepCamp.OwnerTeam.Computer.Wc3Player);

          creepCamp.ReviveHero();
        }
        catch (Exception ex)
        {
          Program.ShowExceptionMessage("ComputerHero.OnDies", ex);
        }
      });
    }
  }
}
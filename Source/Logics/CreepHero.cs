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

      Program.ShowDebugMessage("Start creep hero timer!"); // TODO : Code prüfen!
      Common.TimerStart(timer, respawnTime, false, () =>
      {
        try
        {
          // Timer wieder zerstören
          Common.DestroyTimer(timer);
          timer.Dispose();
          timer = null;

          Program.ShowDebugMessage("Detect creep hcampt of hero!"); // TODO : Code prüfen!
          // Prüfe vor Wiedergeburt-Abschluss, ob der Computer-Spieler noch unbesiegt ist
          if (!Program.TryGetCreepCampByHero(unit, out CreepCamp creepCamp))
          {
            Program.ShowErrorMessage("CreepHero.HandleDied", $"Creep camp of unit {unit.Name} not found!");
            return;
          }

          Program.ShowDebugMessage($"Set creep hero owner to {creepCamp.Name}!"); // TODO : Code prüfen!
          unit.SetOwner(creepCamp.OwnerTeam.Computer.Wc3Player);

          Program.ShowDebugMessage($"Revive creep hero for {creepCamp.OwnerTeam.Computer.Wc3Player.Name}!"); // TODO : Code prüfen!
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
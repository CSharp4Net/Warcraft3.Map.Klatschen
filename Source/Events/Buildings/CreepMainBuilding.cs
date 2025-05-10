using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events.Buildings
{
  internal static class CreepMainBuilding
  {
    internal static void OnDies()
    {
      try
      {
        Program.ShowDebugMessage("BuildingCreep.OnDies");

        unit unit = Common.GetTriggerUnit();
        unit killingUnit = Common.GetKillingUnit();
        player player = killingUnit.Owner;

        if (!Program.TryGetActiveUser(player.Id, out UserPlayer user))
          return;

        Program.ShowDebugMessage(player.Name + " has killed the creep building!");

        int unitType = unit.UnitType;
        CreepCamp creepCamp = null;

        // Suche CreepCamp, zudem das zerstörte Gebäude gehört
        foreach (CreepCamp camp in Program.CreepCamps)
        {
          if (camp.Building.Wc3Unit == unit)
          {
            creepCamp = camp;
            break;
          }
        }

        if (creepCamp == null)
          return;

        Program.ShowDebugMessage(creepCamp.Wc3Player.Name + " has lost creep building!");
        int rebuildTime = 30;

        // Stoppe Trigger
        creepCamp.Building.Destroy();

        // Verstorbenen Held nach gegebener Zeit wieder belegen
        timer timer = Common.CreateTimer();
        // Währenddessen Timer-Dialog anzeigen
        timerdialog timerdialog = timer.CreateDialog();
        timerdialog.SetTitle($"{creepCamp.Name} wurde besiegt...");
        timerdialog.IsDisplayed = true;

        Common.TimerStart(timer, rebuildTime, false, () =>
        {
          try
          {
            // Timer wieder zerstören
            Common.DestroyTimer(timer);
            timer.Dispose();
            timer = null;

            // Timer-Dialog wieder zerstören
            timerdialog.Dispose();
            timerdialog = null;

            // Prüfe vor Übernahme, ob der Computer-Spieler noch unbesiegt ist
            if (user.Team.Computer.Defeated)
              return;

            Program.ShowDebugMessage(user.Team.Computer.Wc3Player.Name + " takes the ownership!");
            creepCamp.SetOwnerAndRebuild(user.Team.Computer.Wc3Player);

            Program.ShowDebugMessage(user.Team.Computer.Wc3Player.Name + " start spawning in 15 seconds!");
            creepCamp.Building.AddSpawnTrigger(creepCamp.SpawnArea, Enums.UnitClass.Meelee, 15f, Areas.Center,
               Constants.UNIT_BLAUDRACHE_SUPPORT)
              .Run();
          }
          catch (Exception ex)
          {
            Program.ShowExceptionMessage("BuildingCreep.OnDies", ex);
          }
        });
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("BuildingCreep.OnDies", ex);
      }
    }
  }
}
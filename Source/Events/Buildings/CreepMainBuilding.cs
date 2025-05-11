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
        unit unit = Common.GetTriggerUnit();
        unit killingUnit = Common.GetKillingUnit();
        player player = killingUnit.Owner;

        if (!Program.TryGetActiveUser(player.Id, out UserPlayer user))
          return;

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

        int rebuildTime = 15;

        // Stoppe Trigger
        creepCamp.Building.Destroy();

        // Verstorbenen Held nach gegebener Zeit wieder belegen
        timer timer = Common.CreateTimer();
        // Währenddessen Timer-Dialog anzeigen
        timerdialog timerdialog = timer.CreateDialog();
        timerdialog.SetTitle($"{creepCamp.Name} wurden besiegt und schließen sich {user.Team.Computer.Wc3Player.Name} an!");
        timerdialog.IsDisplayed = true;

        ComputerPlayer newOwningPlayer = user.Team.Computer;

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
            if (newOwningPlayer.Defeated)
              return;

            creepCamp.SetOwnerAndRebuild(user.Team.Computer.Wc3Player);

            Area attackTargetArea;

            // Ist der neue Eigentümer die nahe Streitmacht, ist das Ziel die Streitmacht am anderen Ende
            // der Lane - alternativ ist es die nahe Streitmacht.
            if (newOwningPlayer.PlayerId == creepCamp.NearestForce.PlayerId)
              attackTargetArea = creepCamp.OpposingForce.Team.TeamBaseArea;
            else
              attackTargetArea = user.Team.TeamBaseArea;

            creepCamp.Building.AddSpawnTrigger(creepCamp.SpawnArea, Enums.UnitClass.Meelee, 15f, attackTargetArea, 
              Constants.UNIT_NAHKAMPFEINHEIT_CREEP, Constants.UNIT_FERNKAMPFEINHEIT_CREEP).Run();
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
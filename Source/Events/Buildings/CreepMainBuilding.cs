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
        unit buildingUnit = Common.GetTriggerUnit();
        unit killingUnit = Common.GetKillingUnit();

        player player = killingUnit.Owner;

        if (!Program.TryGetUserById(player.Id, out UserPlayer user))
          return;

        int unitType = buildingUnit.UnitType;

        // Suche CreepCamp, zudem das zerstörte Gebäude gehört
        if (!Program.TryGetCreepCampByBuilding(buildingUnit, out CreepCamp creepCamp))
        {
          Program.ShowErrorMessage("CreepMainBuilding.OnDies", $"Creep camp of creep building {buildingUnit.Name} not found!");
          return;
        }

        int rebuildTime = 10;

        // Stoppe Trigger
        creepCamp.Building.Destroy();

        // Verstorbenen Held nach gegebener Zeit wieder belegen
        timer timer = Common.CreateTimer();

        ComputerPlayer newOwningPlayer = user.Team.Computer;

        Console.WriteLine($"Die {creepCamp.ColorizedName} wurden besiegt und schließen sich der {user.Team.ColorizedName} an!");
        Common.TimerStart(timer, rebuildTime, false, () =>
        {
          try
          {
            // Timer wieder zerstören
            Common.DestroyTimer(timer);
            timer.Dispose();
            timer = null;

            // Prüfe vor Übernahme, ob der Computer-Spieler noch unbesiegt ist
            if (newOwningPlayer.Defeated)
              return;

            Area attackTargetArea;

            // Ist der neue Eigentümer das Team im gleichen Quadranten, ist das Ziel das Team am anderen Ende
            // der Lane, ansonsten alternativ ist es das Team im gleichen Quadrant.
            if (newOwningPlayer.PlayerId == creepCamp.NearTeam.Computer.PlayerId)
            {
              attackTargetArea = creepCamp.OpposingTeam.TeamBaseArea;
            }
            else
            {
              attackTargetArea = creepCamp.NearTeam.TeamBaseArea;
            }

            creepCamp.SetOwnerAndRebuild(user.Team, attackTargetArea);
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
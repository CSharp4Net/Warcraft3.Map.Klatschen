using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events.Buildings
{
  internal static class MercenaryBuilding
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
        if (!Program.TryGetCreepCampByBuilding(buildingUnit, out MercenaryForce creepCamp))
        {
          Program.ShowErrorMessage("MercenaryMainBuilding.OnDies", $"Creep camp of creep building {buildingUnit.Name} not found!");
          return;
        }

        int rebuildTime = 5;

        // Stoppe Trigger
        creepCamp.Building.Destroy();

        // Falls Verteidiger noch am Leben, dann töte diese
        for (int i = creepCamp.DefenderCreeps.Count - 1; i >= 0; i--)
        {
          creepCamp.DefenderCreeps[i].Kill();
        }
        creepCamp.DefenderCreeps.Clear();

        // Verstorbenen Held nach gegebener Zeit wieder belegen
        timer timer = Common.CreateTimer();

        ComputerPlayer newOwningPlayer = user.Team.Computer;

        Console.WriteLine($"Die {creepCamp.ColorizedName} wurden besiegt und schließen sich der {user.Team.ColorizedName} an!");
        Common.TimerStart(timer, rebuildTime, false, () =>
        {
          try
          {
            Program.ShowDebugMessage($"Init rebuilding of building of {creepCamp.ColorizedName}");
            // Timer wieder zerstören
            Common.DestroyTimer(timer);
            timer.Dispose();
            timer = null;

            // Prüfe vor Übernahme, ob der Computer-Spieler noch unbesiegt ist
            if (newOwningPlayer.Defeated)
              return;

            Area attackTargetArea;

            Program.ShowDebugMessage($"Detect attack target of building of {creepCamp.ColorizedName}");
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

            Program.ShowDebugMessage($"Set owner and rebuild building of {creepCamp.ColorizedName}");
            creepCamp.SetOwnerAndRebuild(user.Team, attackTargetArea);
          }
          catch (Exception ex)
          {
            Program.ShowExceptionMessage("MercenaryMainBuilding.OnDies", ex);
          }
        });
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("MercenaryMainBuilding.OnDies", ex);
      }
    }
  }
}
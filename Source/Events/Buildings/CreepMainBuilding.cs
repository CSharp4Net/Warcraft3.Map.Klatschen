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
        timerdialog.SetTitle($"{creepCamp.Name} unterstützt nun {user.Team.Computer.Wc3Player.Name}...");
        timerdialog.IsDisplayed = true;

        Common.TimerStart(timer, rebuildTime, false, () =>
        {
          try
          {
            // Timer wieder zerstören
            Common.DestroyTimer(timer);
            timer.Dispose();
            timer = null;

            // Prüfe vor Übernahme, ob der Computer-Spieler noch unbesiegt ist

            if (user.Team.Computer.Defeated)
              return;

            creepCamp.SetOwner(user.Team.Computer.Wc3Player);

            creepCamp.InitializeBuilding(Constants.UNIT_BANDITENZELT_CREEP);
            creepCamp.CreateOrReviveHero()


            throw new NotImplementedException("TODO");
          }
          catch (Exception ex)
          {
            Program.ShowExceptionMessage("ComputerHero.OnDies", ex);
          }
        });

        //if (Program.Humans.Computer.IsOwnerOfBuilding(unit, out SpawnBuilding building))
        //{
        //  building.Destroy();
        //  Console.WriteLine("Die Menschen haben eine ihrer Kasernen verloren!");
        //  Program.Humans.Computer.RemoveBuilding(building);
        //}
        //else if (Program.Orcs.Computer.IsOwnerOfBuilding(unit, out building))
        //{
        //  building.Destroy();
        //  Console.WriteLine("Die Orks haben eine ihrer Kasernen verloren!");
        //  Program.Orcs.Computer.RemoveBuilding(building);
        //}
        //else if (Program.Elves.Computer.IsOwnerOfBuilding(unit, out building))
        //{
        //  building.Destroy();
        //  Console.WriteLine("Die Elfen haben eine ihrer Kasernen verloren!");
        //  Program.Elves.Computer.RemoveBuilding(building);
        //}
        //else if (Program.Undeads.Computer.IsOwnerOfBuilding(unit, out building))
        //{
        //  building.Destroy();
        //  Console.WriteLine("Die Elfen haben eine ihrer Kasernen verloren!");
        //  Program.Elves.Computer.RemoveBuilding(building);
        //}
        //else if (unit.Owner == player.NeutralAggressive)
        //{
        //  building.Destroy();

        //}

        //if (building != null)
        // building.Destroy();
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("BuildingCreep.OnDies", ex);
      }
    }
  }
}
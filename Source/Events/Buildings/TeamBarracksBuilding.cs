using Source.Abstracts;
using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events.Buildings
{
  internal static class TeamBarracksBuilding
  {
    internal static void OnDies()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (!Program.TryUnitTeam(unit, out TeamBase team))
        {
          Program.ShowErrorMessage("BarracksBuilding.OnDies", $"Building {unit.Name} not found in building lists of teams!");
          return;
        }

        if (!team.Computer.IsOwnerOfBuilding(unit, out SpawnUnitsBuilding building))
        {
          Program.ShowErrorMessage("BarracksBuilding.OnDies", $"Building {unit.Name} not found in building lists of computer player {team.Computer.Wc3Player.Name}!");
          return;
        }

        building.Destroy();
        Console.WriteLine($"Die {team.ColorizedName} hat einen ihrer Vorposten verloren!");
        Program.Humans.Computer.RemoveBuilding(building);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("BarracksBuilding.OnDies", ex);
      }
    }
  }
}
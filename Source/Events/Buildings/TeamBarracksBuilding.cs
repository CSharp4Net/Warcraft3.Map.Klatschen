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

        if (!Program.TryGetTeamByUnit(unit, out TeamBase team))
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
        Console.WriteLine($"{team.ColorizedName} has lost one of its outposts!");
        Program.Humans.Computer.RemoveBuilding(building);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("TeamBarracksBuilding.OnDies", ex);
      }
    }
  }
}
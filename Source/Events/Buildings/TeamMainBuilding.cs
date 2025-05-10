using System;
using WCSharp.Api;

namespace Source.Events.Buildings
{
  internal static class TeamMainBuilding
  {
    internal static void OnDies()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        int playerId = unit.Owner.Id;

        // Besiege alle Spieler im Team des Hauptgebäudes
        if (playerId == Program.Humans.Computer.PlayerId)
        {
          Program.Humans.Defeat();
        }
        else if (playerId == Program.Orcs.Computer.PlayerId)
        {
          Program.Orcs.Defeat();
        }
        else if (playerId == Program.Elves.Computer.PlayerId)
        {
          Program.Elves.Defeat();
        }
        else if (playerId == Program.Undeads.Computer.PlayerId)
        {
          Program.Undeads.Defeat();
        }
        else
          Program.ShowDebugMessage("MainBuilding.OnDies", $"Unit of building {unit.Name} not found in computer players!");

        // Ist nur noch ein Team übrig, gewinnen alle Spieler im Team
        if (Program.Elves.Defeated && Program.Orcs.Defeated && Program.Undeads.Defeated)
        {
          Program.Humans.Win();
        }
        else if (Program.Humans.Defeated && Program.Elves.Defeated && Program.Undeads.Defeated)
        {
          Program.Orcs.Win();
        }
        else if (Program.Orcs.Defeated && Program.Humans.Defeated && Program.Undeads.Defeated)
        {
          Program.Elves.Win();
        }
        else if (Program.Orcs.Defeated && Program.Elves.Defeated && Program.Humans.Defeated)
        {
          Program.Undeads.Win();
        }
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("MainBuilding.OnDies", ex);
      }
    }
  }
}

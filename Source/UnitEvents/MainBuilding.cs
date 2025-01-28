using System;
using WCSharp.Api;

namespace Source.UnitEvents
{
  internal static class MainBuilding
  {
    internal static void OnDies()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        // Besiege alle Spieler im Team des Hauptgebäudes
        if (unit.Owner.Id == Program.Humans.Computer.Wc3Player.Id)
        {
          Program.Humans.Defeat();
        }
        else if (unit.Owner.Id == Program.Orcs.Computer.Wc3Player.Id)
        {
          Program.Orcs.Defeat();
        }
        else if (unit.Owner.Id == Program.Elves.Computer.Wc3Player.Id)
        {
          Program.Elves.Defeat();
        }
        else if (unit.Owner.Id == Program.Undeads.Computer.Wc3Player.Id)
        {
          Program.Undeads.Defeat();
        }

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
        Program.ShowDebugMessage("MainBuilding.OnDies", ex.ToString());
      }
    }
  }
}

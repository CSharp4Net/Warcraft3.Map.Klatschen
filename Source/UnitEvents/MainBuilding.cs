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

        // Ist nur noch ein Team übrig, gewinnen alle Spieler im Team
        if (Program.Humans.Defeated && Program.Orcs.Defeated)
        {
          Program.Elves.Win();
        }
        else if (Program.Humans.Defeated && Program.Elves.Defeated)
        {
          Program.Orcs.Win();
        }
        else if (Program.Orcs.Defeated && Program.Elves.Defeated)
        {
          Program.Humans.Win();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

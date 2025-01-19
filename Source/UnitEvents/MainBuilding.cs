using System;
using WCSharp.Api;

namespace Source.UnitEvents
{
  internal static class MainBuilding
  {
    internal static void OnDies()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.Owner.Id == Program.Humans.Computer.Player.Id)
      {
        Program.Humans.Defeat();
      }
      else if (unit.Owner.Id == Program.Orcs.Computer.Player.Id)
      {
        Program.Orcs.Defeat();
      }
      else if (unit.Owner.Id == Program.Elves.Computer.Player.Id)
      {
        Program.Elves.Defeat();
      }

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
  }
}

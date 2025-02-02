using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.Handler.Region
{
  internal static class HumanBase
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (unit.Owner.Id == Program.Orcs.Computer.Wc3Player.Id)
      {
        if (!Program.Elves.Defeated)
        {
          unit.AttackMove(Areas.ElfBase);
        }
        else
        {
          unit.AttackMove(Areas.UndeadBase);
        }
      }
      else if (unit.Owner.Id == Program.Undeads.Computer.Wc3Player.Id)
      {
        if (!Program.Elves.Defeated)
        {
          unit.AttackMove(Areas.ElfBase);
        }
        else
        {
          unit.AttackMove(Areas.OrcBase);
        }
      }
      else if (unit.Owner.Id == Program.Elves.Computer.Wc3Player.Id)
      {
        if (!Program.Orcs.Defeated)
        {
          unit.AttackMove(Areas.OrcBase);
        }
        else
        {
          unit.AttackMove(Areas.UndeadBase);
        }
      }
    }
  }
}

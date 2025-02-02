using Source.Extensions;
using WCSharp.Api;

namespace Source.Handler.Region
{
  internal static class ElfBase
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis eines anderen Spielers schicken
      if (unit.Owner.Id == Program.Humans.Computer.Wc3Player.Id)
      {
        if (Program.Undeads.Defeated)
        {
          unit.AttackMove(Areas.UndeadBase);
        }
        else
        {
          unit.AttackMove(Areas.OrcBase);
        }
      }
      else if (unit.Owner.Id == Program.Orcs.Computer.Wc3Player.Id)
      {
        if (!Program.Undeads.Defeated)
        {
          unit.AttackMove(Areas.UndeadBase);
        }
        else
        {
          unit.AttackMove(Areas.HumanBase);
        }
      }
      else if (unit.Owner.Id == Program.Undeads.Computer.Wc3Player.Id)
      {
        if (!Program.Humans.Defeated)
        {
          unit.AttackMove(Areas.HumanBase);
        }
        else
        {
          unit.AttackMove(Areas.OrcBase);
        }
      }
    }
  }
}

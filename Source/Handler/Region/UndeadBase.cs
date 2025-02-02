using Source.Extensions;
using WCSharp.Api;

namespace Source.Handler.Region
{
  internal static class UndeadBase
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (unit.Owner.Id == Program.Humans.Computer.Wc3Player.Id)
      {
        if (!Program.Orcs.Defeated)
        {
          unit.AttackMove(Areas.OrcBase);
        }
        else
        {
          unit.AttackMove(Areas.ElfBase);
        }
      }
      else if (unit.Owner.Id == Program.Orcs.Computer.Wc3Player.Id)
      {
        if (!Program.Humans.Defeated)
        {
          unit.AttackMove(Areas.HumanBase);
        }
        else
        {
          unit.AttackMove(Areas.ElfBase);
        }
      }
      else if (unit.Owner.Id == Program.Elves.Computer.Wc3Player.Id)
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

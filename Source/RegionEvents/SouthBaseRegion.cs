using Source.Extensions;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class SouthBaseRegion
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (unit.Owner.Id == Program.Humans.Computer.Wc3Player.Id)
      {
        unit.AttackMove(Regions.EastBase);
      }
      else if (unit.Owner.Id == Program.Orcs.Computer.Wc3Player.Id)
      {
        unit.AttackMove(Regions.WestBase);
      }
    }
  }
}

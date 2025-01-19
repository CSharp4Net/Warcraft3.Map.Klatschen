using Source.Extensions;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class EastBaseRegion
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (unit.Owner.Id == Program.Humans.Computer.Player.Id)
      {
        unit.AttackMove(Regions.SouthBase);
      }
      else if (unit.Owner.Id == Program.Elves.Computer.Player.Id)
      {
        unit.AttackMove(Regions.WestBase);
      }
    }
  }
}

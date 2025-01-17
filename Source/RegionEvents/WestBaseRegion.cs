using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class WestBaseRegion
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();
      player player = Common.GetOwningPlayer(unit);

      if (player.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (player.Id == Program.EasternForces.Id)
      {
        unit.AttackMove(Regions.SouthBase);
      }
      else if (player.Id == Program.SouthernForces.Id)
      {
        unit.AttackMove(Regions.EastBase);
      }
    }
  }
}

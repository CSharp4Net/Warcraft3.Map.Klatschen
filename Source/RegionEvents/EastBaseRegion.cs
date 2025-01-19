using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class EastBaseRegion
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();
      player player = Common.GetOwningPlayer(unit);

      if (player.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (player.Id == Program.HumanTeam.Computer.Player.Id)
      {
        unit.AttackMove(Regions.SouthBase);
      }
      else if (player.Id == Program.SouthernForces.Computer.Player.Id)
      {
        unit.AttackMove(Regions.WestBase);
      }
    }
  }
}

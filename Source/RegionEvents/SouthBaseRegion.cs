using Source.Extensions;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class SouthBaseRegion
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
        unit.AttackMove(Regions.EastBase);
      }
      else if (player.Id == Program.EasternForces.Computer.Player.Id)
      {
        unit.AttackMove(Regions.WestBase);
      }
    }
  }
}

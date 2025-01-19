using Source.Extensions;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class CenterRegion
  {
    private static bool lastTargetOfWesternUnitWasClockwise;
    private static bool lastTargetOfEasternUnitWasClockwise;
    private static bool lastTargetOfSouthernUnitWasClockwise;

    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();
      player player = Common.GetOwningPlayer(unit);

      if (player.Controller != mapcontrol.Computer)
        return;

      // Computer-Einheit im Uhrzeigersinn oder entgegen gesetzt weiter schicken
      if (player.Id == Program.HumanTeam.Computer.Player.Id)
      {
        if (lastTargetOfWesternUnitWasClockwise)
          unit.AttackMove(Regions.SouthBase);
        else
          unit.AttackMove(Regions.EastBase);

        lastTargetOfWesternUnitWasClockwise = !lastTargetOfWesternUnitWasClockwise;
      }
      else if (player.Id == Program.EasternForces.Computer.Player.Id)
      {
        if (lastTargetOfEasternUnitWasClockwise)
          unit.AttackMove(Regions.WestBase);
        else
          unit.AttackMove(Regions.SouthBase);

        lastTargetOfEasternUnitWasClockwise = !lastTargetOfEasternUnitWasClockwise;
      }
      else // SouthernForces
      {
        if (lastTargetOfSouthernUnitWasClockwise)
          unit.AttackMove(Regions.WestBase);
        else
          unit.AttackMove(Regions.EastBase);

        lastTargetOfSouthernUnitWasClockwise = !lastTargetOfSouthernUnitWasClockwise;
      }
    }
  }
}

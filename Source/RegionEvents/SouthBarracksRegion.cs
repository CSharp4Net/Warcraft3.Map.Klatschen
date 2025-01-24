using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class SouthBarracksRegions
  {
    internal static void OnEnter()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
          return;

        // Feindliche Einheit zur Basis des Computer-Spielers schicken
        if (unit.Owner.Id != Program.Elves.Computer.Wc3Player.Id)
        {
          unit.AttackMove(Regions.SouthBase);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

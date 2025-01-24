using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class OrcSpawnToUndead
  {
    internal static void OnEnter()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
          return;

        // Feindliche Einheit zur Basis des anderen Spielers schicken
        if (unit.Owner.Id == Program.Orcs.Computer.Wc3Player.Id)
        {
          unit.AttackMove(Regions.UndeadBase);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

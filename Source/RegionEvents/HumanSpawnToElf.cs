using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.RegionEvents
{
  internal static class HumanSpawnToElf
  {
    internal static void OnEnter()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
          return;

        // Feindliche Einheit zur Basis des anderen Spielers schicken
        if (unit.Owner.Id == Program.Humans.Computer.Wc3Player.Id)
        {
          unit.AttackMove(Regions.ElfBase);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

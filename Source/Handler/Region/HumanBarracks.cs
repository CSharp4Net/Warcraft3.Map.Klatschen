using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.Handler.Region
{
  internal static class HumanBarracksRegions
  {
    internal static void OnEnter()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
          return;

        // Feindliche Einheit zur Basis des Computer-Spielers schicken
        if (!Program.Humans.Defeated && unit.Owner.Id != Program.Humans.Computer.Wc3Player.Id)
        {
          unit.AttackMove(Areas.HumanBase);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

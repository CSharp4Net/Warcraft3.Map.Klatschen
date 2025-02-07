//using Source.Extensions;
//using System;
//using WCSharp.Api;

//namespace Source.Handler.Region
//{
//  internal static class OrcBarracks
//  {
//    internal static void OnEnter()
//    {
//      try
//      {
//        unit unit = Common.GetTriggerUnit();

//        if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
//          return;

//        // Feindliche Einheit zur Basis des Computer-Spielers schicken
//        if (!Program.Orcs.Defeated && unit.Owner.Id != Program.Orcs.Computer.Wc3Player.Id)
//        {
//          unit.AttackMove(Areas.OrcBase);
//        }
//      }
//      catch (Exception ex)
//      {
//        Console.WriteLine(ex.Message);
//      }
//    }
//  }
//}
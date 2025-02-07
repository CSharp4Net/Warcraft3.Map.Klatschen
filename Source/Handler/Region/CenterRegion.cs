//using Source.Extensions;
//using WCSharp.Api;

//namespace Source.Handler.Region
//{
//  internal static class CenterRegion
//  {
//    internal static void OnEnter()
//    {
//      unit unit = Common.GetTriggerUnit();

//      if (unit.Owner.Controller != mapcontrol.Computer)
//        return;

//      // Computer-Einheit im Uhrzeigersinn oder entgegen gesetzt weiter schicken
//      if (unit.Owner.Id == Program.Humans.Computer.Wc3Player.Id)
//      {
//        if (!Program.Orcs.Defeated)
//        {
//          unit.AttackMove(Areas.OrcBase);
//        }
//        else if (!Program.Elves.Defeated)
//        {
//          unit.AttackMove(Areas.ElfBase);
//        }
//        else
//        {
//          unit.AttackMove(Areas.UndeadBase);
//        }
//      }
//      else if (unit.Owner.Id == Program.Orcs.Computer.Wc3Player.Id)
//      {
//        if (!Program.Undeads.Defeated)
//        {
//          unit.AttackMove(Areas.UndeadBase);
//        }
//        else if (!Program.Humans.Defeated)
//        {
//          unit.AttackMove(Areas.HumanBase);
//        }
//        else
//        {
//          unit.AttackMove(Areas.ElfBase);
//        }
//      }
//      else if (unit.Owner.Id == Program.Undeads.Computer.Wc3Player.Id)
//      {
//        if (!Program.Elves.Defeated)
//        {
//          unit.AttackMove(Areas.ElfBase);
//        }
//        else if (!Program.Orcs.Defeated)
//        {
//          unit.AttackMove(Areas.OrcBase);
//        }
//        else
//        {
//          unit.AttackMove(Areas.HumanBase);
//        }
//      }
//      else // Elves
//      {
//        if (!Program.Humans.Defeated)
//        {
//          unit.AttackMove(Areas.HumanBase);
//        }
//        else if (!Program.Undeads.Defeated)
//        {
//          unit.AttackMove(Areas.UndeadBase);
//        }
//        else
//        {
//          unit.AttackMove(Areas.OrcBase);
//        }
//      }
//    }
//  }
//}

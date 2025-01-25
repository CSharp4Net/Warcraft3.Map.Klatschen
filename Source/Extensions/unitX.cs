using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Extensions
{
  internal static class unitX
  {
    internal static void AttackMove(this unit unit, Area targetArea)
    {
      unit.IssueOrder(Constants.ORDER_ATTACK, targetArea.Wc3Rectangle.Center.X, targetArea.Wc3Rectangle.Center.Y);
    }

    internal static void RegisterOnDies(this unit unit, Action eventHandler)
    {
      trigger trigger = trigger.Create();
      trigger.RegisterUnitEvent(unit, unitevent.Death);
      trigger.AddAction(eventHandler);
    }
  }
}

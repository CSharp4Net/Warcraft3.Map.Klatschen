using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Extensions
{
  internal static class unitX
  {
    internal static void AttackMove(this unit unit, Rectangle region)
    {
      unit.IssueOrder(Constants.ORDER_ATTACK, region.Center.X, region.Center.Y);
    }

    internal static void RegisterOnDies(this unit unit, Action eventHandler)
    {
      trigger trigger = trigger.Create();
      trigger.RegisterUnitEvent(unit, unitevent.Death);
      trigger.AddAction(eventHandler);
    }
  }
}

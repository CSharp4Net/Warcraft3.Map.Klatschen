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
  }
}

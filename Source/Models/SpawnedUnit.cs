using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnedUnit
  {
    public SpawnedUnit(PlayerBase owner, int unitTypeId, Area area, float face = 0f)
    {
      Owner = owner;
      Wc3Unit = Common.CreateUnitAtLoc(owner.Wc3Player, unitTypeId, area.Wc3CenterLocation, face);
    }

    public PlayerBase Owner { get; init; }

    public int Wc3UnitTypeId { get; init; }
    public unit Wc3Unit { get; init; }

    public Area LastAreaTarget { get; private set; }

    public void AttackMove(Area targetArea)
    {
      LastAreaTarget = targetArea;

      Wc3Unit.IssueOrder(Constants.ORDER_ATTACK, LastAreaTarget.Wc3Rectangle.Center.X, LastAreaTarget.Wc3Rectangle.Center.Y);
    }

    public void RepeatAttackMove()
    {
      if (LastAreaTarget != null)
      {
        Wc3Unit.IssueOrder(Constants.ORDER_ATTACK, LastAreaTarget.Wc3Rectangle.Center.X, LastAreaTarget.Wc3Rectangle.Center.Y);
      }
    }

    public void Kill()
    {
      if (Wc3Unit.Alive)
        Wc3Unit.Kill();
    }
  }
}

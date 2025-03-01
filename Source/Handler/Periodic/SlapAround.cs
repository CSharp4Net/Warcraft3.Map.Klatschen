using System;
using WCSharp.Api;
using WCSharp.Dummies;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace Source.Handler.Periodic
{
  internal static class SlapAround
  {
    public static bool OnElapsed()
    {
      try
      {
        player player = player.NeutralAggressive;

        Program.ShowDebugMessage("Create dummy for NeutralAggressive");
        unit dummyUnit = Common.CreateUnitAtLoc(player, Constants.UNIT_DUMMY, Areas.Center.Wc3CenterLocation, 0f);

        Program.ShowDebugMessage("Train spells");
        dummyUnit.AddAbility(Constants.ABILITY_MONSUN_DUMMY);
        dummyUnit.AddAbility(Constants.ABILITY_CHAOSREGEN_DUMMY);

        DummySystem.RecycleDummy(dummyUnit, 4f);

        Rectangle rectangle = Areas.CenterComplete.Wc3Rectangle;

        for (int i = 0; i < 10; i++)
        {
          Point point = rectangle.GetRandomPoint();

          effect e = Common.AddSpecialEffect("Units\\Demon\\Infernal\\InfernalBirth.mdl", point.X, point.Y);
          EffectSystem.Add(e);
        }

        //Program.ShowDebugMessage("Cast monsoon");
        //dummyUnit.IssueOrder(Constants.ORDER_MONSOON, dummyUnit);

        //var timer = Common.CreateTimer();
        //Common.TimerStart(timer, 5f, false, () =>
        //{
        //  try
        //  {
        //    dummyUnit.IssueOrder(Constants.ORDER_RAIN_OF_CHAOS, dummyUnit);
        //  }
        //  catch (Exception ex)
        //  {
        //    Program.ShowExceptionMessage("SlapAround.OnElapsed-Inner", ex);
        //  }
        //});
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("SlapAround.OnElapsed", ex);
      }

      return true;
    }
  }
}
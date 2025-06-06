using System;
using WCSharp.Api;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace Source.Statics
{
  internal static class SpecialEffects
  {
    internal static void CreateSpecialEffect(string modelPath, Point point, float scale, float duration = 0.03125f)
      => CreateSpecialEffect(modelPath, point.X, point.Y, scale, duration);
    internal static void CreateSpecialEffect(string modelPath, float x, float y, float scale, float duration = 0.03125f)
    {
      effect e = Common.AddSpecialEffect(modelPath, x, y);
      e.Scale = scale;
      EffectSystem.Add(e, duration);
    }

    internal static void CreateSpecialEffectTimed(string modelPath, Point point, float scale, float delay, float duration = 0.03125f)
    {
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        CreateSpecialEffect(modelPath, point, scale, duration);
      });
    }

    internal static void CreateLightning(Point caster, Point target)
    {
      // https://www.hiveworkshop.com/threads/beginners-guide-to-lightning-effects.220370/#herp
      var lightning = Common.AddLightningEx("AFOD", true, caster.X, caster.Y, 50, target.X, target.Y, 50);

      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, 1f, true, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        try
        {
          Common.DestroyLightning(lightning);
          lightning.Dispose();
          lightning = null;
        }
        catch (Exception ex)
        {
          Program.ShowExceptionMessage("SpecialEffects.CreateLightning", ex);
        }
      });
    }
  }
}

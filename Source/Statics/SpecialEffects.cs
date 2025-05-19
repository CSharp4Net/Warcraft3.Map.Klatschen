using WCSharp.Api;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace Source.Statics
{
  internal static class SpecialEffects
  {
    internal static void CreateSpecialEffect(string modelPath, Point point, float scale, float duration = 0.03125f)
    {
      effect e = Common.AddSpecialEffect(modelPath, point.X, point.Y);
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

  }
}

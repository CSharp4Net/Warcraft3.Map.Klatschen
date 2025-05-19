using WCSharp.Api;

namespace Source.Extensions
{
  internal static class timerExtension
  {
    internal static void Destroy(this timer timer)
    {
      Common.DestroyTimer(timer);

      timer.Dispose();
      timer = null;
    }
  }
}
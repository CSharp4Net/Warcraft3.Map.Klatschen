using System;
using WCSharp.Api;

namespace Source.Extensions
{
  internal static class regionX
  {
    internal static void RegisterOnEnter(this region region, Action eventHandler)
    {
      trigger trigger = trigger.Create();
      trigger.RegisterEnterRegion(region);
      trigger.AddAction(eventHandler);
    }
  }
}

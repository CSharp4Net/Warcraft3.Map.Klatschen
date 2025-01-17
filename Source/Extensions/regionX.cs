using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using WCSharp.Shared.Data;

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

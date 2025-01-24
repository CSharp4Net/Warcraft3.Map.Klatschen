using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class Area
  {
    public Area(Rectangle wc3Rectangle)
    {
      Wc3Rectangle = wc3Rectangle;
      Wc3CenterLocation = Common.Location(wc3Rectangle.Center.X, wc3Rectangle.Center.Y);
    }

    public Rectangle Wc3Rectangle { get; init; }
    public region Wc3Region => Wc3Rectangle.Region;
    public location Wc3CenterLocation { get; init; }

    public void RegisterOnEnter(Action eventHandler)
    {
      trigger trigger = trigger.Create();
      trigger.RegisterEnterRegion(Wc3Region);
      trigger.AddAction(eventHandler);
    }
  }
}

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
      CenterX = wc3Rectangle.Center.X;
      CenterY = wc3Rectangle.Center.Y;
      Wc3CenterLocation = Common.Location(CenterX, CenterY);
    }

    public Rectangle Wc3Rectangle { get; init; }
    public region Wc3Region => Wc3Rectangle.Region;
    public location Wc3CenterLocation { get; init; }

    public float CenterX { get; set; }
    public float CenterY { get; set; }

    public void RegisterOnEnter(Action eventHandler)
    {
      trigger trigger = trigger.Create();
      trigger.RegisterEnterRegion(Wc3Region);
      trigger.AddAction(eventHandler);
    }

    public new string ToString()
    {
      return $"[{CenterX}:{CenterY}]";
    }
  }
}

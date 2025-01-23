using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class Area
  {
    public Area(Rectangle rectangle)
    {
      Rectangle = rectangle;
      CenterLocation = Common.Location(rectangle.Center.X, rectangle.Center.Y);
    }

    public Rectangle Rectangle { get; init; }
    public region Region => Rectangle.Region;
    public location CenterLocation { get; init; }

    public void RegisterOnEnter(Action eventHandler)
    {
      trigger trigger = trigger.Create();
      trigger.RegisterEnterRegion(Region);
      trigger.AddAction(eventHandler);
    }
  }
}

using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class Pentagram
  {
    public Pentagram(Point center, float size)
    {
      float centerX = center.X;
      float centerY = center.Y - 100;

      PointBottom = new Point(centerX, centerY - (90f * size));
      PointTopLeft = new Point(centerX - (60f * size), centerY + (75f * size));
      PointTopRight = new Point(centerX + (60f * size), centerY + (75f * size));
      PointLeft = new Point(centerX - (90f * size), centerY - (30f * size));
      PointRight = new Point(centerX + (90f * size), centerY - (30f * size));
    }

    public Point PointBottom { get; set; }
    public Point PointTopLeft { get; set; }
    public Point PointTopRight { get; set; }
    public Point PointLeft { get; set; }
    public Point PointRight { get; set; }

    public void CreateLightning()
    {
      Statics.SpecialEffects.CreateLightning(PointBottom, PointTopLeft);
      Statics.SpecialEffects.CreateLightning(PointTopLeft, PointRight);
      Statics.SpecialEffects.CreateLightning(PointRight, PointLeft);
      Statics.SpecialEffects.CreateLightning(PointLeft, PointTopRight);
      Statics.SpecialEffects.CreateLightning(PointTopRight, PointBottom);
    }
  }
}
using Source.Models;

namespace Source
{
  internal static class Areas
  {
    public static Area EastBase { get; set; } = new Area(Regions.EastBase);
    public static Area EastSpawnBottom { get; set; } = new  Area(Regions.EastSpawnBottom);
    public static Area EastSpawnMiddle { get; set; } = new Area(Regions.EastSpawnMiddle);
    public static Area EastSpawnTop { get; set; } = new Area(Regions.EastSpawnTop);
    public static Area SouthBase { get; set; } = new Area(Regions.SouthBase);
    public static Area SouthSpawnLeft { get; set; } = new Area(Regions.SouthSpawnLeft);
    public static Area SouthSpawnMiddle { get; set; } = new  Area(Regions.SouthSpawnMiddle);
    public static Area SouthSpawnRight { get; set; } = new Area(Regions.SouthSpawnRight);
    public static Area WestBase { get; set; } = new Area(Regions.WestBase);
    public static Area WestSpawnBottom { get; set; } = new  Area(Regions.WestSpawnBottom);
    public static Area WestSpawnMiddle { get; set; } = new Area(Regions.WestSpawnMiddle);
    public static Area WestSpawnTop { get; set; } = new Area(Regions.WestSpawnTop);
    public static Area Center { get; set; } = new Area(Regions.Center);
  }
}
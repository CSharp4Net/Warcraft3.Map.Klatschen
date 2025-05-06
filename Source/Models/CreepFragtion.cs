using Source.Abstracts;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class CreepFragtion : FragtionBase
  {
    public CreepFragtion(Area campCenter, Area campSpawnArea)
      : base(player.NeutralAggressive)
    {
      Center = campCenter;
      SpawnArea = campSpawnArea;
    }

    public Area Center { get; set; }
    public Area SpawnArea { get; set; }

    public void CreateOrReviveHero(int unitTypeId)
    {
      CreateOrReviveHero(unitTypeId, Center, Hero.HeroLevel, 0f);
    }

    public void SpawnUnitInAreaAtRandomPoint(int unitTypeId)
    {
      Point point = SpawnArea.Wc3Rectangle.GetRandomPoint();

      unit.Create(Wc3Player, unitTypeId, point.X, point.Y);
    }
  }
}
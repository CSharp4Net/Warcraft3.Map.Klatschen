using Source.Abstracts;
using Source.Events.Buildings;
using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class CreepCamp : NeutralForce
  {
    public CreepCamp(string campName, Area campBuilding, Area campCenter, Area campSpawnArea)
      : base(player.NeutralAggressive)
    {
      Name = campName;
      Center = campCenter;
      SpawnArea = campSpawnArea;
      BuildingArea = campBuilding;
    }

    public string Name { get; private set; }
    public Area Center { get; private set; }
    public Area SpawnArea { get; private set; }
    public Area BuildingArea { get; private set; }

    public SpawnBuilding Building { get; private set; }

    public void CreateOrReviveHero(int unitTypeId)
    {
      CreateOrReviveHero(unitTypeId, Center, Hero.HeroLevel, 0f);
    }

    public void SpawnUnitInAreaAtRandomPoint(int unitTypeId)
    {
      Point point = SpawnArea.Wc3Rectangle.GetRandomPoint();

      unit.Create(Wc3Player, unitTypeId, point.X, point.Y);
    }

    public SpawnBuilding InitializeBuilding(int unitTypeId, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      Building = new SpawnBuilding(this, unitTypeId, BuildingArea, face);
      Building.RegisterOnDies(CreepMainBuilding.OnDies);

      return Building;
    }

    public void SetOwner(player wc3Player)
    {
      Wc3Player = wc3Player;
    }
  }
}
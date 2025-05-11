using Source.Abstracts;
using Source.Events.Buildings;
using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class CreepCamp : NeutralForce
  {
    public CreepCamp(string campName, Area campBuilding, Area campCenter, Area campSpawnArea, ComputerPlayer nearestForce, ComputerPlayer opposingForce)
      : base(player.NeutralAggressive)
    {
      Name = campName;
      Center = campCenter;
      SpawnArea = campSpawnArea;
      BuildingArea = campBuilding;
      NearestForce = nearestForce;
      OpposingForce = opposingForce;
    }

    public string Name { get; init; }

    public Area Center { get; init; }
    public Area SpawnArea { get; init; }
    public Area BuildingArea { get; init; }

    public ComputerPlayer NearestForce { get; init; }
    public ComputerPlayer OpposingForce { get; init; }

    public SpawnCreepsBuilding Building { get; private set; }

    public void InitializeHero(int unitTypeId, float face = 0f)
    {
      CreateOrReviveHero(unitTypeId, Center, Hero.HeroLevel, face);
    }

    public SpawnCreepsBuilding InitializeBuilding(int unitTypeId, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      Building = new SpawnCreepsBuilding(this, unitTypeId, BuildingArea, face);
      Building.RegisterOnDies(CreepMainBuilding.OnDies);

      return Building;
    }

    public void ReviveHero()
    {
      CreateOrReviveHero(Hero.UnitType, Center, Hero.HeroLevel, 0f);
    }

    public SpawnedCreep SpawnUnitInAreaAtRandomPoint(int unitTypeId)
    {
      Point point = SpawnArea.Wc3Rectangle.GetRandomPoint();

      return new SpawnedCreep(this, unitTypeId, SpawnArea);
    }

    public void SetOwnerAndRebuild(player wc3Player)
    {
      Wc3Player = wc3Player;

      // Ort anhand Zentrum einer Region erstellen
      Building = new SpawnCreepsBuilding(this, Building.Wc3Unit.UnitType, BuildingArea, 0f);
      Building.RegisterOnDies(CreepMainBuilding.OnDies);
    }
  }
}
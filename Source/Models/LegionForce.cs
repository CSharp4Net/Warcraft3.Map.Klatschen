using Source.Abstracts;
using Source.Events.Buildings;
using Source.Statics;
using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class LegionForce
  {
    public LegionForce(string name)
    {
      Name = name;
      ColorizedName = $"|cffff0000{name}|r";
      Wc3Player = Common.Player(20);
    }

    public LegionSpawnBuilding SpawnBuildingWest { get; set; }
    public LegionSpawnBuilding SpawnBuildingEast { get; set; }

    /// <summary>
    /// Name des Söldnerlagers mit Farberweiterung.
    /// </summary>
    public string ColorizedName { get; init; }
    /// <summary>
    /// Name des Söldnerlagers, welcher in Nachrichten angezeigt wird.
    /// </summary>
    public string Name { get; init; }

    public SpawnedCreep Hero { get; private set; }

    public player Wc3Player { get; init; }

    public void CreateOrReviveHero(int unitTypeId, Area spawnArea, int heroLevel, float face = 0f, Area targetArea = null)
    {

      unit unit = null;

      if (Hero == null)
      {
        SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", spawnArea.Wc3Rectangle.Center, 2f, 3f);
        Hero = CreateHero(unitTypeId, spawnArea.Wc3Rectangle.Center, heroLevel, face);
        unit = Hero.Wc3Unit;

        AddAbilitiesToHero(unitTypeId, unit);
      }
      else
      {
        unit = Hero.Wc3Unit;

        if (!unit.Alive)
        {
          SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", spawnArea.Wc3Rectangle.Center, 2f, 3f);
          Point point = spawnArea.Wc3Rectangle.Center;
          Common.ReviveHero(unit, point.X, point.Y, true);

          if (targetArea != null)
            Hero.AttackMove(targetArea);
        }
        else
        {
          SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", unit.X, unit.Y, 2f, 3f);
          unit.Life = unit.MaxLife;
        }
      }

      unit.HeroLevel = heroLevel;
      unit.Mana = unit.MaxMana;

      TrainHero(unitTypeId, unit, heroLevel);
    }

    internal void CreateOrRefreshEastSpawnBuilding()
    {
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", Areas.MiddleLaneSpawnEast.Wc3Rectangle.Center, 4f, 3f);

      if (SpawnBuildingEast == null || !SpawnBuildingEast.Wc3Unit.Alive)
      {
        SpawnBuildingEast = new LegionSpawnBuilding(Constants.UNIT_DEMON_SHRINE_LEGION, Areas.MiddleLaneSpawnEast, 180f);
        SpawnBuildingEast.RegisterOnDies(LegionBuilding.OnDies);

        SpawnBuildingEast.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnEast, Areas.CenterRight).Run();
        SpawnBuildingEast.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnEast, Areas.Center).Run();
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_FELGUARD_LEGION);
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_MAIDEN_OF_PAIN_LEGION);
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_VILE_TORMENTOR_LEGION);
      }
      else
      {
        SpawnBuildingEast.Wc3Unit.Life = SpawnBuildingEast.Wc3Unit.MaxLife;
      }
    }

    internal void CreateOrRefreshWestSpawnBuilding()
    {
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", Areas.MiddleLaneSpawnWest.Wc3Rectangle.Center, 4f, 3f);

      if (SpawnBuildingWest == null || !SpawnBuildingWest.Wc3Unit.Alive)
      {
        SpawnBuildingWest = new LegionSpawnBuilding(Constants.UNIT_DEMON_SHRINE_LEGION, Areas.MiddleLaneSpawnWest);
        SpawnBuildingWest.RegisterOnDies(LegionBuilding.OnDies);

        SpawnBuildingWest.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnWest, Areas.CenterLeft).Run();
        SpawnBuildingWest.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnWest, Areas.Center).Run();
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_FELGUARD_LEGION);
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_MAIDEN_OF_PAIN_LEGION);
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_VILE_TORMENTOR_LEGION);
      }
      else
      {
        SpawnBuildingWest.Wc3Unit.Life = SpawnBuildingWest.Wc3Unit.MaxLife;
      }
    }

    private void AddAbilitiesToHero(int unitTypeId, unit unit)
    {
      switch (unitTypeId)
      {
        case Constants.UNIT_DEMON_LORD_LEGION:
          unit.AddAbility(Constants.ABILITY_RAIN_OF_FIRE_LEGION_100);
          unit.AddAbility(Constants.ABILITY_CLEAVING_ATTACK_LEGION_100);
          unit.AddAbility(Constants.ABILITY_FINGER_OF_DEATH_LEGION_100);
          unit.AddAbility(Constants.ABILITY_UNHOLY_AURA_LEGION_100);
          unit.AddAbility(Constants.ABILITY_ATTRIBUTE_BONUS_LEGION_100);
          break;

        default:
          throw new NotImplementedException($"Abilities for hero {unit.Name} (Id {unitTypeId}) not implemented yet!");
      }
    }

    private void TrainHero(int unitTypeId, unit unit, int heroLevel)
    {
      switch (unitTypeId)
      {
        case Constants.UNIT_DEMON_LORD_LEGION:
          unit.SetAbilityLevel(Constants.ABILITY_RAIN_OF_FIRE_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_CLEAVING_ATTACK_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_FINGER_OF_DEATH_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_UNHOLY_AURA_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_ATTRIBUTE_BONUS_LEGION_100, heroLevel);
          break;

        default:
          throw new NotImplementedException($"Abilities for hero {unit.Name} (Id {unitTypeId}) not implemented yet!");
      }
    }

    private SpawnedCreep CreateHero(int unitTypeId, Point point, int heroLevel, float face = 0f)
    {
      SpawnedCreep result = new SpawnedCreep(Wc3Player, unitTypeId, point, face);
      result.Wc3Unit.HeroLevel = heroLevel;
      return result;
    }

    internal SpawnedCreep SpawnUnitAtPoint(Point point, int unitTypeId)
    {
      return new SpawnedCreep(Wc3Player, unitTypeId, point);
    }
  }
}
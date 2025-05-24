using Source.Abstracts;
using Source.Events.Buildings;
using Source.Statics;
using System;
using System.Xml.Linq;
using WCSharp.Api;
using WCSharp.Shared.Extensions;

namespace Source.Models
{
  public sealed class LegionForce : NeutralForce
  {
    public LegionForce(string name) : base(player.NeutralAggressive)
    {
      Name = name;
      ColorizedName = $"|cffff0000{name}|r";
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

    public void CreateOrReviveHero(int unitTypeId, Area spawnArea, int heroLevel, float face = 0f, Area targetArea = null)
    {
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", spawnArea.Wc3Rectangle.Center, 2f, 3f);

      unit unit = null;

      if (Hero == null)
      {
        Program.ShowDebugMessage("Create legion hero");
        Hero = CreateHero(unitTypeId, spawnArea, heroLevel, face);
        unit = Hero.Wc3Unit;

        Program.ShowDebugMessage("Learn legion hero");
        AddAbilitiesToHero(unitTypeId, unit);
      }
      else
      {
        unit = Hero.Wc3Unit;

        if (!unit.Alive)
        {
          Program.ShowDebugMessage("Revive legion hero");
          Hero.ReviveHero();

          if (targetArea != null)
            Hero.AttackMove(targetArea);
        }
        else if (unit.HeroLevel < heroLevel)
        {
          Program.ShowDebugMessage("Power up legion hero");
          unit.Life = unit.MaxLife;
        }
      }

      unit.HeroLevel = heroLevel;
      unit.Mana = unit.MaxMana;

      Program.ShowDebugMessage($"Train legion hero to level {heroLevel}");
      TrainHero(unitTypeId, unit, heroLevel);
    }

    internal void CreateOrRefreshEastSpawnBuilding()
    {
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", Areas.MiddleLaneSpawnEast.Wc3Rectangle.Center, 4f, 3f);

      if (SpawnBuildingEast == null || !SpawnBuildingEast.Wc3Unit.Alive)
      {
        SpawnBuildingEast = new LegionSpawnBuilding(Constants.UNIT_D_MONENSCHREIN_LEGION, Areas.MiddleLaneSpawnEast, 180f);
        SpawnBuildingEast.RegisterOnDies(LegionBuilding.OnDies);

        SpawnBuildingEast.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnEast, Areas.CenterRight).Run();
        SpawnBuildingEast.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnEast, Areas.Center).Run();
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_TEUFELSWACHE_LEGION);
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_MAID_DES_SCHMERZES_LEGION);
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_SCH_NDLICHER_FOLTERKNECHT_LEGION);
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
        SpawnBuildingWest = new LegionSpawnBuilding(Constants.UNIT_D_MONENSCHREIN_LEGION, Areas.MiddleLaneSpawnWest);
        SpawnBuildingWest.RegisterOnDies(LegionBuilding.OnDies);

        SpawnBuildingWest.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnWest, Areas.CenterLeft).Run();
        SpawnBuildingWest.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnWest, Areas.Center).Run();
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_TEUFELSWACHE_LEGION);
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_MAID_DES_SCHMERZES_LEGION);
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_SCH_NDLICHER_FOLTERKNECHT_LEGION);
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
        case Constants.UNIT_D_MONENF_RST_LEGION:
          unit.AddAbility(Constants.ABILITY_FEUERREGEN_LEGION_100);
          unit.AddAbility(Constants.ABILITY_SPALTSCHLAG_LEGION_100);
          unit.AddAbility(Constants.ABILITY_TODESFINGER_LEGION_100);
          unit.AddAbility(Constants.ABILITY_UNHEILIGE_AURA_LEGION_100);
          unit.AddAbility(Constants.ABILITY_ERH_HTE_ATTRIBUTE_LEGION_100);
          break;

        default:
          throw new NotImplementedException($"Abilities for hero {unit.Name} (Id {unitTypeId}) not implemented yet!");
      }
    }

    private void TrainHero(int unitTypeId, unit unit, int heroLevel)
    {
      switch (unitTypeId)
      {
        case Constants.UNIT_D_MONENF_RST_LEGION:
          unit.SetAbilityLevel(Constants.ABILITY_FEUERREGEN_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_SPALTSCHLAG_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_TODESFINGER_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_UNHEILIGE_AURA_LEGION_100, heroLevel);
          unit.SetAbilityLevel(Constants.ABILITY_ERH_HTE_ATTRIBUTE_LEGION_100, heroLevel);
          break;

        default:
          throw new NotImplementedException($"Abilities for hero {unit.Name} (Id {unitTypeId}) not implemented yet!");
      }
    }
  }
}
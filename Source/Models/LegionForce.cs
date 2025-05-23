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

    public void CreateOrReviveHero(int unitTypeId, Area spawnArea, int heroLevel, int abilitiesLevel, float delay, Area targetArea = null)
    {
      if (Hero == null)
        CreateHero(unitTypeId, spawnArea, heroLevel, delay, targetArea);
      else
        ReviveHero(spawnArea, heroLevel, delay, targetArea);

      if (unitTypeId == Constants.UNIT_D_MONENF_RST_LEGION)
      {
        var timer = Common.CreateTimer();
        Common.TimerStart(timer, delay + 1, false, () =>
        {
          try
          {
            Common.DestroyTimer(timer);
            timer.Dispose();
            timer = null;

            TrainGrubenlord(Hero.Wc3Unit, abilitiesLevel);
          }
          catch (Exception ex)
          {
            Program.ShowExceptionMessage("KlatschenFragtion.CreateOrReviveHero", ex);
          }
        });
      }
    }

    internal LegionSpawnBuilding CreateOrRefreshEastSpawnBuilding()
    {
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", Areas.MiddleLaneSpawnEast.Wc3Rectangle.Center, 4f, 3f);

      if (SpawnBuildingEast == null || !SpawnBuildingEast.Wc3Unit.Alive)
      {
        SpawnBuildingEast = new LegionSpawnBuilding(Constants.UNIT_D_MONENSCHREIN_LEGION, Areas.MiddleLaneSpawnEast);
        SpawnBuildingEast.RegisterOnDies(LegionBuilding.OnDies);

        SpawnBuildingEast.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnEast, Areas.CenterRight).Run();
        SpawnBuildingEast.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnEast, Areas.Center).Run();
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_TEUFELSWACHE_LEGION);
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_TEUFELSFRESSER_LEGION);
        SpawnBuildingEast.AddUnitToSpawnTriggers(Constants.UNIT_MAID_DES_SCHMERZES_LEGION);
      }
      else
      {
        SpawnBuildingEast.Wc3Unit.Life = SpawnBuildingEast.Wc3Unit.MaxLife;
      }

      return SpawnBuildingEast;
    }

    internal LegionSpawnBuilding CreateOrRefreshWestSpawnBuilding()
    {
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", Areas.MiddleLaneSpawnWest.Wc3Rectangle.Center, 4f, 3f);

      if (SpawnBuildingWest == null || !SpawnBuildingWest.Wc3Unit.Alive)
      {
        SpawnBuildingWest = new LegionSpawnBuilding(Constants.UNIT_D_MONENSCHREIN_LEGION, Areas.MiddleLaneSpawnWest);
        SpawnBuildingWest.RegisterOnDies(LegionBuilding.OnDies);

        SpawnBuildingWest.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnWest, Areas.CenterLeft).Run();
        SpawnBuildingWest.AddSpawnTrigger(Enums.SpawnInterval.Middle, Areas.MiddleLaneSpawnWest, Areas.Center).Run();
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_TEUFELSWACHE_LEGION);
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_TEUFELSFRESSER_LEGION);
        SpawnBuildingWest.AddUnitToSpawnTriggers(Constants.UNIT_MAID_DES_SCHMERZES_LEGION);
      }
      else
      {
        SpawnBuildingWest.Wc3Unit.Life = SpawnBuildingWest.Wc3Unit.MaxLife;
      }

      return SpawnBuildingWest;
    }

    private void TrainGrubenlord(unit unit, int abilitiesLevel)
    {
      switch (abilitiesLevel)
      {
        case 1:
          unit.AddAbility(Constants.ABILITY_FEUERREGEN_KLATSCHEN_5);
          unit.AddAbility(Constants.ABILITY_SPALTSCHLAG_KLATSCHEN_5);
          unit.AddAbility(Constants.ABILITY_INFERNO_KLATSCHEN_5);
          unit.AddAbility(Constants.ABILITY_UNHEILIGE_AURA_KLATSCHEN_5);

          unit.AddAbility(Constants.ABILITY_ERH_HTE_ATTRIBUTE_HERO_50);
          unit.SetAbilityLevel(Constants.ABILITY_ERH_HTE_ATTRIBUTE_HERO_50, 10);
          break;
        case 2:
        case 3:
        case 4:
        case 5:
          unit.IncrementAbilityLevel(Constants.ABILITY_FEUERREGEN_KLATSCHEN_5);
          unit.IncrementAbilityLevel(Constants.ABILITY_SPALTSCHLAG_KLATSCHEN_5);
          unit.IncrementAbilityLevel(Constants.ABILITY_INFERNO_KLATSCHEN_5);
          unit.IncrementAbilityLevel(Constants.ABILITY_UNHEILIGE_AURA_KLATSCHEN_5);

          unit.SetAbilityLevel(Constants.ABILITY_ERH_HTE_ATTRIBUTE_HERO_50, abilitiesLevel * 10);
          break;
      }
    }
  }
}
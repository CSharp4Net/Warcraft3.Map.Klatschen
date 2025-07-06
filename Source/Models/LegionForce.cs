using Source.Events.Buildings;
using Source.Events.Periodic;
using Source.Statics;
using System;
using System.Collections;
using System.Collections.Generic;
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
      Wc3Player = Common.Player(ConstantsEx.PlayerId_Legion);
      Wc3Player.SetState(playerstate.GivesBounty, 1);
    }

    private List<LegionSpawnBuilding> SpawnBuildings { get; set; } = new List<LegionSpawnBuilding>();

    /// <summary>
    /// Name des Söldnerlagers mit Farberweiterung.
    /// </summary>
    public string ColorizedName { get; init; }
    /// <summary>
    /// Name des Söldnerlagers, welcher in Nachrichten angezeigt wird.
    /// </summary>
    public string Name { get; init; }

    public SpawnedUnit Hero { get; private set; }

    public player Wc3Player { get; init; }

    private List<SpawnedUnit> Units { get; set; } = new List<SpawnedUnit>();

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

    internal void CreateOrRefreshSpawnBuildings(int raidCounts)
    {
      CreateOrRefreshSpawnBuilding(Areas.LegionSpawnBottom, Areas.ElfBase, Areas.UndeadBase, raidCounts);
      CreateOrRefreshSpawnBuilding(Areas.LegionSpawnEast, Areas.OrcBase, Areas.UndeadBase, raidCounts);
      CreateOrRefreshSpawnBuilding(Areas.LegionSpawnTop, Areas.OrcBase, Areas.HumanBase, raidCounts);
      CreateOrRefreshSpawnBuilding(Areas.LegionSpawnWest, Areas.HumanBase, Areas.ElfBase, raidCounts);
    }
    internal void CreateOrRefreshSpawnBuilding(Area creationArea, Area target1, Area target2, int raidCounts)
    {
      foreach (LegionSpawnBuilding spawnBuilding in SpawnBuildings)
      {
        if (spawnBuilding.CreationArea == creationArea)
        {
          spawnBuilding.Wc3Unit.Life = spawnBuilding.Wc3Unit.MaxLife;

          // TODO : Increase power and bounty by raid Counts or so!

          return;
        }
      }

      LegionSpawnBuilding building = new LegionSpawnBuilding(Constants.UNIT_DEMON_SHRINE_LEGION, creationArea, 180f);
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\Human\\SmallFlameSpawn\\SmallFlameSpawn.mdl", building.CreationArea.Wc3Rectangle.Center, 2f, 3f);
      building.RegisterOnDies(LegionBuilding.OnDies);

      building.AddSpawnTrigger(Enums.SpawnInterval.Long, creationArea, target2).Run();
      building.AddSpawnTrigger(Enums.SpawnInterval.Long, creationArea, target1).Run();

      building.AddUnitToSpawnTriggers(Constants.UNIT_FELGUARD_LEGION);

      if (LegionRaid.RaidRound >= 2)
        building.AddUnitToSpawnTriggers(Constants.UNIT_FEL_RAVAGER_LEGION);
      if (LegionRaid.RaidRound >= 3)
        building.AddUnitToSpawnTriggers(Constants.UNIT_MAIDEN_OF_PAIN_LEGION);
      if (LegionRaid.RaidRound >= 4)
        building.AddUnitToSpawnTriggers(Constants.UNIT_FELGUARD_LEGION);
      if (LegionRaid.RaidRound >= 5)
        building.AddUnitToSpawnTriggers(Constants.UNIT_FEL_RAVAGER_LEGION);
      if (LegionRaid.RaidRound >= 6)
        building.AddUnitToSpawnTriggers(Constants.UNIT_VILE_TORMENTOR_LEGION);
      if (LegionRaid.RaidRound >= 7)
        building.AddUnitToSpawnTriggers(Constants.UNIT_INFERNAL_LEGION);
      if (LegionRaid.RaidRound >= 8)
        building.AddUnitToSpawnTriggers(Constants.UNIT_INFERNAL_LEGION);
      if (LegionRaid.RaidRound >= 9)
        building.AddUnitToSpawnTriggers(Constants.UNIT_INFERNAL_MACHINE_LEGION);

      // TODO : Increase power and bounty by raid Counts or so!

      SpawnBuildings.Add(building);
    }

    public bool TryGetSpawnBuilding(unit wc3Unit, out LegionSpawnBuilding building)
    {
      foreach (LegionSpawnBuilding spawnBuilding in SpawnBuildings)
      {
        if (spawnBuilding.Wc3Unit == wc3Unit)
        {
          building = spawnBuilding;
          return true;
        }
      }

      building = null;
      return false;
    }

    public void RemoveSpawnBuilding(LegionSpawnBuilding building)
    {
      building.Destroy();
      building = null;

      SpawnBuildings.Remove(building);
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

    private SpawnedUnit CreateHero(int unitTypeId, Point point, int heroLevel, float face = 0f)
    {
      SpawnedUnit result = new SpawnedUnit(Wc3Player, unitTypeId, point, face);
      result.Wc3Unit.HeroLevel = heroLevel;
      return result;
    }

    internal SpawnedUnit CreateUnitInArea(Area area, int unitTypeId, float face = 0f)
    {
      return CreateUnitAtPoint(area.Wc3Rectangle.Center, unitTypeId, face);
    }
    internal SpawnedUnit CreateUnitAtRandomPoint(Rectangle rectangle, int unitTypeId, float face = 0f)
    {
      Point point = rectangle.GetRandomPoint();
      return CreateUnitAtPoint(point, unitTypeId, face);
    }
    internal SpawnedUnit CreateUnitAtPoint(Point point, int unitTypeId, float face = 0f)
    {
      SpecialEffects.CreateSpecialEffect("Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl", point, 2f, 1f);
      SpawnedUnit result = new SpawnedUnit(Wc3Player, unitTypeId, point, face);
      Units.Add(result);
      ManipulateSpawnedUnit(result.Wc3Unit, LegionRaid.RaidRound);
      return result;
    }

    private void ManipulateSpawnedUnit(unit unit, int raidCount)
    {
      switch (raidCount)
      {
        case 1:
        case 2:
        case 3:
        case 4:
        case 6:
        case 7:
        case 8:
        case 9:
        case 10:
          unit.AttackBaseDamage1 = unit.AttackBaseDamage1 + (10 * raidCount);
          unit.Defense = unit.Defense + (2 * raidCount);
          unit.MaxLife = unit.MaxLife + ((unit.MaxLife / 10) * raidCount);
          break;

        default: // Ab Stufe 10 werden die Einheiten nicht mehr stärker, sonst werden sie (fast) unbesiegbar
          unit.AttackBaseDamage1 = unit.AttackBaseDamage1 + 100;
          unit.Defense = unit.Defense + 20;
          unit.MaxLife = unit.MaxLife + (unit.MaxLife);
          break;
      }

      unit.Life = unit.MaxLife;
    }

    /// <summary>
    /// Gibt True zurück, wenn die übergebene Einheit in der Auflistung aller Einheiten enthalten ist
    /// </summary>
    /// <param name="wc3Unit"></param>
    /// <returns></returns>
    public bool IsOwnerOfUnit(unit wc3Unit, out SpawnedUnit unit)
    {
      if (wc3Unit.Owner.Id != ConstantsEx.PlayerId_Legion)
      {
        unit = null;
        return false;
      }

      int unitId = wc3Unit.UnitType;

      foreach (SpawnedUnit spawnedUnit in Units)
      {
        // Prüfe primär die Einheit-Id, da ein UNIT-Vergleich nicht empfohlen wird!
        // Ein Einheitenvergleich wird zwar nicht empfohlen, ist aber die einzige Möglichkeit diesselbe Einheit zu ermitteln
        if (spawnedUnit.Wc3Unit.UnitType == unitId && spawnedUnit.Wc3Unit == wc3Unit)
        {
          unit = spawnedUnit;
          return true;
        }
      }

      // Dieser Fall kann eintreten, wenn eine statische Computer-Einheit das Event auslöst
      unit = null;
      return false;
    }

    /// <summary>
    /// Entfernt eine Einheit aus der Auflistung aller Einheiten.
    /// </summary>
    /// <param name="unit"></param>
    public void RemoveUnit(SpawnedUnit unit)
    {
      Units.Remove(unit);
    }
  }
}
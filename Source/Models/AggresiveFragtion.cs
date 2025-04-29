using Source.Abstracts;
using Source.Handler.Generic;
using Source.Statics;
using System.Reflection.Emit;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class AggresiveFragtion : FragtionBase
  {
    public AggresiveFragtion()
      : base(player.NeutralAggressive)
    {

    }

    public override void CreateOrReviveHero(int unitTypeId, Area spawnArea, int heroLevel, int abilitiesLevel, float delay)
    {
      base.CreateOrReviveHero(unitTypeId, spawnArea, heroLevel, abilitiesLevel, delay);

      int unitId = Common.GetUnitTypeId(Hero);
      if (unitId == Constants.UNIT_GRUBENLORD_KLATSCHEN)
      {
        TrainGrubenlord(Hero, abilitiesLevel);
      }
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
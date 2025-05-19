using Source.Abstracts;
using System;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class KlatschenFragtion : NeutralForce
  {
    public KlatschenFragtion() : base(player.NeutralAggressive)
    {

    }

    public void CreateOrReviveHero(int unitTypeId, Area spawnArea, int heroLevel, int abilitiesLevel, float delay, Area targetArea = null)
    {
      if (Hero == null)
        CreateHero(unitTypeId, spawnArea, heroLevel, delay, targetArea);
      else
        ReviveHero(spawnArea, heroLevel, delay, targetArea);

      if (unitTypeId == Constants.UNIT_GRUBENLORD_KLATSCHEN)
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
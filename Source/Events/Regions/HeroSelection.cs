using System;
using WCSharp.Api;

namespace Source.Events.Regions
{
  internal static class HeroSelection
  {
    internal static void OnAlchemist()
    {
      HandleHeroSelection(Constants.UNIT_ALCHEMIST_HERO);
    }

    internal static void OnArchmage()
    {
      HandleHeroSelection(Constants.UNIT_ARCHMAGE_HERO);
    }

    internal static void OnBlademaster()
    {
      HandleHeroSelection(Constants.UNIT_BLADEMASTER_HERO);
    }

    internal static void OnBloodMage()
    {
      HandleHeroSelection(Constants.UNIT_BLOOD_MAGE_HERO);
    }

    internal static void OnBrewmaster()
    {
      HandleHeroSelection(Constants.UNIT_BREWMASTER_HERO);
    }

    internal static void OnCryptLord()
    {
      HandleHeroSelection(Constants.UNIT_CRYPT_LORD_HERO);
    }

    internal static void OnDarkRanger()
    {
      HandleHeroSelection(Constants.UNIT_DARK_RANGER_HERO);
    }

    internal static void OnDeathKnight()
    {
      HandleHeroSelection(Constants.UNIT_DEATH_KNIGHT_HERO);
    }

    internal static void OnFirelord()
    {
      HandleHeroSelection(Constants.UNIT_FIRELORD_HERO);
    }

    internal static void OnKeeperOfTheGrove()
    {
      HandleHeroSelection(Constants.UNIT_KEEPER_OF_THE_GROVE_HERO);
    }

    internal static void OnLich()
    {
      HandleHeroSelection(Constants.UNIT_LICH_HERO);
    }

    internal static void OnMountainKing()
    {
      HandleHeroSelection(Constants.UNIT_MOUNTAIN_KING_HERO);
    }

    internal static void OnPitLord()
    {
      HandleHeroSelection(Constants.UNIT_PIT_LORD_HERO);
    }

    internal static void OnPriestessOfMoon()
    {
      HandleHeroSelection(Constants.UNIT_PRIESTESS_OF_THE_MOON_HERO);
    }

    internal static void OnSeaWitch()
    {
      HandleHeroSelection(Constants.UNIT_SEA_WITCH_HERO);
    }

    internal static void OnShadowHunter()
    {
      HandleHeroSelection(Constants.UNIT_SHADOW_HUNTER_HERO);
    }

    internal static void OnTaurenChieftain()
    {
      HandleHeroSelection(Constants.UNIT_TAUREN_CHIEFTAIN_HERO);
    }

    internal static void OnTinker()
    {
      HandleHeroSelection(Constants.UNIT_TINKER_HERO);
    }

    internal static void OnWarden()
    {
      HandleHeroSelection(Constants.UNIT_WARDEN_HERO);
    }

    private static void HandleHeroSelection(int heroUnitTypeId)
    {
      unit unit = Common.GetEnteringUnit();

      if (Common.GetUnitTypeId(unit) == Constants.UNIT_HEROIC_SOUL_HERO_SELECTOR)
      {
        // Helden-Selector kauft Benutzerhelden
        Logics.HeroSelector.HandleHeroSelected(unit, heroUnitTypeId);
        return;
      }
      else
        Program.ShowErrorMessage("HeroSelection", $"Invalid unit {unit.Name} detected in hero selection areas!");
    }
  }
}

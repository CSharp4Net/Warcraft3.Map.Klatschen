using Source.Abstracts;
using Source.Events;
using Source.Events.Buildings;
using Source.Events.Periodic;
using Source.Events.Region;
using Source.Events.Regions;
using Source.Models;
using Source.Models.Teams;
using System;
using System.Collections.Generic;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Sync;

namespace Source
{
  public static class Program
  {
    public static bool Debug { get; private set; } = false;

    public static HumansTeam Humans;
    public static OrcsTeam Orcs;
    public static ElvesTeam Elves;
    public static UndeadsTeam Undeads;

    public static LegionForce Legion;

    public static List<MercenaryForce> Mercenaries { get; set; } = new List<MercenaryForce>();

    /// <summary>
    /// Alle aktiven Benutzer-Spieler
    /// </summary>
    public static List<UserPlayer> AllActiveUsers { get; set; } = new List<UserPlayer>();

    public static void Main()
    {
      // Delay a little since some stuff can break otherwise
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, 0.01f, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        Start();
      });
    }

    public static void ShowDebugMessage(string message)
    {
#if DEBUG
      Console.WriteLine(message);
#endif
    }
    public static void ShowDebugMessage(string sender, string message)
    {
#if DEBUG
      Console.WriteLine($"{sender}: {message}");
#endif
    }
    public static void ShowErrorMessage(string sender, string message)
    {
      Console.WriteLine($"|c{ConstantsEx.ColorHexCode_Red}{sender}: {message}|r");
    }
    public static void ShowExceptionMessage(string sender, Exception ex)
    {
      Console.WriteLine($"|c{ConstantsEx.ColorHexCode_Red}{sender}: {ex.ToString()}|r");
    }

    private static void Start()
    {
      try
      {
#if DEBUG
        // This part of the code will only run if the map is compiled in Debug mode
        Debug = true;
        ShowDebugMessage("Start", "Running in debug mode...");

        // By calling these methods, whenever these systems call external code (i.e. your code),
        // they will wrap the call in a try-catch and output any errors to the chat for easier debugging
        PeriodicEvents.EnableDebug();
        PlayerUnitEvents.EnableDebug();
        SyncSystem.EnableDebug();
        Delay.EnableDebug();
#endif

        Blizzard.SetTimeOfDay(0f);

        // Teams initialisieren
        Humans = new HumansTeam();
        Orcs = new OrcsTeam();
        Elves = new ElvesTeam();
        Undeads = new UndeadsTeam();

        Legion = new LegionForce(ConstantsEx.ForceName_DemonLegion);

        // Helden-Auswahl-Ereignisse registrieren
        Areas.HeroAlchemist.RegisterOnEnter(HeroSelection.OnAlchemist);
        Areas.HeroArchmage.RegisterOnEnter(HeroSelection.OnArchmage);
        Areas.HeroBlademaster.RegisterOnEnter(HeroSelection.OnBlademaster);
        Areas.HeroBloodMage.RegisterOnEnter(HeroSelection.OnBloodMage);
        Areas.HeroBrewmaster.RegisterOnEnter(HeroSelection.OnBrewmaster);
        Areas.HeroCryptLord.RegisterOnEnter(HeroSelection.OnCryptLord);
        Areas.HeroDarkRanger.RegisterOnEnter(HeroSelection.OnDarkRanger);
        Areas.HeroDeathKnight.RegisterOnEnter(HeroSelection.OnDeathKnight);
        Areas.HeroFarSeer.RegisterOnEnter(HeroSelection.OnFarSeer);
        Areas.HeroFirelord.RegisterOnEnter(HeroSelection.OnFirelord);
        Areas.HeroKeeperOfTheGrove.RegisterOnEnter(HeroSelection.OnKeeperOfTheGrove);
        Areas.HeroLich.RegisterOnEnter(HeroSelection.OnLich);
        Areas.HeroMountainKing.RegisterOnEnter(HeroSelection.OnMountainKing);
        Areas.HeroPitLord.RegisterOnEnter(HeroSelection.OnPitLord);
        Areas.HeroPriestessOfMoon.RegisterOnEnter(HeroSelection.OnPriestessOfMoon);
        Areas.HeroSeaWitch.RegisterOnEnter(HeroSelection.OnSeaWitch);
        Areas.HeroShadowHunter.RegisterOnEnter(HeroSelection.OnShadowHunter);
        Areas.HeroTaurenChieftain.RegisterOnEnter(HeroSelection.OnTaurenChieftain);
        Areas.HeroTinker.RegisterOnEnter(HeroSelection.OnTinker);
        Areas.HeroWarden.RegisterOnEnter(HeroSelection.OnWarden);

        // Regions-Ereignisse registrieren für automatische Einheitenbewegungen:
        // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden.
        Areas.HumanBase.RegisterOnEnter(HumanBase.OnEnter);
        Areas.OrcBase.RegisterOnEnter(OrcBase.OnEnter);
        Areas.ElfBase.RegisterOnEnter(ElfBase.OnEnter);
        Areas.UndeadBase.RegisterOnEnter(UndeadBase.OnEnter);

        Blizzard.bj_stockUpdateTimer.Pause();
        Blizzard.bj_stockItemPurchased.Disable();

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.BuysUnit, Unit.OnBuysUnit);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, Unit.OnFinishesResearch);
        PlayerUnitEvents.Register(UnitTypeEvent.SellsItem, Unit.OnSellsItem);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, Unit.OnDies);
        PlayerUnitEvents.Register(UnitTypeEvent.ReceivesOrder, Unit.OnReceivesOrder);
        PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, Unit.OnSpellEffect);
        PlayerUnitEvents.Register(HeroTypeEvent.Levels, Hero.OnLevels);

        // Periodische Events registrieren
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);
        PeriodicEvents.AddPeriodicEvent(LegionRaid.OnElapsed, ConstantsEx.Interval_Event_Klatschen);
        PeriodicEvents.AddPeriodicEvent(ResearchCheck.OnElapsed, 10f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        Humans.CreateBuildings();
        Orcs.CreateBuildings();
        Elves.CreateBuildings();
        Undeads.CreateBuildings();

        ConstructCreepCamps();

        // Spezifische Events registrieren
        Console.WriteLine(ConstantsEx.Message_FightToTheDeath);

        // Für alle Benutzer-Spieler einen Hero-Selector generieren
        foreach (UserPlayer user in AllActiveUsers)
        {
          // Dauerhafte Spielersicht auf Heldenauswahlbereich
          fogmodifier fogmodifier = Blizzard.CreateFogModifierRectSimple(user.Wc3Player, fogstate.Visible, Regions.HeroSelectionTotal.Rect, true);
          fogmodifier.Start();

          CreateHeroSelectorForPlayerAndAdjustCamera(user);
        }

#if DEBUG
        Common.FogEnable(false);
        Common.FogMaskEnable(false);
#endif

        var timer = Common.CreateTimer();
        Common.TimerStart(timer, 10f, false, () =>
        {
          try
          {
            Common.DestroyTimer(timer);
            timer.Dispose();
            timer = null;

            CreateComputerHeros();
          }
          catch (Exception ex)
          {
            ShowExceptionMessage("Start.CreateComputerHeros", ex);
          }
        });
      }
      catch (Exception ex)
      {
        ShowExceptionMessage("Start", ex);
      }
    }

    public static bool TryGetUserById(int wc3PlayerId, out UserPlayer user)
    {
      for (int i = AllActiveUsers.Count - 1; i >= 0; i--)
      {
        if (AllActiveUsers[i].PlayerId == wc3PlayerId)
        {
          user = AllActiveUsers[i];
          return true;
        }
      }

      user = null;
      return false;
    }

    public static bool TryGetCreepCampByBuilding(unit buildingUnit, out MercenaryForce creepCamp)
    {
      for (int i = Mercenaries.Count - 1; i >= 0; i--)
      {
        if (Mercenaries[i].Building.Wc3Unit == buildingUnit)
        {
          creepCamp = Mercenaries[i];
          return true;
        }
      }

      creepCamp = null;
      return false;
    }

    public static bool TryGetCreepCampByUnit(unit buildingUnit, out MercenaryForce creepCamp)
    {
      for (int i = Mercenaries.Count - 1; i >= 0; i--)
      {
        if (Mercenaries[i].Building.Wc3Unit == buildingUnit)
        {
          creepCamp = Mercenaries[i];
          return true;
        }
      }

      creepCamp = null;
      return false;
    }

    public static bool TryGetTeamByUnit(unit unit, out TeamBase team)
    {
      int playerId = unit.Owner.Id;

      if (playerId == Humans.Computer.PlayerId)
      {
        team = Humans;
        return true;
      }
      else if (playerId == Orcs.Computer.PlayerId)
      {
        team = Orcs;
        return true;
      }
      else if (playerId == Elves.Computer.PlayerId)
      {
        team = Elves;
        return true;
      }
      else if (playerId == Undeads.Computer.PlayerId)
      {
        team = Undeads;
        return true;
      }

      team = null;
      return false;
    }

    private static void ConstructCreepCamps()
    {
      // Menschen-Creeps
      ConstructCreepCamp("Bandits", Areas.HumanCreepToElfSpawnBuilding, Areas.HumanCreepToElfSpawn,
        Humans, Elves, Constants.UNIT_BANDIT_CAMP_CREEP, Constants.UNIT_BANDIT_LORD_CREEP,
        Constants.UNIT_BANDIT_CREEP, Constants.UNIT_BANDIT_CREEP, Constants.UNIT_BANDIT_CREEP,
        Constants.UNIT_BANDIT_ASSASSIN_CREEP, Constants.UNIT_BANDIT_ASSASSIN_CREEP, Constants.UNIT_BANDIT_WIZARD_CREEP);
      ConstructCreepCamp("Tuskarr", Areas.HumanCreepToOrcSpawnBuilding, Areas.HumanCreepToOrcSpawn,
        Humans, Orcs, Constants.UNIT_TUSKARR_CAMP_CREEP, Constants.UNIT_TUSKARR_CHIEFTAIN_CREEP,
        Constants.UNIT_TUSKARR_WARRIOR_CREEP, Constants.UNIT_TUSKARR_WARRIOR_CREEP, Constants.UNIT_TUSKARR_WARRIOR_CREEP,
        Constants.UNIT_TUSKARR_HUNTER_CREEP, Constants.UNIT_TUSKARR_HUNTER_CREEP, Constants.UNIT_TUSKARR_HEALER_CREEP);

      // Elfen-Creeps
      ConstructCreepCamp("Furbolgs", Areas.ElfCreepToHumanSpawnBuilding, Areas.ElfCreepToHumanSpawn,
        Elves, Humans, Constants.UNIT_FURBOLG_CAMP_CREEP, Constants.UNIT_FURBOLG_CHAMPION_CREEP,
        Constants.UNIT_FURBOLG_WARRIOR_CREEP, Constants.UNIT_FURBOLG_WARRIOR_CREEP,
        Constants.UNIT_FURBOLG_HUNTER_CREEP, Constants.UNIT_FURBOLG_HUNTER_CREEP, Constants.UNIT_FURBOLG_WIZARD_CREEP);
      ConstructCreepCamp("Wildekins", Areas.ElfCreepToUndeadSpawnBuilding, Areas.ElfCreepToUndeadSpawn,
        Elves, Undeads, Constants.UNIT_WILDEKIN_CAMP_CREEP, Constants.UNIT_WILDEKIN_ALPHA_CREEP,
        Constants.UNIT_WILDEKIN_CREEP, Constants.UNIT_WILDEKIN_CREEP, Constants.UNIT_WILDEKIN_CREEP,
        Constants.UNIT_WILDEKIN_TRAPPER_CREEP, Constants.UNIT_WILDEKIN_TRAPPER_CREEP, Constants.UNIT_WILDEKIN_ANCESTOR_CREEP);

      // Orcs-Creeps
      ConstructCreepCamp("Centaurs", Areas.OrcCreepToHumanSpawnBuilding, Areas.OrcCreepToHumanSpawn,
        Orcs, Humans, Constants.UNIT_CENTAUR_CAMP_CREEP, Constants.UNIT_CENTAUR_KHAN_CREEP,
        Constants.UNIT_CENTAUR_RUNNER_CREEP, Constants.UNIT_CENTAUR_RUNNER_CREEP, Constants.UNIT_CENTAUR_RUNNER_CREEP,
        Constants.UNIT_CENTAUR_ARCHER_CREEP, Constants.UNIT_CENTAUR_ARCHER_CREEP, Constants.UNIT_CENTAUR_SORCERESS_CREEP);
      ConstructCreepCamp("Ogres", Areas.OrcCreepToUndeadSpawnBuilding, Areas.OrcCreepToUndeadSpawn,
        Orcs, Undeads, Constants.UNIT_OGRE_CAMP_CREEP, Constants.UNIT_OGRE_LORD_CREEP,
        Constants.UNIT_OGRE_WARRIOR_CREEP, Constants.UNIT_OGRE_WARRIOR_CREEP, Constants.UNIT_OGRE_WARRIOR_CREEP,
        Constants.UNIT_OGRE_THIEF_CREEP, Constants.UNIT_OGRE_THIEF_CREEP, Constants.UNIT_OGRE_MAGE_CREEP);

      // Untoten-Creeps
      ConstructCreepCamp("Mur'guls", Areas.UndeadCreepToOrcSpawnBuilding, Areas.UndeadCreepToOrcSpawn,
        Undeads, Orcs, Constants.UNIT_MUR_GUL_CAMP_CREEP, Constants.UNIT_MUR_GUL_SHADOWCASTER_CREEP,
        Constants.UNIT_MUR_GUL_WARRIOR_CREEP, Constants.UNIT_MUR_GUL_WARRIOR_CREEP, Constants.UNIT_MUR_GUL_WARRIOR_CREEP,
        Constants.UNIT_MUR_GUL_TRAPPER_CREEP, Constants.UNIT_MUR_GUL_TRAPPER_CREEP, Constants.UNIT_MUR_GUL_WIZARD_CREEP);
      ConstructCreepCamp("Nerubians", Areas.UndeadCreepToElfSpawnBuilding, Areas.UndeadCreepToElfSpawn,
        Undeads, Elves, Constants.UNIT_NERUBIAN_CAMP_CREEP, Constants.UNIT_NERUBIAN_QUEEN_CREEP,
        Constants.UNIT_NERUBIAN_WARRIOR_CREEP, Constants.UNIT_NERUBIAN_WARRIOR_CREEP, Constants.UNIT_NERUBIAN_WARRIOR_CREEP,
        Constants.UNIT_NERUBIAN_SPINNER_CREEP, Constants.UNIT_NERUBIAN_SPINNER_CREEP, Constants.UNIT_NERUBIAN_WIZARD_CREEP);
    }

    private static void ConstructCreepCamp(string name,
      Area buildingArea, Area spawnArea,
      TeamBase nearestTeam, TeamBase opposingTeam,
      int buildingUnitType, params int[] defenderUnitTypeIds)
    {
      MercenaryForce creepCamp = new MercenaryForce(name, buildingArea, spawnArea, nearestTeam, opposingTeam, buildingUnitType, defenderUnitTypeIds);
      MercenarySpawnBuilding building = creepCamp.InitializeBuilding();
      Mercenaries.Add(creepCamp);
    }

    private static void CreateComputerHeros()
    {
      Humans.Computer.CreateUnit(Constants.UNIT_GUARDIAN_HUMAN, Areas.HumanBaseToElfSpawn).AttackMove(Areas.ElfBase);
      Humans.Computer.CreateUnit(Constants.UNIT_GUARDIAN_HUMAN, Areas.HumanBaseToCenterSpawn).AttackMove(Areas.UndeadBase);
      Humans.Computer.CreateUnit(Constants.UNIT_GUARDIAN_HUMAN, Areas.HumanBaseToOrcsSpawn).AttackMove(Areas.OrcBase);

      Orcs.Computer.CreateUnit(Constants.UNIT_GUARDIAN_ORC, Areas.OrcBaseToCenterSpawn).AttackMove(Areas.ElfBase);
      Orcs.Computer.CreateUnit(Constants.UNIT_GUARDIAN_ORC, Areas.OrcBaseToUndeadSpawn).AttackMove(Areas.UndeadBase);
      Orcs.Computer.CreateUnit(Constants.UNIT_GUARDIAN_ORC, Areas.OrcBaseToHumanSpawn).AttackMove(Areas.HumanBase);

      Elves.Computer.CreateUnit(Constants.UNIT_GUARDIAN_ELF, Areas.ElfBaseToHumanSpawn).AttackMove(Areas.HumanBase);
      Elves.Computer.CreateUnit(Constants.UNIT_GUARDIAN_ELF, Areas.ElfBaseToUndeadSpawn).AttackMove(Areas.UndeadBase);
      Elves.Computer.CreateUnit(Constants.UNIT_GUARDIAN_ELF, Areas.ElfBaseToCenterSpawn).AttackMove(Areas.OrcBase);

      Undeads.Computer.CreateUnit(Constants.UNIT_GUARDIAN_UNDEAD, Areas.UndeadBaseToElfSpawn).AttackMove(Areas.ElfBase);
      Undeads.Computer.CreateUnit(Constants.UNIT_GUARDIAN_UNDEAD, Areas.UndeadBaseToCenterSpawn).AttackMove(Areas.HumanBase);
      Undeads.Computer.CreateUnit(Constants.UNIT_GUARDIAN_UNDEAD, Areas.UndeadBaseToOrcsSpawn).AttackMove(Areas.OrcBase);
    }

    internal static void CreateHeroSelectorForPlayerAndAdjustCamera(UserPlayer user)
    {
      SpawnedUnit unit = user.CreateUnit(Constants.UNIT_HEROIC_SOUL_HERO_SELECTOR, Areas.HeroSelectorSpawn);

      // Spieler-Kamera auf Heldenseele fokussieren
      user.ApplyCamera(Areas.HeroSelectorSpawn);

      // Heldenseele auswählen
      Blizzard.SelectUnitForPlayerSingle(unit.Wc3Unit, user.Wc3Player);
    }

    internal static int GetIntervalSeconds(Enums.SpawnInterval spawnInterval)
    {
      switch (spawnInterval)
      {
        case Enums.SpawnInterval.Short:
          return ConstantsEx.Interval_SpawnTime_Short;
        case Enums.SpawnInterval.Middle:
          return ConstantsEx.Interval_SpawnTime_Middle;
        case Enums.SpawnInterval.Long:
          return ConstantsEx.Interval_SpawnTime_Long;

        default:
          Console.WriteLine("Unsupported SpawnInterval!");
          return 999;
      }
    }
  }
}
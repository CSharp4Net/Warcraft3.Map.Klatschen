using Source.Abstracts;
using Source.Events;
using Source.Events.Buildings;
using Source.Events.Periodic;
using Source.Events.Region;
using Source.Events.Regions;
using Source.Extensions;
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
        Humans = new HumansTeam(Common.Player(0));
        Orcs = new OrcsTeam(Common.Player(4));
        Elves = new ElvesTeam(Common.Player(8));
        Undeads = new UndeadsTeam(Common.Player(12));

        Legion = new LegionForce(ConstantsEx.ForceName_DemonLegion);

        // Helden-Auswahl-Ereignisse registrieren
        Areas.HeroAlchemist.RegisterOnEnter(HeroSelection.OnAlchemist);
        Areas.HeroArchmage.RegisterOnEnter(HeroSelection.OnArchmage);
        Areas.HeroBlademaster.RegisterOnEnter(HeroSelection.OnBlademaster);
        Areas.HeroBloodMage.RegisterOnEnter(HeroSelection.OnBloodMage);
        Areas.HeroBrewmaster.RegisterOnEnter(HeroSelection.OnBrewmaster);
        Areas.HeroDarkRanger.RegisterOnEnter(HeroSelection.OnDarkRanger);
        Areas.HeroFirelord.RegisterOnEnter(HeroSelection.OnFirelord);
        Areas.HeroKeeperOfTheGrove.RegisterOnEnter(HeroSelection.OnKeeperOfTheGrove);
        Areas.HeroMountainKing.RegisterOnEnter(HeroSelection.OnMountainKing);
        Areas.HeroPitLord.RegisterOnEnter(HeroSelection.OnPitLord);
        Areas.HeroSeaWitch.RegisterOnEnter(HeroSelection.OnSeaWitch);
        Areas.HeroShadowHunter.RegisterOnEnter(HeroSelection.OnShadowHunter);
        Areas.HeroTinker.RegisterOnEnter(HeroSelection.OnTinker);

        // Regions-Ereignisse registrieren für automatische Einheitenbewegungen:
        // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden.
        Areas.HumanBase.RegisterOnEnter(HumanBase.OnEnter);
        Areas.OrcBase.RegisterOnEnter(OrcBase.OnEnter);
        Areas.ElfBase.RegisterOnEnter(ElfBase.OnEnter);
        Areas.UndeadBase.RegisterOnEnter(UndeadBase.OnEnter);

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
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        ConstructElfBuildingAndTrigger();
        ConstructUndeadBuildingAndTrigger();

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
        //Common.FogEnable(false);
        //Common.FogMaskEnable(false);
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

    private static void ConstructHumanBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnUnitsBuilding building = Humans.Computer.CreateBuilding(Constants.UNIT_CASTLE_HUMAN, Areas.HumanBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_PRIEST_HUMAN, Constants.UNIT_FLYING_MACHINE_HUMAN)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.UndeadBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_PRIEST_HUMAN, Constants.UNIT_FLYING_MACHINE_HUMAN)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.SpawnInterval.Long, Areas.ElfBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_PRIEST_HUMAN, Constants.UNIT_FLYING_MACHINE_HUMAN)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.SpawnInterval.Long, Areas.OrcBase)
        .Run(7.5f);

      // Kasernen
      building = Humans.Computer.CreateBuilding(Constants.UNIT_BARRACKS_HUMAN, Areas.HumanBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.UndeadBase, Constants.UNIT_SOLDIER_HUMAN, Constants.UNIT_SOLDIER_HUMAN)
        .Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_RIFLEMAN_HUMAN)
        .Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_BARRACKS_HUMAN, Areas.HumanBarracksToElf);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.SpawnInterval.Short, Areas.ElfBase, Constants.UNIT_SOLDIER_HUMAN, Constants.UNIT_SOLDIER_HUMAN)
        .Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_RIFLEMAN_HUMAN)
        .Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_BARRACKS_HUMAN, Areas.HumanBarracksToOrcs);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.SpawnInterval.Short, Areas.OrcBase, Constants.UNIT_SOLDIER_HUMAN, Constants.UNIT_SOLDIER_HUMAN)
        .Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_RIFLEMAN_HUMAN)
        .Run(1f);
    }

    private static void ConstructOrcBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnUnitsBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_FORTRESS_ORC, Areas.OrcBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_WITCH_DOCTOR_ORC, Constants.UNIT_BATRIDER_ORC)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.ElfBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_WITCH_DOCTOR_ORC, Constants.UNIT_BATRIDER_ORC)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.SpawnInterval.Long, Areas.HumanBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_WITCH_DOCTOR_ORC, Constants.UNIT_BATRIDER_ORC)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.SpawnInterval.Long, Areas.UndeadBase)
        .Run(7.5f);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_BARRACKS_ORC, Areas.OrcBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.ElfBase, Constants.UNIT_GRUNT_ORC, Constants.UNIT_GRUNT_ORC)
        .Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_HEADHUNTER_ORC)
        .Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_BARRACKS_ORC, Areas.OrcBarracksToHuman);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.SpawnInterval.Short, Areas.HumanBase, Constants.UNIT_GRUNT_ORC, Constants.UNIT_GRUNT_ORC)
        .Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_HEADHUNTER_ORC)
        .Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_BARRACKS_ORC, Areas.OrcBarracksToUndead);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.SpawnInterval.Short, Areas.UndeadBase, Constants.UNIT_GRUNT_ORC, Constants.UNIT_GRUNT_ORC)
        .Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_HEADHUNTER_ORC)
        .Run(0.5f);
    }

    private static void ConstructElfBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnUnitsBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_TREE_OF_ETERNITY_ELF, Areas.ElfBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_DRUID_OF_THE_TALON_ELF, Constants.UNIT_FAERIE_DRAGON_ELF)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.OrcBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_DRUID_OF_THE_TALON_ELF, Constants.UNIT_FAERIE_DRAGON_ELF)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.SpawnInterval.Long, Areas.HumanBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_DRUID_OF_THE_TALON_ELF, Constants.UNIT_FAERIE_DRAGON_ELF)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.SpawnInterval.Long, Areas.UndeadBase)
        .Run(7.5f);

      // Kasernen
      building = Elves.Computer.CreateBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF, Areas.ElfBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.OrcBase, Constants.UNIT_SENTRY_ELF, Constants.UNIT_SENTRY_ELF)
        .Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_SENTRY_ELF)
        .Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF, Areas.ElfBarracksToHuman);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.SpawnInterval.Short, Areas.HumanBase, Constants.UNIT_SENTRY_ELF, Constants.UNIT_SENTRY_ELF)
        .Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_ARCHER_ELF)
        .Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_ANCIENT_OF_WAR_ELF, Areas.ElfBarracksToUndead);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.SpawnInterval.Short, Areas.UndeadBase, Constants.UNIT_SENTRY_ELF, Constants.UNIT_SENTRY_ELF)
        .Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_ARCHER_ELF)
        .Run(0.5f);
    }

    private static void ConstructUndeadBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnUnitsBuilding building = Undeads.Computer.CreateBuilding(Constants.UNIT_BLACK_CITADEL_UNDEAD, Areas.UndeadBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_SKELETAL_MAGE_UNDEAD, Constants.UNIT_GARGOYLE_UNDEAD)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.HumanBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_SKELETAL_MAGE_UNDEAD, Constants.UNIT_GARGOYLE_UNDEAD)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.SpawnInterval.Long, Areas.ElfBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_SKELETAL_MAGE_UNDEAD, Constants.UNIT_GARGOYLE_UNDEAD)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.SpawnInterval.Long, Areas.OrcBase)
        .Run(7.5f);

      // Kasernen
      building = Undeads.Computer.CreateBuilding(Constants.UNIT_CRYPT_UNDEAD, Areas.UndeadBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.HumanBase, Constants.UNIT_GHOUL_UNDEAD, Constants.UNIT_GHOUL_UNDEAD)
        .Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_CRYPT_FIEND_UNDEAD)
        .Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_CRYPT_UNDEAD, Areas.UndeadBarracksToElf);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.SpawnInterval.Short, Areas.ElfBase, Constants.UNIT_GHOUL_UNDEAD, Constants.UNIT_GHOUL_UNDEAD)
        .Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_CRYPT_FIEND_UNDEAD)
        .Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_CRYPT_UNDEAD, Areas.UndeadBarracksToOrcs);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.SpawnInterval.Short, Areas.OrcBase, Constants.UNIT_GHOUL_UNDEAD, Constants.UNIT_GHOUL_UNDEAD)
        .Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_CRYPT_FIEND_UNDEAD)
        .Run(0.5f);
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
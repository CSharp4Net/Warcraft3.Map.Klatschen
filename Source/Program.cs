using Source.Events.Computer;
using Source.Events.Generic;
using Source.Events.GenericEvents;
using Source.Events.Periodic;
using Source.Events.Player;
using Source.Events.Region;
using Source.Events.Specific;
using Source.Events.User;
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

    public static HumanTeam Humans;
    public static OrcTeam Orcs;
    public static ElfTeam Elves;
    public static UndeadTeam Undeads;

    public static KlatschenFragtion Legion;

    public static List<CreepFragtion> Creeps { get; set; } = new List<CreepFragtion>();

    /// <summary>
    /// Alle aktiven Benutzer-Spieler
    /// </summary>
    public static List<UserPlayer> AllActiveUsers { get; set; } = new List<UserPlayer>();

    internal const int BarracksSpawnTime = 15;
    internal const int MainBuilding1SpawnTime = 30;
    internal const int MainBuilding2SpawnTime = 60;

#if DEBUG
    internal const float KlatschenInterval = 360f;
#else
    internal const float KlatschenInterval = 900f;
#endif

    public static void Main()
    {
      // Delay a little since some stuff can break otherwise
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, 0.01f, false, () =>
      {
        Common.DestroyTimer(timer);
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
    public static void ShowExceptionMessage(string sender, Exception ex)
    {
      Console.WriteLine($"{sender}: {ex.ToString()}");
    }

    public static bool TryGetActiveUser(int wc3PlayerId, out UserPlayer user)
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
        Humans = new HumanTeam(Common.Player(0));
        Orcs = new OrcTeam(Common.Player(4));
        Elves = new ElfTeam(Common.Player(8));
        Undeads = new UndeadTeam(Common.Player(12));

        Legion = new KlatschenFragtion();

        // Regions-Ereignisse registrieren für automatische Einheitenbewegungen
        RegisterRegionTriggersInHumanArea();
        RegisterRegionTriggerInOrcArea();
        RegisterRegionTriggerInElfArea();
        RegisterRegionTriggerInUndeadArea();

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.BuysUnit, UserHero.OnBuyed);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, UserResearch.OnFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.SellsItem, Item.OnSellsFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, Unit.OnDies);
        PlayerUnitEvents.Register(UnitTypeEvent.ReceivesOrder, Unit.OnReceivesOrder);
        PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, Ability.OnCasted);
        PlayerUnitEvents.Register(HeroTypeEvent.Levels, ComputerHero.OnLevels);

        // Periodische Events registrieren
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);
        PeriodicEvents.AddPeriodicEvent(Klatschen.OnElapsed, KlatschenInterval);
        PeriodicEvents.AddPeriodicEvent(ResearchCheck.OnElapsed, 10f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        ConstructElfBuildingAndTrigger();
        ConstructUndeadBuildingAndTrigger();

        // Spezifische Events registrieren
        Console.WriteLine("Kämpft bis zum Tod, ihr Lappen!");

        // Für alle Benutzer-Spieler einen Hero-Selector generieren
        foreach (UserPlayer user in AllActiveUsers)
        {
          CreateHeroSelectorForPlayerAndAdjustCamera(user);
        }

#if DEBUG
        Common.FogEnable(false);
        Common.FogMaskEnable(false);
#endif

        CreepFragtion bandits = new CreepFragtion(Areas.HumanCreepToElf, Areas.HumanCreepToElfSpawn);

        bandits.CreateOrReviveHero(Constants.UNIT_BANDITENF_RST_CREEP);
        //bandits.SpawnUnitInAreaAtRandomPoint(Constants.UNIT_BANDIT_CREEP);
        //bandits.SpawnUnitInAreaAtRandomPoint(Constants.UNIT_BANDIT_CREEP);
        //bandits.SpawnUnitInAreaAtRandomPoint(Constants.UNIT_BANDIT_CREEP);
        //bandits.SpawnUnitInAreaAtRandomPoint(Constants.UNIT_BANDIT_CREEP);

        Creeps.Add(bandits);
        

        var timer = Common.CreateTimer();
        Common.TimerStart(timer, 30f, false, () =>
        {
          try
          {
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

    private static void RegisterRegionTriggersInHumanArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.HumanBase.RegisterOnEnter(HumanBase.OnEnter);
    }

    private static void RegisterRegionTriggerInOrcArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.OrcBase.RegisterOnEnter(OrcBase.OnEnter);
    }

    private static void RegisterRegionTriggerInElfArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.ElfBase.RegisterOnEnter(ElfBase.OnEnter);
    }

    private static void RegisterRegionTriggerInUndeadArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.UndeadBase.RegisterOnEnter(UndeadBase.OnEnter);
    }

    private static void ConstructHumanBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Humans.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.HumanBase);
      building.RegisterOnDies(BuildingMain.OnDies);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.UndeadBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_HUMAN, Constants.UNIT_FLUGEINHEIT_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.UndeadBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.ElfBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_HUMAN, Constants.UNIT_FLUGEINHEIT_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.ElfBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.OrcBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_HUMAN, Constants.UNIT_FLUGEINHEIT_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.OrcBase).Run(7.5f);

      // Kasernen
      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToCenter);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.UndeadBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.UndeadBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_HUMAN).Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToElf);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.ElfBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.ElfBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_HUMAN).Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToOrcs);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.OrcBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.OrcBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_HUMAN).Run(1f);
    }

    private static void ConstructOrcBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_FESTUNG_ORC, Areas.OrcBase);
      building.RegisterOnDies(BuildingMain.OnDies);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.ElfBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_ORC, Constants.UNIT_FLUGEINHEIT_STUFE_1_ORC).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.ElfBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.HumanBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_ORC, Constants.UNIT_FLUGEINHEIT_STUFE_1_ORC).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.HumanBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.UndeadBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_ORC, Constants.UNIT_FLUGEINHEIT_STUFE_1_ORC).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.UndeadBase).Run(7.5f);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToCenter);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.ElfBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.ElfBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ORC).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToHuman);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.HumanBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.HumanBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ORC).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToUndead);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.UndeadBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.UndeadBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ORC).Run(0.5f);
    }

    private static void ConstructElfBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_TELDRASSIL_ELF, Areas.ElfBase);
      building.RegisterOnDies(BuildingMain.OnDies);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.OrcBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_ELF, Constants.UNIT_FLUGEINHEIT_STUFE_1_ELF).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.OrcBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.HumanBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_ELF, Constants.UNIT_FLUGEINHEIT_STUFE_1_ELF).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.HumanBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.UndeadBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_ELF, Constants.UNIT_FLUGEINHEIT_STUFE_1_ELF).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.UndeadBase).Run(7.5f);

      // Kasernen
      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToCenter);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.OrcBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF).Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.OrcBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ELF).Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToHuman);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.HumanBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF).Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.HumanBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ELF).Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToUndead);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.UndeadBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF).Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.UndeadBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ELF).Run(0.5f);
    }

    private static void ConstructUndeadBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Undeads.Computer.CreateBuilding(Constants.UNIT_SCHWARZE_ZITADELLE_UNDEAD, Areas.UndeadBase);
      building.RegisterOnDies(BuildingMain.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.HumanBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_FLUGEINHEIT_STUFE_1_UNDEAD).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.HumanBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.ElfBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_FLUGEINHEIT_STUFE_1_UNDEAD).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.ElfBase).Run(7.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.UnitClass.Distance, MainBuilding1SpawnTime, Areas.OrcBase,
        Constants.UNIT_MAGIEEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_FLUGEINHEIT_STUFE_1_UNDEAD).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.UnitClass.Artillery, MainBuilding2SpawnTime, Areas.OrcBase).Run(7.5f);

      // Kasernen
      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToCenter);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.HumanBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD).Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.HumanBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_UNDEAD).Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToElf);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.ElfBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD).Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.ElfBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_UNDEAD).Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToOrcs);
      building.RegisterOnDies(BuildingBarracks.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.UnitClass.Meelee, BarracksSpawnTime, Areas.OrcBase,
        Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD).Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.UnitClass.Distance, BarracksSpawnTime, Areas.OrcBase,
        Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_UNDEAD).Run(0.5f);
    }

    private static void CreateComputerHeros()
    {
      Humans.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.HumanBaseToElfSpawn).AttackMove(Areas.ElfBase);
      Humans.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.HumanBaseToCenterSpawn).AttackMove(Areas.UndeadBase);
      Humans.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.HumanBaseToOrcsSpawn).AttackMove(Areas.OrcBase);

      Orcs.Computer.CreateUnit(Constants.UNIT_W_CHTER_ORC, Areas.OrcBaseToCenterSpawn).AttackMove(Areas.ElfBase);
      Orcs.Computer.CreateUnit(Constants.UNIT_W_CHTER_ORC, Areas.OrcBaseToUndeadSpawn).AttackMove(Areas.UndeadBase);
      Orcs.Computer.CreateUnit(Constants.UNIT_W_CHTER_ORC, Areas.OrcBaseToHumanSpawn).AttackMove(Areas.HumanBase);

      Elves.Computer.CreateUnit(Constants.UNIT_W_CHTER_ELF, Areas.ElfBaseToHumanSpawn).AttackMove(Areas.HumanBase);
      Elves.Computer.CreateUnit(Constants.UNIT_W_CHTER_ELF, Areas.ElfBaseToUndeadSpawn).AttackMove(Areas.UndeadBase);
      Elves.Computer.CreateUnit(Constants.UNIT_W_CHTER_ELF, Areas.ElfBaseToCenterSpawn).AttackMove(Areas.OrcBase);

      Undeads.Computer.CreateUnit(Constants.UNIT_W_CHTER_UNDEAD, Areas.UndeadBaseToElfSpawn).AttackMove(Areas.ElfBase);
      Undeads.Computer.CreateUnit(Constants.UNIT_W_CHTER_UNDEAD, Areas.UndeadBaseToCenterSpawn).AttackMove(Areas.HumanBase);
      Undeads.Computer.CreateUnit(Constants.UNIT_W_CHTER_UNDEAD, Areas.UndeadBaseToOrcsSpawn).AttackMove(Areas.OrcBase);
    }

    internal static void CreateHeroSelectorForPlayerAndAdjustCamera(UserPlayer user)
    {
      SpawnedUnit unit = user.CreateUnit(Constants.UNIT_HELDENSEELE_HERO_SELECTOR, Areas.HeroSelectorSpawn);
      user.ApplyCamera(Areas.HeroSelectorSpawn);

      Blizzard.SelectUnitForPlayerSingle(unit.Wc3Unit, user.Wc3Player);
    }
  }
}

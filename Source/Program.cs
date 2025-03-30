using Source.Handler.Generic;
using Source.Handler.GenericEvents;
using Source.Handler.Periodic;
using Source.Handler.Region;
using Source.Handler.Specific;
using Source.Models;
using Source.UnitEvents;
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

    public static Team Humans;
    public static Team Orcs;
    public static Team Elves;
    public static Team Undeads;

    public static Fragtion Slappers;

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
        Humans = new Team(Common.Player(0));
        Orcs = new Team(Common.Player(4));
        Elves = new Team(Common.Player(8));
        Undeads = new Team(Common.Player(12));

        Slappers = new Fragtion(player.NeutralAggressive);

        // Regions-Ereignisse registrieren für automatische Einheitenbewegungen
        RegisterRegionTriggersInHumanArea();
        RegisterRegionTriggerInOrcArea();
        RegisterRegionTriggerInElfArea();
        RegisterRegionTriggerInUndeadArea();

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.BuysUnit, UserHero.OnBuyed);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, Research.OnFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.SellsItem, Item.OnSellsFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, Unit.OnDies);
        PlayerUnitEvents.Register(UnitTypeEvent.ReceivesOrder, Unit.OnReceivesOrder);
        PlayerUnitEvents.Register(UnitTypeEvent.SpellEffect, Ability.OnCasted);

        // Periodische Events registrieren
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);
        PeriodicEvents.AddPeriodicEvent(Slapping.OnElapsed, KlatschenInterval);
        PeriodicEvents.AddPeriodicEvent(ResearchCheckHumans.OnElapsed, 5f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        ConstructElfBuildingAndTrigger();
        ConstructUndeadBuildingAndTrigger();

        // Spezifische Events registrieren
        Console.WriteLine("Kämpft bis zum Tod!");

        // Für alle Benutzer-Spieler einen Hero-Selector generieren
        force force = Blizzard.GetPlayersByMapControl(mapcontrol.User);
        foreach (UserPlayer user in AllActiveUsers)
        {
          CreateHeroSelectorForPlayerAndAdjustCamera(user);
        }

#if DEBUG
        Common.FogEnable(false);
        Common.FogMaskEnable(false);
#endif

        var timer = Common.CreateTimer();
        Common.TimerStart(timer, 5f, false, () =>
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
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.UndeadBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.UndeadBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.ElfBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.ElfBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.OrcBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.OrcBase).Run(5.5f);

      // Kasernen
      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToElf);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToOrcs);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.OrcBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.OrcBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(1f);
    }

    private static void ConstructOrcBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_FESTUNG_ORC, Areas.OrcBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.ElfBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.ElfBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.HumanBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.HumanBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.UndeadBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.UndeadBase).Run(5.5f);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToHuman);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToUndead);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);
    }

    private static void ConstructElfBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_TELDRASSIL_ELF, Areas.ElfBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.OrcBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.OrcBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.HumanBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.HumanBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.UndeadBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.UndeadBase).Run(5.5f);

      // Kasernen
      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.OrcBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.OrcBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToHuman);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToUndead);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);
    }

    private static void ConstructUndeadBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Undeads.Computer.CreateBuilding(Constants.UNIT_SCHWARZE_ZITADELLE_UNDEAD, Areas.UndeadBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.HumanBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.HumanBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.ElfBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.ElfBase).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.UnitSpawnType.Distance, MainBuilding1SpawnTime, Areas.OrcBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN, Constants.UNIT_REITER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.UnitSpawnType.Artillery, MainBuilding2SpawnTime, Areas.OrcBase).Run(5.5f);

      // Kasernen
      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToElf);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToOrcs);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.OrcBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.OrcBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);
    }

    private static void CreateComputerHeros()
    {
      Humans.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.HumanBaseHeroSpawn).AttackMove(Areas.ElfBase);
      Humans.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.HumanBaseHeroSpawn).AttackMove(Areas.UndeadBase);
      Humans.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.HumanBaseHeroSpawn).AttackMove(Areas.OrcBase);

      Orcs.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.OrcBaseHeroSpawn).AttackMove(Areas.ElfBase);
      Orcs.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.OrcBaseHeroSpawn).AttackMove(Areas.UndeadBase);
      Orcs.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.OrcBaseHeroSpawn).AttackMove(Areas.HumanBase);

      Elves.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.ElfBaseHeroSpawn).AttackMove(Areas.HumanBase);
      Elves.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.ElfBaseHeroSpawn).AttackMove(Areas.UndeadBase);
      Elves.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.ElfBaseHeroSpawn).AttackMove(Areas.OrcBase);

      Undeads.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.UndeadBaseHeroSpawn).AttackMove(Areas.ElfBase);
      Undeads.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.UndeadBaseHeroSpawn).AttackMove(Areas.HumanBase);
      Undeads.Computer.CreateUnit(Constants.UNIT_W_CHTER_HUMAN, Areas.UndeadBaseHeroSpawn).AttackMove(Areas.OrcBase);
    }

    internal static void CreateHeroSelectorForPlayerAndAdjustCamera(UserPlayer user)
    {
      SpawnedUnit unit = user.CreateUnit(Constants.UNIT_HELDENSEELE_HERO_SELECTOR, Areas.HeroSelectorSpawn);
      user.ApplyCamera(Areas.HeroSelectorSpawn);

      Blizzard.SelectUnitForPlayerSingle(unit.Wc3Unit, user.Wc3Player);
    }
  }
}

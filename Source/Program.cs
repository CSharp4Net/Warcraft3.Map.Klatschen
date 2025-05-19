using Source.Abstracts;
using Source.Events;
using Source.Events.Buildings;
using Source.Events.Periodic;
using Source.Events.Region;
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

    public static HumanTeam Humans;
    public static OrcTeam Orcs;
    public static ElfTeam Elves;
    public static UndeadTeam Undeads;

    public static KlatschenFragtion Legion;

    public static List<CreepCamp> CreepCamps { get; set; } = new List<CreepCamp>();

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
        Humans = new HumanTeam(Common.Player(0), Areas.HumanBase);
        Orcs = new OrcTeam(Common.Player(4), Areas.OrcBase);
        Elves = new ElfTeam(Common.Player(8), Areas.ElfBase);
        Undeads = new UndeadTeam(Common.Player(12), Areas.UndeadBase);

        Legion = new KlatschenFragtion();

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
        PeriodicEvents.AddPeriodicEvent(Klatschen.OnElapsed, ConstantsEx.Interval_Event_Klatschen);
        PeriodicEvents.AddPeriodicEvent(ResearchCheck.OnElapsed, 10f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        ConstructElfBuildingAndTrigger();
        ConstructUndeadBuildingAndTrigger();

        ConstructCreepCamps();

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

        var timer = Common.CreateTimer();
        Common.TimerStart(timer, 30f, false, () =>
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

    public static bool TryGetCreepCampByBuilding(unit buildingUnit, out CreepCamp creepCamp)
    {
      for (int i = CreepCamps.Count - 1; i >= 0; i--)
      {
        if (CreepCamps[i].Building.Wc3Unit == buildingUnit)
        {
          creepCamp = CreepCamps[i];
          return true;
        }
      }

      creepCamp = null;
      return false;
    }

    public static bool TryGetCreepCampByHero(unit heroUnit, out CreepCamp creepCamp)
    {
      for (int i = CreepCamps.Count - 1; i >= 0; i--)
      {
        if (CreepCamps[i].Hero.Wc3Unit == heroUnit)
        {
          creepCamp = CreepCamps[i];
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
      SpawnUnitsBuilding building = Humans.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.HumanBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_HUMAN, Constants.UNIT_FLUGEINHEIT_STUFE_1_HUMAN)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.UndeadBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_HUMAN, Constants.UNIT_FLUGEINHEIT_STUFE_1_HUMAN)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.SpawnInterval.Long, Areas.ElfBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.SpawnInterval.Long, Areas.OrcBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_HUMAN, Constants.UNIT_FLUGEINHEIT_STUFE_1_HUMAN)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.SpawnInterval.Long, Areas.OrcBase)
        .Run(7.5f);

      // Kasernen
      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.UndeadBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN)
        .Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_HUMAN)
        .Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToElf);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.SpawnInterval.Short, Areas.ElfBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN)
        .Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_HUMAN)
        .Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToOrcs);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.SpawnInterval.Short, Areas.OrcBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_HUMAN)
        .Run();
      building.AddSpawnTrigger(Areas.HumanBarracksToOrcsSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_HUMAN)
        .Run(1f);
    }

    private static void ConstructOrcBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnUnitsBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_FESTUNG_ORC, Areas.OrcBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_ORC, Constants.UNIT_FLUGEINHEIT_STUFE_1_ORC)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.ElfBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_ORC, Constants.UNIT_FLUGEINHEIT_STUFE_1_ORC)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.SpawnInterval.Long, Areas.HumanBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_ORC, Constants.UNIT_FLUGEINHEIT_STUFE_1_ORC)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.SpawnInterval.Long, Areas.UndeadBase)
        .Run(7.5f);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.ElfBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC)
        .Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ORC)
        .Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToHuman);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.SpawnInterval.Short, Areas.HumanBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC)
        .Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ORC)
        .Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToUndead);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.SpawnInterval.Short, Areas.UndeadBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ORC)
        .Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ORC)
        .Run(0.5f);
    }

    private static void ConstructElfBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnUnitsBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_TELDRASSIL_ELF, Areas.ElfBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_ELF, Constants.UNIT_FLUGEINHEIT_STUFE_1_ELF)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.OrcBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_ELF, Constants.UNIT_FLUGEINHEIT_STUFE_1_ELF)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToHumanSpawn, Enums.SpawnInterval.Long, Areas.HumanBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_ELF, Constants.UNIT_FLUGEINHEIT_STUFE_1_ELF)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.ElfBaseToUndeadSpawn, Enums.SpawnInterval.Long, Areas.UndeadBase)
        .Run(7.5f);

      // Kasernen
      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.OrcBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF)
        .Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ELF)
        .Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToHuman);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.SpawnInterval.Short, Areas.HumanBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF)
        .Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToHumanSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ELF)
        .Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_ELF, Areas.ElfBarracksToUndead);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.SpawnInterval.Short, Areas.UndeadBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_ELF)
        .Run();
      building.AddSpawnTrigger(Areas.ElfBarracksToUndeadSpawn, Enums.SpawnInterval.Middle, Areas.UndeadBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_ELF)
        .Run(0.5f);
    }

    private static void ConstructUndeadBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnUnitsBuilding building = Undeads.Computer.CreateBuilding(Constants.UNIT_SCHWARZE_ZITADELLE_UNDEAD, Areas.UndeadBase);
      building.RegisterOnDies(TeamMainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_FLUGEINHEIT_STUFE_1_UNDEAD)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToCenterSpawn, Enums.SpawnInterval.Long, Areas.HumanBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_FLUGEINHEIT_STUFE_1_UNDEAD)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToElfSpawn, Enums.SpawnInterval.Long, Areas.ElfBase)
        .Run(7.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_MAGIEEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_FLUGEINHEIT_STUFE_1_UNDEAD)
        .Run(5.5f);
      building.AddSpawnTrigger(Areas.UndeadBaseToOrcsSpawn, Enums.SpawnInterval.Long, Areas.OrcBase)
        .Run(7.5f);

      // Kasernen
      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToCenter);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.SpawnInterval.Short, Areas.HumanBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD)
        .Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToCenterSpawn, Enums.SpawnInterval.Middle, Areas.HumanBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_UNDEAD)
        .Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToElf);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.SpawnInterval.Short, Areas.ElfBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD)
        .Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToElfSpawn, Enums.SpawnInterval.Middle, Areas.ElfBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_UNDEAD)
        .Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToOrcs);
      building.RegisterOnDies(TeamBarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.SpawnInterval.Short, Areas.OrcBase, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD, Constants.UNIT_NAHKAMPFEINHEIT_STUFE_1_UNDEAD)
        .Run();
      building.AddSpawnTrigger(Areas.UndeadBarracksToOrcsSpawn, Enums.SpawnInterval.Middle, Areas.OrcBase, Constants.UNIT_FERNKAMPFEINHEIT_STUFE_1_UNDEAD)
        .Run(0.5f);
    }

    private static void ConstructCreepCamps()
    {
      // Menschen-Creeps
      ConstructCreepCamp("Banditen", Constants.UNIT_BANDITENLAGER_CREEP, Areas.HumanCreepToElfSpawnBuilding, Areas.HumanCreepToElfSpawn, Humans, Elves);
      ConstructCreepCamp("Tuskarr", Constants.UNIT_TUSKARRLAGER_CREEP, Areas.HumanCreepToOrcSpawnBuilding, Areas.HumanCreepToOrcSpawn, Humans, Orcs);

      // Elfen-Creeps
      ConstructCreepCamp("Furbolgs", Constants.UNIT_FURBOLGLAGER_CREEP, Areas.ElfCreepToHumanSpawnBuilding, Areas.ElfCreepToHumanSpawn, Elves, Humans);
      ConstructCreepCamp("Wildekins", Constants.UNIT_WILDEKINLAGER_CREEP, Areas.ElfCreepToUndeadSpawnBuilding, Areas.ElfCreepToUndeadSpawn, Elves, Undeads);

      // Orcs-Creeps
      ConstructCreepCamp("Zentauren", Constants.UNIT_ZENTAURENLAGER_CREEP, Areas.OrcCreepToHumanSpawnBuilding, Areas.OrcCreepToHumanSpawn, Orcs, Humans);
      ConstructCreepCamp("Oger", Constants.UNIT_OGERLAGER_CREEP, Areas.OrcCreepToUndeadSpawnBuilding, Areas.OrcCreepToUndeadSpawn, Orcs, Undeads);

      // Untoten-Creeps
      ConstructCreepCamp("Mur'guls", Constants.UNIT_MUR_GULLAGER_CREEP, Areas.UndeadCreepToOrcSpawnBuilding, Areas.UndeadCreepToOrcSpawn, Undeads, Orcs);
      ConstructCreepCamp("Neruber", Constants.UNIT_NERUBERLAGER_CREEP, Areas.UndeadCreepToElfSpawnBuilding, Areas.UndeadCreepToElfSpawn, Undeads, Elves);
    }

    private static void ConstructCreepCamp(string name, int buildingUniType, Area buildingArea, Area spawnArea, TeamBase nearestTeam, TeamBase opposingTeam)
    {
      CreepCamp creepCamp = new CreepCamp(name, buildingArea, spawnArea, nearestTeam, opposingTeam);
      SpawnCreepsBuilding building = creepCamp.InitializeBuilding(buildingUniType);
      CreepCamps.Add(creepCamp);
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

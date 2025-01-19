using Source.Extensions;
using Source.Models;
using Source.PermanentEvents;
using Source.RegionEvents;
using Source.UnitEvents;
using System;
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

    private static void Start()
    {
      try
      {
#if DEBUG
        // This part of the code will only run if the map is compiled in Debug mode
        Debug = true;
        Console.WriteLine("This map is in debug mode. The map may not function as expected.");
        // By calling these methods, whenever these systems call external code (i.e. your code),
        // they will wrap the call in a try-catch and output any errors to the chat for easier debugging
        PeriodicEvents.EnableDebug();
        PlayerUnitEvents.EnableDebug();
        SyncSystem.EnableDebug();
        Delay.EnableDebug();
#endif

        // Teams initialisieren
        Humans = new Team(Common.Player(3));
        Orcs = new Team(Common.Player(7));
        Elves = new Team(Common.Player(11));

        // TODO: Trigger-Gebäude für Computer-Spieler erstellen
        Humans.Computer.CreateBuilding(Constants.UNIT_RATHAUS_HUMAN, Areas.WestBase)
          .RegisterOnDies(MainBuilding.OnDies);

        Orcs.Computer.CreateBuilding(Constants.UNIT_HAUPTHAUS_ORC, Areas.EastBase)
          .RegisterOnDies(MainBuilding.OnDies);

        Elves.Computer.CreateBuilding(Constants.UNIT_BAUM_DES_LEBENS_ELF, Areas.SouthBase)
          .RegisterOnDies(MainBuilding.OnDies);

#if DEBUG
        Common.FogEnable(false);
        Common.FogMaskEnable(false);

        //timer timer = Common.CreateTimer();
        //timer.Start(5f, true, CreateFootmans);
#endif

        // Regions-Ereignisse registrieren für automatische Einheitenbewegungen
        Regions.Center.Region.RegisterOnEnter(CenterRegion.OnEnter);
        Regions.WestBase.Region.RegisterOnEnter(WestBaseRegion.OnEnter);
        Regions.EastBase.Region.RegisterOnEnter(EastBaseRegion.OnEnter);
        Regions.SouthBase.Region.RegisterOnEnter(SouthBaseRegion.OnEnter);

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, OnResearchFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, ComputerUnit.OnUnitDies);
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);

        // Spezifische Events registrieren
        Humans.Computer.AddSpawnTrigger(3, Areas.WestBase, Constants.UNIT_TESTSOLDIER, Constants.UNIT_TESTSOLDIER, Constants.UNIT_TESTSOLDIER);

        Console.WriteLine("Kämpft bis zum Tod!");
      }
      catch (Exception ex)
      {
        Common.DisplayTextToPlayer(Common.GetLocalPlayer(), 0, 0, ex.Message);
      }
    }



    private static void CreateFootmans()
    {
      try
      {
        Humans.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.WestSpawnTop, 0f).AttackMove(Regions.EastBase);
        Humans.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.WestSpawnMiddle, 0f).AttackMove(Regions.Center);
        Humans.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.WestSpawnBottom, 0f).AttackMove(Regions.SouthBase);

        Orcs.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.EastSpawnTop, 90f).AttackMove(Regions.WestBase);
        Orcs.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.EastSpawnMiddle, 90f).AttackMove(Regions.Center);
        Orcs.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.EastSpawnBottom, 90f).AttackMove(Regions.SouthBase);

        Elves.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.SouthSpawnLeft, 45f).AttackMove(Regions.WestBase);
        Elves.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.SouthSpawnMiddle, 45f).AttackMove(Regions.Center);
        Elves.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.SouthSpawnRight, 45f).AttackMove(Regions.EastBase);
      }
      catch (Exception ex)
      {
        Common.DisplayTextToPlayer(Common.GetLocalPlayer(), 0, 0, ex.Message);
      }
    }

    static void OnResearchFinished()
    {
      Console.WriteLine("Forschung abgeschlossen!");
      unit unit = Common.GetResearchingUnit();
      int researchedTechId = Common.GetResearched();
    }
  }
}

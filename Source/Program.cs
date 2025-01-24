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
    public static Team Undeads;

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
        Undeads = new Team(Common.Player(15));

        // Regions-Ereignisse registrieren für automatische Einheitenbewegungen
        Areas.Center.RegisterOnEnter(CenterRegion.OnEnter);

        RegisterRegionTriggerWestBase();
        RegisterRegionTriggerEastBase();
        RegisterRegionTriggerSouthBase();

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, OnResearchFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, GenericUnit.OnUnitDies);
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        ConstructElfBuildingAndTrigger();

        // Spezifische Events registrieren
        Console.WriteLine("Kämpft bis zum Tod!");

#if DEBUG
        Common.FogEnable(false);
        Common.FogMaskEnable(false);
#endif

        // Alle Spieler der Streitmacht vom Computer-Spiler abrufen
        force force = Blizzard.GetPlayersByMapControl(mapcontrol.User);
        force.ForEach(() =>
        {
          player player = Common.GetEnumPlayer();

          // TODO
        });
      }
      catch (Exception ex)
      {
        Common.DisplayTextToPlayer(Common.GetLocalPlayer(), 0, 0, ex.Message);
      }
    }

    private static void RegisterRegionTriggerWestBase()
    {
      Areas.WestBase.RegisterOnEnter(WestBaseRegion.OnEnter);
      Areas.WestBarracksBottom.RegisterOnEnter(WestBarracksRegions.OnEnter);
      Areas.WestBarracksMiddle.RegisterOnEnter(WestBarracksRegions.OnEnter);
      Areas.WestBarracksTop.RegisterOnEnter(WestBarracksRegions.OnEnter);

      Areas.WestSpawnBottom.RegisterOnEnter(WestSpawnBottomRegion.OnEnter);
      Areas.WestSpawnBarracksBottom.RegisterOnEnter(WestSpawnBottomRegion.OnEnter);
      Areas.WestSpawnMiddle.RegisterOnEnter(WestSpawnMiddleRegion.OnEnter);
      Areas.WestSpawnBarracksMiddle.RegisterOnEnter(WestSpawnMiddleRegion.OnEnter);
      Areas.WestSpawnTop.RegisterOnEnter(WestSpawnTopRegion.OnEnter);
      Areas.WestSpawnBarracksTop.RegisterOnEnter(WestSpawnTopRegion.OnEnter);
    }
    private static void RegisterRegionTriggerEastBase()
    {

      Areas.EastBase.RegisterOnEnter(EastBaseRegion.OnEnter);
      Areas.EastBarracksBottom.RegisterOnEnter(EastBarracksRegions.OnEnter);
      Areas.EastBarracksMiddle.RegisterOnEnter(EastBarracksRegions.OnEnter);
      Areas.EastBarracksTop.RegisterOnEnter(EastBarracksRegions.OnEnter);

      Areas.EastSpawnBottom.RegisterOnEnter(EastSpawnBottomRegion.OnEnter);
      Areas.EastSpawnBarracksBottom.RegisterOnEnter(EastSpawnBottomRegion.OnEnter);
      Areas.EastSpawnMiddle.RegisterOnEnter(EastSpawnMiddleRegion.OnEnter);
      Areas.EastSpawnBarracksMiddle.RegisterOnEnter(EastSpawnMiddleRegion.OnEnter);
      Areas.EastSpawnTop.RegisterOnEnter(EastSpawnTopRegion.OnEnter);
      Areas.EastSpawnBarracksTop.RegisterOnEnter(EastSpawnTopRegion.OnEnter);

    }
    private static void RegisterRegionTriggerSouthBase()
    {
      Areas.SouthBase.RegisterOnEnter(SouthBaseRegion.OnEnter);
      Areas.SouthBarracksLeft.RegisterOnEnter(SouthBarracksRegions.OnEnter);
      Areas.SouthBarracksMiddle.RegisterOnEnter(SouthBarracksRegions.OnEnter);
      Areas.SouthBarracksRight.RegisterOnEnter(SouthBarracksRegions.OnEnter);
            
      Areas.SouthSpawnLeft.RegisterOnEnter(SouthSpawnLeftRegion.OnEnter);
      Areas.SouthSpawnBarracksLeft.RegisterOnEnter(SouthSpawnLeftRegion.OnEnter);
      Areas.SouthSpawnMiddle.RegisterOnEnter(SouthSpawnMiddleRegion.OnEnter);
      Areas.SouthSpawnBarracksMiddle.RegisterOnEnter(SouthSpawnMiddleRegion.OnEnter);
      Areas.SouthSpawnRight.RegisterOnEnter(SouthSpawnRightRegion.OnEnter);
      Areas.SouthSpawnBarracksRight.RegisterOnEnter(SouthSpawnRightRegion.OnEnter);
    }

    private static void ConstructHumanBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Humans.Computer.CreateBuilding(Constants.UNIT_RATHAUS_HUMAN, Areas.WestBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(15, Areas.WestSpawnBottom, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(15, Areas.WestSpawnMiddle, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(15, Areas.WestSpawnTop, Constants.UNIT_TESTSOLDIER);

      // Kasernen
      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.WestBarracksBottom);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.WestSpawnBarracksBottom, Constants.UNIT_TESTSOLDIER);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.WestBarracksMiddle);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.WestSpawnBarracksMiddle, Constants.UNIT_TESTSOLDIER);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.WestBarracksTop);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.WestSpawnBarracksTop, Constants.UNIT_TESTSOLDIER);
    }

    private static void ConstructOrcBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_HAUPTHAUS_ORC, Areas.EastBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(15, Areas.EastSpawnBottom, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(15, Areas.EastSpawnMiddle, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(15, Areas.EastSpawnTop, Constants.UNIT_TESTSOLDIER);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.EastBarracksBottom);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.EastSpawnBarracksBottom, Constants.UNIT_TESTSOLDIER);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.EastBarracksMiddle);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.EastSpawnBarracksMiddle, Constants.UNIT_TESTSOLDIER);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.EastBarracksTop);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.EastSpawnBarracksTop, Constants.UNIT_TESTSOLDIER);
    }

    private static void ConstructElfBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_BAUM_DES_LEBENS_ELF, Areas.SouthBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(15, Areas.SouthSpawnLeft, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(15, Areas.SouthSpawnMiddle, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(15, Areas.SouthSpawnRight, Constants.UNIT_TESTSOLDIER);

      // Kasernen
      building = Elves.Computer.CreateBuilding(Constants.UNIT_URTUM_DES_KRIEGES_ELF, Areas.SouthBarracksLeft);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.SouthSpawnBarracksLeft, Constants.UNIT_TESTSOLDIER);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_URTUM_DES_KRIEGES_ELF, Areas.SouthBarracksMiddle);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.SouthSpawnBarracksMiddle, Constants.UNIT_TESTSOLDIER);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_URTUM_DES_KRIEGES_ELF, Areas.SouthBarracksRight);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.SouthSpawnBarracksRight, Constants.UNIT_TESTSOLDIER);
    }

    static void OnResearchFinished()
    {
      Console.WriteLine("Forschung abgeschlossen!");
      unit unit = Common.GetResearchingUnit();
      int researchedTechId = Common.GetResearched();
    }
  }
}

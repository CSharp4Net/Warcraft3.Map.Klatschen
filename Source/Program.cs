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

        RegisterRegionTriggersInHumanArea();
        RegisterRegionTriggerInOrcArea();
        RegisterRegionTriggerInElfArea();
        RegisterRegionTriggerInUndeadArea();

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, OnResearchFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, GenericUnit.OnUnitDies);
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        ConstructElfBuildingAndTrigger();
        ConstructUndeadBuildingAndTrigger();

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

    private static void RegisterRegionTriggersInHumanArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.HumanBase.RegisterOnEnter(HumanBase.OnEnter);
      Areas.HumanBarracksToCenter.RegisterOnEnter(HumanBarracksRegions.OnEnter);
      Areas.HumanBarracksToElf.RegisterOnEnter(HumanBarracksRegions.OnEnter);
      Areas.HumanBarracksToOrcs.RegisterOnEnter(HumanBarracksRegions.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten/gespawnt werden
      Areas.HumanBaseToCenterSpawn.RegisterOnEnter(HumanSpawnToCenter.OnEnter);
      Areas.HumanBarracksToCenterSpawn.RegisterOnEnter(HumanSpawnToCenter.OnEnter);
      Areas.HumanBaseToElfSpawn.RegisterOnEnter(HumanSpawnToElf.OnEnter);
      Areas.HumanBarracksToElfSpawn.RegisterOnEnter(HumanSpawnToElf.OnEnter);
      Areas.HumanBaseToOrcsSpawn.RegisterOnEnter(HumanSpawnToOrc.OnEnter);
      Areas.HumanBarracksToOrcsSpawn.RegisterOnEnter(HumanSpawnToOrc.OnEnter);
    }
    private static void RegisterRegionTriggerInOrcArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.OrcBase.RegisterOnEnter(OrcBase.OnEnter);
      Areas.OrcBarracksToCenter.RegisterOnEnter(OrcBarracks.OnEnter);
      Areas.OrcBarracksToHuman.RegisterOnEnter(OrcBarracks.OnEnter);
      Areas.OrcBarracksToUndead.RegisterOnEnter(OrcBarracks.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten/gespawnt werden
      Areas.OrcBaseToCenterSpawn.RegisterOnEnter(OrcSpawnToCenter.OnEnter);
      Areas.OrcBarracksToCenterSpawn.RegisterOnEnter(OrcSpawnToCenter.OnEnter);
      Areas.OrcBaseToHumanSpawn.RegisterOnEnter(OrcSpawnToHuman.OnEnter);
      Areas.OrcBarracksToHumanSpawn.RegisterOnEnter(OrcSpawnToHuman.OnEnter);
      Areas.OrcBaseToUndeadSpawn.RegisterOnEnter(OrcSpawnToUndead.OnEnter);
      Areas.OrcBarracksToUndeadSpawn.RegisterOnEnter(OrcSpawnToUndead.OnEnter);

    }
    private static void RegisterRegionTriggerInElfArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.ElfBase.RegisterOnEnter(ElfBase.OnEnter);
      Areas.ElfBarracksToCenter.RegisterOnEnter(ElfBarracks.OnEnter);
      Areas.ElfBarracksToHuman.RegisterOnEnter(ElfBarracks.OnEnter);
      Areas.ElfBarracksToUndead.RegisterOnEnter(ElfBarracks.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten / gespawnt werden
      Areas.ElfBaseToCenterSpawn.RegisterOnEnter(ElfSpawnToCenter.OnEnter);
      Areas.ElfBarracksToCenterSpawn.RegisterOnEnter(ElfSpawnToCenter.OnEnter);
      Areas.ElfBaseToHumanSpawn.RegisterOnEnter(ElfSpawnToHuman.OnEnter);
      Areas.ElfBarracksToHumanSpawn.RegisterOnEnter(ElfSpawnToHuman.OnEnter);
      Areas.ElfBaseToUndeadSpawn.RegisterOnEnter(ElfSpawnToUndead.OnEnter);
      Areas.ElfBarracksToUndeadSpawn.RegisterOnEnter(ElfSpawnToUndead.OnEnter);
    }
    private static void RegisterRegionTriggerInUndeadArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.UndeadBase.RegisterOnEnter(UndeadBase.OnEnter);
      Areas.UndeadBarracksToCenter.RegisterOnEnter(UndeadBarracks.OnEnter);
      Areas.UndeadBarracksToElf.RegisterOnEnter(UndeadBarracks.OnEnter);
      Areas.UndeadBarracksToOrcs.RegisterOnEnter(UndeadBarracks.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten/gespawnt werden
      Areas.UndeadBaseToCenterSpawn.RegisterOnEnter(UndeadSpawnToCenter.OnEnter);
      Areas.UndeadBarracksToCenterSpawn.RegisterOnEnter(UndeadSpawnToCenter.OnEnter);
      Areas.UndeadBaseToElfSpawn.RegisterOnEnter(UndeadSpawnToElf.OnEnter);
      Areas.UndeadBarracksToElfSpawn.RegisterOnEnter(UndeadSpawnToElf.OnEnter);
      Areas.UndeadBaseToOrcsSpawn.RegisterOnEnter(UndeadSpawnToOrc.OnEnter);
      Areas.UndeadBarracksToOrcsSpawn.RegisterOnEnter(UndeadSpawnToOrc.OnEnter);
    }

    private static void ConstructHumanBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Humans.Computer.CreateBuilding(Constants.UNIT_RATHAUS_HUMAN, Areas.HumanBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(20, Areas.HumanBaseToCenterSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.HumanBaseToElfSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.HumanBaseToOrcsSpawn, Constants.UNIT_TESTSOLDIER);

      // Kasernen
      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.HumanBarracksToCenterSpawn, Constants.UNIT_TESTSOLDIER);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToElf);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.HumanBarracksToElfSpawn, Constants.UNIT_TESTSOLDIER);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToOrcs);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.HumanBarracksToOrcsSpawn, Constants.UNIT_TESTSOLDIER);
    }

    private static void ConstructOrcBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_HAUPTHAUS_ORC, Areas.OrcBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(20, Areas.OrcBaseToCenterSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.OrcBaseToHumanSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.OrcBaseToUndeadSpawn, Constants.UNIT_TESTSOLDIER);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.OrcBarracksToCenterSpawn, Constants.UNIT_TESTSOLDIER);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToHuman);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.OrcBarracksToHumanSpawn, Constants.UNIT_TESTSOLDIER);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_ORC, Areas.OrcBarracksToUndead);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.OrcBarracksToUndeadSpawn, Constants.UNIT_TESTSOLDIER);
    }

    private static void ConstructElfBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_BAUM_DES_LEBENS_ELF, Areas.ElfBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(20, Areas.ElfBaseToCenterSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.ElfBaseToHumanSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.ElfBaseToUndeadSpawn, Constants.UNIT_TESTSOLDIER);

      // Kasernen
      building = Elves.Computer.CreateBuilding(Constants.UNIT_URTUM_DES_KRIEGES_ELF, Areas.ElfBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.ElfBarracksToCenterSpawn, Constants.UNIT_TESTSOLDIER);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_URTUM_DES_KRIEGES_ELF, Areas.ElfBarracksToHuman);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.ElfBarracksToHumanSpawn, Constants.UNIT_TESTSOLDIER);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_URTUM_DES_KRIEGES_ELF, Areas.ElfBarracksToUndead);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.ElfBarracksToUndeadSpawn, Constants.UNIT_TESTSOLDIER);
    }

    private static void ConstructUndeadBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Undeads.Computer.CreateBuilding(Constants.UNIT_NEKROPOLE_UNDEAD, Areas.UndeadBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(20, Areas.UndeadBaseToCenterSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.UndeadBaseToElfSpawn, Constants.UNIT_TESTSOLDIER);
      building.AddSpawnTrigger(20, Areas.UndeadBaseToOrcsSpawn, Constants.UNIT_TESTSOLDIER);

      // Kasernen
      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.UndeadBarracksToCenterSpawn, Constants.UNIT_TESTSOLDIER);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToElf);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.UndeadBarracksToElfSpawn, Constants.UNIT_TESTSOLDIER);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_GRUFT_UNDEAD, Areas.UndeadBarracksToOrcs);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(10, Areas.UndeadBarracksToOrcsSpawn, Constants.UNIT_TESTSOLDIER);
    }

    static void OnResearchFinished()
    {
      Console.WriteLine("Forschung abgeschlossen!");
      unit unit = Common.GetResearchingUnit();
      int researchedTechId = Common.GetResearched();
    }
  }
}

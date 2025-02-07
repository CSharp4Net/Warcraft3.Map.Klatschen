using Source.Handler.GenericEvents;
using Source.Handler.Region;
using Source.Handler.Specific;
using Source.Models;
using Source.PermanentEvents;
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

    internal const int BarracksSpawnTime = 15;
    internal const int MainBuildingSpawnTime = 30;

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

        // Teams initialisieren
        Humans = new Team(Common.Player(0));
        Orcs = new Team(Common.Player(4));
        Elves = new Team(Common.Player(8));
        Undeads = new Team(Common.Player(12));

        // Regions-Ereignisse registrieren für automatische Einheitenbewegungen
        //Areas.Center.RegisterOnEnter(CenterRegion.OnEnter);

        RegisterRegionTriggersInHumanArea();
        RegisterRegionTriggerInOrcArea();
        RegisterRegionTriggerInElfArea();
        RegisterRegionTriggerInUndeadArea();

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.BuysUnit, UserHero.OnBuys);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, Research.OnFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.SellsItem, Item.OnSellsFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, Unit.OnDies);
        PlayerUnitEvents.Register(UnitTypeEvent.ReceivesOrder, Unit.OnReceivesOrder);

        // Periodische Events registrieren
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        //ConstructElfBuildingAndTrigger();
        //ConstructUndeadBuildingAndTrigger();

        // Spezifische Events registrieren
        Console.WriteLine("Kämpft bis zum Tod!");

        // Für alle Benutzer-Spieler einen Hero-Selector generieren
        force force = Blizzard.GetPlayersByMapControl(mapcontrol.User);
        force.ForEach(() =>
        {
          player player = Common.GetEnumPlayer();

          if (player.SlotState == playerslotstate.Playing)
          {
            // Leider funktioniert die Verknüpfung via || Operator nicht,
            // daher redundant hier den selben Command für das User-Objekt aufrufen
            if (Humans.ContainsPlayer(player, out UserPlayer user))
            {
              CreateHeroSelectorForPlayerAndAdjustCamera(user);
            }
            else if (Orcs.ContainsPlayer(player, out user))
            {
              CreateHeroSelectorForPlayerAndAdjustCamera(user);
            }
            else if (Elves.ContainsPlayer(player, out user))
            {
              CreateHeroSelectorForPlayerAndAdjustCamera(user);
            }
            else if (Undeads.ContainsPlayer(player, out user))
            {
              CreateHeroSelectorForPlayerAndAdjustCamera(user);
            }
          }
        });

#if DEBUG
        //Common.FogEnable(false);
        //Common.FogMaskEnable(false);
#endif
      }
      catch (Exception ex)
      {
        ShowExceptionMessage("Start.Exception", ex);
      }
    }

    private static void RegisterRegionTriggersInHumanArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.HumanBase.RegisterOnEnter(HumanBase.OnEnter);
      //Areas.HumanBarracksToCenter.RegisterOnEnter(HumanBarracksRegions.OnEnter);
      //Areas.HumanBarracksToElf.RegisterOnEnter(HumanBarracksRegions.OnEnter);
      //Areas.HumanBarracksToOrcs.RegisterOnEnter(HumanBarracksRegions.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten/gespawnt werden
      //Areas.HumanBaseToCenterSpawn.RegisterOnEnter(HumanSpawnToCenter.OnEnter);
      //Areas.HumanBarracksToCenterSpawn.RegisterOnEnter(HumanSpawnToCenter.OnEnter);
      //Areas.HumanBaseToElfSpawn.RegisterOnEnter(HumanSpawnToElf.OnEnter);
      //Areas.HumanBarracksToElfSpawn.RegisterOnEnter(HumanSpawnToElf.OnEnter);
      //Areas.HumanBaseToOrcsSpawn.RegisterOnEnter(HumanSpawnToOrc.OnEnter);
      //Areas.HumanBarracksToOrcsSpawn.RegisterOnEnter(HumanSpawnToOrc.OnEnter);
    }
    private static void RegisterRegionTriggerInOrcArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.OrcBase.RegisterOnEnter(OrcBase.OnEnter);
      //Areas.OrcBarracksToCenter.RegisterOnEnter(OrcBarracks.OnEnter);
      //Areas.OrcBarracksToHuman.RegisterOnEnter(OrcBarracks.OnEnter);
      //Areas.OrcBarracksToUndead.RegisterOnEnter(OrcBarracks.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten/gespawnt werden
      //Areas.OrcBaseToCenterSpawn.RegisterOnEnter(OrcSpawnToCenter.OnEnter);
      //Areas.OrcBarracksToCenterSpawn.RegisterOnEnter(OrcSpawnToCenter.OnEnter);
      //Areas.OrcBaseToHumanSpawn.RegisterOnEnter(OrcSpawnToHuman.OnEnter);
      //Areas.OrcBarracksToHumanSpawn.RegisterOnEnter(OrcSpawnToHuman.OnEnter);
      //Areas.OrcBaseToUndeadSpawn.RegisterOnEnter(OrcSpawnToUndead.OnEnter);
      //Areas.OrcBarracksToUndeadSpawn.RegisterOnEnter(OrcSpawnToUndead.OnEnter);

    }
    private static void RegisterRegionTriggerInElfArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.ElfBase.RegisterOnEnter(ElfBase.OnEnter);
      //Areas.ElfBarracksToCenter.RegisterOnEnter(ElfBarracks.OnEnter);
      //Areas.ElfBarracksToHuman.RegisterOnEnter(ElfBarracks.OnEnter);
      //Areas.ElfBarracksToUndead.RegisterOnEnter(ElfBarracks.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten / gespawnt werden
      //Areas.ElfBaseToCenterSpawn.RegisterOnEnter(ElfSpawnToCenter.OnEnter);
      //Areas.ElfBarracksToCenterSpawn.RegisterOnEnter(ElfSpawnToCenter.OnEnter);
      //Areas.ElfBaseToHumanSpawn.RegisterOnEnter(ElfSpawnToHuman.OnEnter);
      //Areas.ElfBarracksToHumanSpawn.RegisterOnEnter(ElfSpawnToHuman.OnEnter);
      //Areas.ElfBaseToUndeadSpawn.RegisterOnEnter(ElfSpawnToUndead.OnEnter);
      //Areas.ElfBarracksToUndeadSpawn.RegisterOnEnter(ElfSpawnToUndead.OnEnter);
    }
    private static void RegisterRegionTriggerInUndeadArea()
    {
      // Wenn feindliche Einheiten in die Regionen treten, welche von zerstörten Gebäuden freigegeben werden
      Areas.UndeadBase.RegisterOnEnter(UndeadBase.OnEnter);
      //Areas.UndeadBarracksToCenter.RegisterOnEnter(UndeadBarracks.OnEnter);
      //Areas.UndeadBarracksToElf.RegisterOnEnter(UndeadBarracks.OnEnter);
      //Areas.UndeadBarracksToOrcs.RegisterOnEnter(UndeadBarracks.OnEnter);

      // Wenn freundliche Einheiten in die Regionen treten/gespawnt werden
      //Areas.UndeadBaseToCenterSpawn.RegisterOnEnter(UndeadSpawnToCenter.OnEnter);
      //Areas.UndeadBarracksToCenterSpawn.RegisterOnEnter(UndeadSpawnToCenter.OnEnter);
      //Areas.UndeadBaseToElfSpawn.RegisterOnEnter(UndeadSpawnToElf.OnEnter);
      //Areas.UndeadBarracksToElfSpawn.RegisterOnEnter(UndeadSpawnToElf.OnEnter);
      //Areas.UndeadBaseToOrcsSpawn.RegisterOnEnter(UndeadSpawnToOrc.OnEnter);
      //Areas.UndeadBarracksToOrcsSpawn.RegisterOnEnter(UndeadSpawnToOrc.OnEnter);
    }

    private static void ConstructHumanBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnBuilding building = Humans.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.HumanBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.HumanBaseToCenterSpawn, Enums.UnitSpawnType.Distance, MainBuildingSpawnTime, Areas.UndeadBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToElfSpawn, Enums.UnitSpawnType.Distance, MainBuildingSpawnTime, Areas.ElfBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.HumanBaseToOrcsSpawn, Enums.UnitSpawnType.Distance, MainBuildingSpawnTime, Areas.OrcBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);

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
      SpawnBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.OrcBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBaseToCenterSpawn, Enums.UnitSpawnType.Distance, MainBuildingSpawnTime, Areas.ElfBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToHumanSpawn, Enums.UnitSpawnType.Distance, MainBuildingSpawnTime, Areas.HumanBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(Areas.OrcBaseToUndeadSpawn, Enums.UnitSpawnType.Distance, MainBuildingSpawnTime, Areas.UndeadBase, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.OrcBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToCenterSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.ElfBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.OrcBarracksToHuman);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToHumanSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.HumanBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.OrcBarracksToUndead);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.UnitSpawnType.Meelee, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
      building.AddSpawnTrigger(Areas.OrcBarracksToUndeadSpawn, Enums.UnitSpawnType.Distance, BarracksSpawnTime, Areas.UndeadBase, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);
    }
    //private static void ConstructElfBuildingAndTrigger()
    //{
    //  // Hauptgebäude
    //  SpawnBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.ElfBase);
    //  building.RegisterOnDies(MainBuilding.OnDies);
    //  building.AddSpawnTrigger(MainBuildingSpawnTime, Areas.ElfBaseToCenterSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
    //  building.AddSpawnTrigger(MainBuildingSpawnTime, Areas.ElfBaseToHumanSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
    //  building.AddSpawnTrigger(MainBuildingSpawnTime, Areas.ElfBaseToUndeadSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);

    //  // Kasernen
    //  building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.ElfBarracksToCenter);
    //  building.RegisterOnDies(BarracksBuilding.OnDies);
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.ElfBarracksToCenterSpawn, Enums.UnitSpawnType.Meelee, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.ElfBarracksToCenterSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

    //  building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.ElfBarracksToHuman);
    //  building.RegisterOnDies(BarracksBuilding.OnDies);
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.ElfBarracksToHumanSpawn, Enums.UnitSpawnType.Meelee, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.ElfBarracksToHumanSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

    //  building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.ElfBarracksToUndead);
    //  building.RegisterOnDies(BarracksBuilding.OnDies);
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.ElfBarracksToUndeadSpawn, Enums.UnitSpawnType.Meelee, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.ElfBarracksToUndeadSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);
    //}
    //private static void ConstructUndeadBuildingAndTrigger()
    //{
    //  // Hauptgebäude
    //  SpawnBuilding building = Undeads.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.UndeadBase);
    //  building.RegisterOnDies(MainBuilding.OnDies);
    //  building.AddSpawnTrigger(MainBuildingSpawnTime, Areas.UndeadBaseToCenterSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
    //  building.AddSpawnTrigger(MainBuildingSpawnTime, Areas.UndeadBaseToElfSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);
    //  building.AddSpawnTrigger(MainBuildingSpawnTime, Areas.UndeadBaseToOrcsSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_MAGIER_STUFE_1_HUMAN).Run(5.5f);

    //  // Kasernen
    //  building = Undeads.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.UndeadBarracksToCenter);
    //  building.RegisterOnDies(BarracksBuilding.OnDies);
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.UndeadBarracksToCenterSpawn, Enums.UnitSpawnType.Meelee, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.UndeadBarracksToCenterSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

    //  building = Undeads.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.UndeadBarracksToElf);
    //  building.RegisterOnDies(BarracksBuilding.OnDies);
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.UndeadBarracksToElfSpawn, Enums.UnitSpawnType.Meelee, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.UndeadBarracksToElfSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);

    //  building = Undeads.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.UndeadBarracksToOrcs);
    //  building.RegisterOnDies(BarracksBuilding.OnDies);
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.UndeadBarracksToOrcsSpawn, Enums.UnitSpawnType.Meelee, Constants.UNIT_SOLDAT_STUFE_1_HUMAN, Constants.UNIT_SOLDAT_STUFE_1_HUMAN).Run();
    //  building.AddSpawnTrigger(BarracksSpawnTime, Areas.UndeadBarracksToOrcsSpawn, Enums.UnitSpawnType.Distance, Constants.UNIT_SCH_TZE_STUFE_1_HUMAN).Run(0.5f);
    //}

    private static void CreateHeroSelectorForPlayerAndAdjustCamera(UserPlayer user)
    {
      SpawnedUnit unit = user.CreateUnit(Constants.UNIT_HELDENSEELE_HERO_SELECTOR, Areas.HeroSelectorSpawn);
      user.ApplyCamera(Areas.HeroSelectorSpawn);

      Blizzard.SelectUnitForPlayerSingle(unit.Wc3Unit, user.Wc3Player);
    }
  }
}

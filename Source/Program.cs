using Source.Extensions;
using Source.Models;
using Source.PermanentEvents;
using Source.RegionEvents;
using Source.UnitEvents;
using System;
using System.Dynamic;
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

    private const int barracksSpawnTime = 15;
    private const int mainBuildingSpawnTime = 30;

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
    public static void ShowDebugMessage(string sender, Exception ex)
    {
#if DEBUG
      Console.WriteLine($"{sender}: {ex.ToString()}");
#endif
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
        Areas.Center.RegisterOnEnter(CenterRegion.OnEnter);

        RegisterRegionTriggersInHumanArea();
        RegisterRegionTriggerInOrcArea();
        RegisterRegionTriggerInElfArea();
        RegisterRegionTriggerInUndeadArea();

        // Allgemeine Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.BuysUnit, UserHero.OnBuys);
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, OnResearchFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.SellsItem, OnItemSellsFinished);
        PlayerUnitEvents.Register(UnitTypeEvent.Dies, GenericUnit.OnUnitDies);
        PeriodicEvents.AddPeriodicEvent(GoldIncome.OnElapsed, 5f);

        // Gebäude & Trigger für Computer-Spieler erstellen
        ConstructHumanBuildingAndTrigger();
        ConstructOrcBuildingAndTrigger();
        ConstructElfBuildingAndTrigger();
        ConstructUndeadBuildingAndTrigger();

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
        Common.FogEnable(false);
        Common.FogMaskEnable(false);
#endif
      }
      catch (Exception ex)
      {
        ShowDebugMessage("Start.Exception", ex);
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
      SpawnedBuilding building = Humans.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.HumanBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.HumanBaseToCenterSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.HumanBaseToElfSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.HumanBaseToOrcsSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);

      // Kasernen
      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.HumanBarracksToCenterSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.HumanBarracksToCenterSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToElf);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.HumanBarracksToElfSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.HumanBarracksToElfSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(1f);

      building = Humans.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.HumanBarracksToOrcs);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.HumanBarracksToOrcsSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.HumanBarracksToOrcsSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(1f);
    }

    private static void ConstructOrcBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Orcs.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.OrcBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.OrcBaseToCenterSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.OrcBaseToHumanSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.OrcBaseToUndeadSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);

      // Kasernen
      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.OrcBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.OrcBarracksToCenterSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.OrcBarracksToCenterSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.OrcBarracksToHuman);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.OrcBarracksToHumanSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.OrcBarracksToHumanSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);

      building = Orcs.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.OrcBarracksToUndead);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.OrcBarracksToUndeadSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.OrcBarracksToUndeadSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);
    }

    private static void ConstructElfBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Elves.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.ElfBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.ElfBaseToCenterSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.ElfBaseToHumanSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.ElfBaseToUndeadSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);

      // Kasernen
      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.ElfBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.ElfBarracksToCenterSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.ElfBarracksToCenterSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.ElfBarracksToHuman);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.ElfBarracksToHumanSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.ElfBarracksToHumanSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);

      building = Elves.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.ElfBarracksToUndead);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.ElfBarracksToUndeadSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.ElfBarracksToUndeadSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);
    }

    private static void ConstructUndeadBuildingAndTrigger()
    {
      // Hauptgebäude
      SpawnedBuilding building = Undeads.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.UndeadBase);
      building.RegisterOnDies(MainBuilding.OnDies);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.UndeadBaseToCenterSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.UndeadBaseToElfSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);
      building.AddSpawnTrigger(mainBuildingSpawnTime, Areas.UndeadBaseToOrcsSpawn, Constants.UNIT_PRIESTER_HUMAN).Run(5.5f);

      // Kasernen
      building = Undeads.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.UndeadBarracksToCenter);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.UndeadBarracksToCenterSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.UndeadBarracksToCenterSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.UndeadBarracksToElf);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.UndeadBarracksToElfSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.UndeadBarracksToElfSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);

      building = Undeads.Computer.CreateBuilding(Constants.UNIT_KASERNE_HUMAN, Areas.UndeadBarracksToOrcs);
      building.RegisterOnDies(BarracksBuilding.OnDies);
      building.AddSpawnTrigger(barracksSpawnTime, Areas.UndeadBarracksToOrcsSpawn, Constants.UNIT_FU_SOLDAT_HUMAN, Constants.UNIT_FU_SOLDAT_HUMAN).Run();
      building.AddSpawnTrigger(barracksSpawnTime, Areas.UndeadBarracksToOrcsSpawn, Constants.UNIT_SCHARFSCH_TZE_HUMAN).Run(0.5f);
    }

    private static void CreateHeroSelectorForPlayerAndAdjustCamera(UserPlayer user)
    {
      user.CreateUnit(Constants.UNIT_HELDENSEELE_HERO_SELECTOR, Areas.HeroSelectorSpawn);
      user.ApplyCamera(Areas.HeroSelectorSpawn);
    }

    static void OnResearchFinished()
    {
      unit unit = Common.GetResearchingUnit();
      int researchedTechId = Common.GetResearched();
      int researchedTechIdCount = Common.GetPlayerTechCount(unit.Owner, researchedTechId, true);

      Console.WriteLine($"Forschung {researchedTechId} (Stufe {researchedTechIdCount}) abgeschlossen von {unit.Owner.Name}!");

      player owner = unit.Owner;

      if (Humans.ContainsPlayer(unit.Owner, out UserPlayer foundUser))
      {
        Humans.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);
      }
      else if (Orcs.ContainsPlayer(unit.Owner, out foundUser))
      {
        Orcs.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);
      }
      else if (Elves.ContainsPlayer(unit.Owner, out foundUser))
      {
        Elves.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);
      }
      else if (Undeads.ContainsPlayer(unit.Owner, out foundUser))
      {
        Undeads.IncreaseTechForAllPlayers(researchedTechId, researchedTechIdCount);
      }
    }
    static void OnItemSellsFinished()
    {
      unit unit = Common.GetBuyingUnit();
      item item = Common.GetSoldItem();

      Console.WriteLine($"Item {item.Name} verkauft an {unit.Owner.Name}!");

      if (Common.GetItemTypeId(item) == Constants.ITEM_GLYPHE_DER_BAUKUNST)
      {
        Console.WriteLine("BAUKUNST");
      }
    }
  }
}

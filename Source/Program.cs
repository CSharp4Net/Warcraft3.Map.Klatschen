using Source.Extensions;
using Source.RegionEvents;
using System;
using WCSharp.Api;
using WCSharp.Events;
using WCSharp.Shared;
using WCSharp.Shared.Data;
using WCSharp.Sync;
using static WCSharp.Api.Common;

namespace Source
{
  public static class Program
  {
    public static bool Debug { get; private set; } = false;

    public static player WesternForces;
    public static player EasternForces;
    public static player SouthernForces;

    public static void Main()
    {
      // Delay a little since some stuff can break otherwise
      var timer = CreateTimer();
      TimerStart(timer, 0.01f, false, () =>
      {
        DestroyTimer(timer);
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

        WesternForces = Player(3);
        EasternForces = Player(7);
        SouthernForces = Player(11);

        FogEnable(false);
        FogMaskEnable(false);

#if DEBUG
        timer timer = CreateTimer();
        timer.Start(5f, true, CreateFootmans);
#endif

        Regions.Center.Region.RegisterOnEnter(CenterRegion.OnEnter);
        Regions.WestBase.Region.RegisterOnEnter(WestBaseRegion.OnEnter);
        Regions.EastBase.Region.RegisterOnEnter(EastBaseRegion.OnEnter);
        Regions.SouthBase.Region.RegisterOnEnter(SouthBaseRegion.OnEnter);

        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, OnResearchFinished);

        PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDies);

        Console.WriteLine("Kämpft bis zum Tod!");
      }
      catch (Exception ex)
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.Message);
      }
    }

    static void OnUnitDies()
    {
      unit unit = GetTriggerUnit();
      player player = GetOwningPlayer(unit);

      Console.WriteLine($"Einheit {unit.Name} starb!");

      if (player.Controller == mapcontrol.User)
        // TODO : Wenn die Einheit (Held) eines Spielers stirbt, wird diese nicht entfernt, sondern wiedergeboren
        return;

      if (unit.IsABuilding)
      {
        // TODO : Bei manchen Gebäude müssen spezielle Auslöser getriggert werden, wenn sie zerstört werden
        // - Wenn Hauptgebäude zerstört wird -> Verlieren alle Spieler im Team
        // - Wenn 2 Hauptgebäude zerstört wurden -> Gewinnen alle Spiele im verbliebenen Team
      }

      // Verstorbene Einheit nach kurzer Zeit aus Spiel entfernen um RAM zu sparen
      var timer = CreateTimer();
      TimerStart(timer, 10f, false, () =>
      {
        DestroyTimer(timer);
        RemoveUnit(unit);
        // Sicherheitshalber Verweis auf Einheit für GC freigeben
        unit.Dispose();
        unit = null;
      });
    }

    private static void CreateFootmans()
    {
      try
      {
        CreateUnitInRegion(WesternForces, Constants.UNIT_TESTSOLDIER, Regions.WestSpawnTop, 0f).AttackMove(Regions.EastBase);
        CreateUnitInRegion(WesternForces, Constants.UNIT_TESTSOLDIER, Regions.WestSpawnMiddle, 0f).AttackMove(Regions.Center);
        CreateUnitInRegion(WesternForces, Constants.UNIT_TESTSOLDIER, Regions.WestSpawnBottom, 0f).AttackMove(Regions.SouthBase);

        CreateUnitInRegion(EasternForces, Constants.UNIT_TESTSOLDIER, Regions.EastSpawnTop, 90f).AttackMove(Regions.WestBase);
        CreateUnitInRegion(EasternForces, Constants.UNIT_TESTSOLDIER, Regions.EastSpawnMiddle, 90f).AttackMove(Regions.Center);
        CreateUnitInRegion(EasternForces, Constants.UNIT_TESTSOLDIER, Regions.EastSpawnBottom, 90f).AttackMove(Regions.SouthBase);

        CreateUnitInRegion(SouthernForces, Constants.UNIT_TESTSOLDIER, Regions.SouthSpawnLeft, 45f).AttackMove(Regions.WestBase);
        CreateUnitInRegion(SouthernForces, Constants.UNIT_TESTSOLDIER, Regions.SouthSpawnMiddle, 45f).AttackMove(Regions.Center);
        CreateUnitInRegion(SouthernForces, Constants.UNIT_TESTSOLDIER, Regions.SouthSpawnRight, 45f).AttackMove(Regions.EastBase);
      }
      catch (Exception ex)
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, ex.Message);
      }
    }

    static unit CreateUnitInRegion(player player, int unitId, Rectangle regionRectangle, float face)
    {
      location location = Location(regionRectangle.Center.X, regionRectangle.Center.Y);
      return CreateUnitAtLoc(player, Constants.UNIT_TESTSOLDIER, location, face);
    }

    static void OnResearchFinished()
    {
      Console.WriteLine("Forschung abgeschlossen!");
      unit unit = GetResearchingUnit();
      int researchedTechId = GetResearched();
    }
  }
}

using Source.Extensions;
using Source.Models;
using Source.RegionEvents;
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

    public static Team HumanTeam;
    public static Team EasternForces;
    public static Team SouthernForces;

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
        HumanTeam = new Team(Common.Player(3));
        EasternForces = new Team(Common.Player(7));
        SouthernForces = new Team(Common.Player(11));

        // TODO: Aktive Spieler zu Teams hinzufügen

        // TODO: Trigger-Gebäude für Computer-Spieler ersteöllen
        HumanTeam.Computer.CreateBuilding(Constants.UNIT_SCHLOSS_HUMAN, Areas.WestBase);

#if DEBUG
        Common.FogEnable(false);
        Common.FogMaskEnable(false);

        timer timer = Common.CreateTimer();
        timer.Start(5f, true, CreateFootmans);
#endif

        // Regions-Ereignisse registriere für automatische Einheitenbewegungen
        Regions.Center.Region.RegisterOnEnter(CenterRegion.OnEnter);
        Regions.WestBase.Region.RegisterOnEnter(WestBaseRegion.OnEnter);
        Regions.EastBase.Region.RegisterOnEnter(EastBaseRegion.OnEnter);
        Regions.SouthBase.Region.RegisterOnEnter(SouthBaseRegion.OnEnter);

        // TODO: Weitere Events registrieren
        PlayerUnitEvents.Register(UnitTypeEvent.FinishesResearch, OnResearchFinished);

        PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitDies);

        Console.WriteLine("Kämpft bis zum Tod!");
      }
      catch (Exception ex)
      {
        Common.DisplayTextToPlayer(Common.GetLocalPlayer(), 0, 0, ex.Message);
      }
    }

    static void OnUnitDies()
    {
      unit unit = Common.GetTriggerUnit();
      player player = Common.GetOwningPlayer(unit);

      //Console.WriteLine($"Einheit {unit.Name} starb! {unit.UnitType},{Constants.UNIT_TESTSOLDIER}");

      if (player.Controller == mapcontrol.User)
        // TODO : Wenn die Einheit (Held) eines Spielers stirbt, wird diese nicht entfernt, sondern wiedergeboren
        return;

      if (unit.IsABuilding)
      {
        // TODO : Bei manchen Gebäude müssen spezielle Auslöser getriggert werden, wenn sie zerstört werden
        // - Wenn Hauptgebäude zerstört wird -> Verlieren alle Spieler im Team
        // - Wenn 2 Hauptgebäude zerstört wurden -> Gewinnen alle Spiele im verbliebenen Team
        if (player.Id == HumanTeam.Computer.Player.Id)
        {
          if (unit.UnitType == Constants.UNIT_RATHAUS_HUMAN || unit.UnitType == Constants.UNIT_BURG_HUMAN || unit.UnitType == Constants.UNIT_SCHLOSS_HUMAN)
          {
            // Hauptgebäude wurde zerstört!
            //Console.WriteLine("");
            //int teamId = Common.GetPlayerTeam(unit.Owner);

            //Blizzard.Defeat
            //WesternForces.Remove(playergameresult.Defeat);

            //var timer2 = CreateTimer();
            //TimerStart(timer2, 5f, false, () =>
            //{
            //  DestroyTimer(timer2);
            //  Player(1).Remove(playergameresult.Defeat);
            //  Player(0).Remove(playergameresult.Defeat);
            //});

            //group group = Blizzard.GetUnitsSelectedAll(WesternForces);

            //group.ForEach(() =>  GetEnumUnit().Kill());
          }
        }
        else if (player.Id == EasternForces.Computer.Player.Id)
        {

        }
        else if (player.Id == SouthernForces.Computer.Player.Id)
        {

        }
      }

      // Verstorbene Einheit nach kurzer Zeit aus Spiel entfernen um RAM zu sparen
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, 10f, false, () =>
      {
        Common.DestroyTimer(timer);
        Common.RemoveUnit(unit);
        // Sicherheitshalber Verweis auf Einheit für GC freigeben
        unit.Dispose();
        unit = null;
      });
    }

    private static void CreateFootmans()
    {
      try
      {
        HumanTeam.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.WestSpawnTop, 0f).AttackMove(Regions.EastBase);
        HumanTeam.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.WestSpawnMiddle, 0f).AttackMove(Regions.Center);
        HumanTeam.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.WestSpawnBottom, 0f).AttackMove(Regions.SouthBase);

        EasternForces.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.EastSpawnTop, 90f).AttackMove(Regions.WestBase);
        EasternForces.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.EastSpawnMiddle, 90f).AttackMove(Regions.Center);
        EasternForces.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.EastSpawnBottom, 90f).AttackMove(Regions.SouthBase);

        SouthernForces.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.SouthSpawnLeft, 45f).AttackMove(Regions.WestBase);
        SouthernForces.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.SouthSpawnMiddle, 45f).AttackMove(Regions.Center);
        SouthernForces.Computer.CreateUnit(Constants.UNIT_TESTSOLDIER, Areas.SouthSpawnRight, 45f).AttackMove(Regions.EastBase);
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

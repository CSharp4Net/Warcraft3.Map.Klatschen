using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events.GenericEvents
{
  internal static class Unit
  {
    internal static void OnDies()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding)
        {
          // Wenn Gebäude sterben, haben diese wenn überhaupt eigene Trigger - TODO ??
          return;
        }

        if (unit.IsUnitType(unittype.Hero))
        {
          // Wenn Helden sterben, werden diese abhängig vom SlotStatus gesondert behandelt
          if (unit.Owner.Controller == mapcontrol.User)
            Player.UserHero.OnDies(unit);
          else
            Computer.ComputerHero.OnDies(unit);

          return;
        }

        player owner = unit.Owner;

        // Getötete Einheit von Spieler entfernen
        if (Program.Humans.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
        {
          Program.Humans.Computer.RemoveUnit(spawnedUnit);
        }
        else if (Program.Orcs.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
        {
          Program.Orcs.Computer.RemoveUnit(spawnedUnit);
        }
        else if (Program.Elves.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
        {
          Program.Elves.Computer.RemoveUnit(spawnedUnit);
        }
        else if (Program.Undeads.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
        {
          Program.Undeads.Computer.RemoveUnit(spawnedUnit);
        }
        //else
        //  Bspw. der Tod der Heldenseele bei Kauf löst diesen Fall aus.
        //  Program.ShowDebugMessage("Unit.OnDies", $"Unit {unit.Name} not found in unit lists of computer players!");

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
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnDies", ex);
      }
    }

    internal static void OnReceivesOrder()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (unit.IsABuilding)
        {
          // Befehle für Gebäude nicht behandeln
          return;
        }

        if (unit.IsUnitType(unittype.Hero) && unit.Owner.Controller == mapcontrol.User)
        {
          // Befehle für Benutzer-Helden nicht behandeln
          return;
        }

        if (Common.GetUnitTypeId(unit) == Constants.UNIT_DUMMY)
        {
          // Befehle für Dummy-Units nicht behandeln
          return;
        }

        // Wenn eine gespawnte Einheit ihren Angriffsbefehl verliert, erteilen wir ihr diesen erneut
        // Befehl 851974 ist die Heimkehr zum Ausgangspunkt und fehlt in der Constants.
        if (unit.CurrentOrder == 851974 || unit.CurrentOrder == Constants.ORDER_CANCEL ||
            unit.CurrentOrder == Constants.ORDER_STUNNED || unit.CurrentOrder == Constants.ORDER_STOP)
        {
          // Zaubernde Einheit den letzten Angriffsbefehl wiederholen lassen
          if (Program.Humans.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
          {
            spawnedUnit.RepeatAttackMove();
          }
          else if (Program.Orcs.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            spawnedUnit.RepeatAttackMove();
          }
          else if (Program.Elves.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            spawnedUnit.RepeatAttackMove();
          }
          else if (Program.Undeads.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
          {
            spawnedUnit.RepeatAttackMove();
          }
        }
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Unit.OnReceivesOrder", ex);
      }
    }
  }
}
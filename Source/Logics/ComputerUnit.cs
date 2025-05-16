using Source.Models;
using WCSharp.Api;

namespace Source.Logics
{
  internal static class ComputerUnit
  {
    internal static void HandleDied(unit unit)
    {
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

    internal static void HandleOrderReceived(unit unit)
    {
      // Wenn eine gespawnte Einheit ihren Angriffsbefehl verliert, erteilen wir ihr diesen erneut
      // Befehl 851974 ist die Heimkehr zum Ausgangspunkt und fehlt in der Constants.
      switch (unit.CurrentOrder)
      {
        case 851974:
        case Constants.ORDER_CANCEL:
        case Constants.ORDER_STUNNED:
        case Constants.ORDER_STOP:
          RepeatAttackMove(unit);
          break;
      }
    }

    private static void RepeatAttackMove(unit unit)
    {
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
}
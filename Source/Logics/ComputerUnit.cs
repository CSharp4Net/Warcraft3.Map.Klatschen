using Source.Models;
using WCSharp.Api;

namespace Source.Logics
{
  /// <summary>
  /// Stellt statische Methoden für die Logik von automatisch erstellten Einheiten bereit.
  /// </summary>
  internal static class ComputerUnit
  {
    /// <summary>
    /// Behandelt den Tod einer Einheit.
    /// </summary>
    /// <param name="unit">Einheit</param>
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
      else if (Program.Legion.IsOwnerOfUnit(unit, out spawnedUnit))
      {
        Program.Legion.RemoveUnit(spawnedUnit);
      }
      //else
      //  Bspw. der Tod der Heldenseele bei Kauf löst diesen Fall aus.
      //  Program.ShowDebugMessage("Unit.OnDies", $"Unit {unit.Name} not found in unit lists of computer players!");

      // Verstorbene Einheit nach kurzer Zeit aus Spiel entfernen um RAM zu sparen
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, 10f, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        // Sicherheitshalber Verweis auf Einheit für GC freigeben
        Common.RemoveUnit(unit);
        unit.Dispose();
        unit = null;
      });
    }

    /// <summary>
    /// Behandelt das Ereignis, wenn eine Einheit vom System einen Befehl bekommt.
    /// </summary>
    /// <param name="unit">Einheit</param>
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

    /// <summary>
    /// Ermittelt den Eigentümer der Einheit und wiederholt deren letzten (Angriffs-)Befehl.
    /// </summary>
    /// <param name="unit">Einheit</param>
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
      else if (Program.Legion.IsOwnerOfUnit(unit, out spawnedUnit))
      {
        spawnedUnit.RepeatAttackMove();
      }
    }
  }
}
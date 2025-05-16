using Source.Models;
using WCSharp.Api;

namespace Source.Logics
{
  internal static class ComputerUnit
  {
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
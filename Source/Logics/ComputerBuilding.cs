using Source.Abstracts;
using WCSharp.Api;

namespace Source.Logics
{
  internal static class ComputerBuilding
  {
    internal static void HandleSingleSpawnBuyed(unit buyingUnit, unit soldUnit, unit sellingUnit, TeamBase team)
    {
      int soldUnitId = Common.GetUnitTypeId(soldUnit);

      // Gekaufte Einheit sofort entfernen
      Common.RemoveUnit(soldUnit);

      // Sicherheitshalber Verweis auf Einheit für GC freigeben
      soldUnit.Dispose();
      soldUnit = null;

      int playerId = buyingUnit.Owner.Id;

      team.Computer.MainBuilding.CreateSingleUnitSpawn(soldUnitId);
    }
  }
}

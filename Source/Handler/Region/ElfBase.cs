using Source.Models;
using WCSharp.Api;

namespace Source.Handler.Region
{
  internal static class ElfBase
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis eines anderen Spielers schicken
      if (Program.Humans.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
      {
        if (!Program.Undeads.Defeated)
        {
          spawnedUnit.AttackMove(Areas.UndeadBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.OrcBase);
        }
      }
      else if (Program.Orcs.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
      {
        if (!Program.Undeads.Defeated)
        {
          spawnedUnit.AttackMove(Areas.UndeadBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.HumanBase);
        }
      }
      else if (Program.Undeads.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
      {
        if (!Program.Humans.Defeated)
        {
          spawnedUnit.AttackMove(Areas.HumanBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.OrcBase);
        }
      }
    }
  }
}

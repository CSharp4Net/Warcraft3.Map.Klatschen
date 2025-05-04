using Source.Models;
using WCSharp.Api;

namespace Source.Events.Region
{
  internal static class UndeadBase
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (Program.Humans.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
      {
        if (!Program.Orcs.Defeated)
        {
          spawnedUnit.AttackMove(Areas.OrcBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.ElfBase);
        }
      }
      else if (Program.Orcs.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
      {
        if (!Program.Elves.Defeated)
        {
          spawnedUnit.AttackMove(Areas.ElfBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.HumanBase);
        }
      }
      else if (Program.Elves.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
      {
        if (!Program.Orcs.Defeated)
        {
          spawnedUnit.AttackMove(Areas.OrcBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.HumanBase);
        }
      }
    }
  }
}

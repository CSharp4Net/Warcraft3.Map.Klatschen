using Source.Models;
using WCSharp.Api;

namespace Source.Events.Region
{
  internal static class OrcBase
  {
    internal static void OnEnter()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.IsABuilding || unit.Owner.Controller != mapcontrol.Computer)
        return;

      // Feindliche Einheit zur Basis des anderen Spielers schicken
      if (Program.Humans.Computer.IsOwnerOfUnit(unit, out SpawnedUnit spawnedUnit))
      {
        if (!Program.Undeads.Defeated)
        {
          spawnedUnit.AttackMove(Areas.UndeadBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.ElfBase);
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
          spawnedUnit.AttackMove(Areas.ElfBase);
        }
      }
      else if (Program.Elves.Computer.IsOwnerOfUnit(unit, out spawnedUnit))
      {
        if (!Program.Humans.Defeated)
        {
          spawnedUnit.AttackMove(Areas.HumanBase);
        }
        else
        {
          spawnedUnit.AttackMove(Areas.UndeadBase);
        }
      }
    }
  }
}

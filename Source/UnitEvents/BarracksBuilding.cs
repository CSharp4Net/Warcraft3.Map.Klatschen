using Source.Models;
using System;
using WCSharp.Api;

namespace Source.UnitEvents
{
  internal static class BarracksBuilding
  {
    internal static void OnDies()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (Program.Humans.Computer.IsOwnerOfBuilding(unit, out SpawnedBuilding building))
        {
          building.Destroy();
          Console.WriteLine("Die Menschen haben eine ihrer Kasernen verloren!");
          Program.Humans.Computer.RemoveBuilding(building);
        }
        else if (Program.Orcs.Computer.IsOwnerOfBuilding(unit, out building))
        {
          building.Destroy();
          Console.WriteLine("Die Orks haben eine ihrer Kasernen verloren!");
          Program.Orcs.Computer.RemoveBuilding(building);
        }
        else if (Program.Elves.Computer.IsOwnerOfBuilding(unit, out building))
        {
          building.Destroy();
          Console.WriteLine("Die Elfen haben eine ihrer Kasernen verloren!");
          Program.Elves.Computer.RemoveBuilding(building);
        }
      }
      catch (Exception ex)
      {
        Program.ShowDebugMessage("BarracksBuilding.OnDies", ex.ToString());
      }
    }
  }
}
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

        if (unit.Owner.Id == Program.Humans.Computer.Player.Id)
        {
          foreach (Building building in Program.Humans.Computer.Buildings)
          {
            if (building.Unit == unit)
            {
              building.Destroy();
              Console.WriteLine("Die Menschen haben eine ihrer Kasernen verloren!");

              Program.Humans.Computer.Buildings.Remove(building);
              break;
            }
          }
        }
        else if (unit.Owner.Id == Program.Orcs.Computer.Player.Id)
        {
          foreach (Building building in Program.Orcs.Computer.Buildings)
          {
            if (building.Unit == unit)
            {
              building.Destroy();
              Console.WriteLine("Die Orks haben eine ihrer Kasernen verloren!");

              Program.Orcs.Computer.Buildings.Remove(building);
              break;
            }
          }
        }
        else if (unit.Owner.Id == Program.Elves.Computer.Player.Id)
        {
          foreach (Building building in Program.Elves.Computer.Buildings)
          {
            if (building.Unit == unit)
            {
              building.Destroy();
              Console.WriteLine("Die Elfen haben eine ihrer Kasernen verloren!");

              Program.Elves.Computer.Buildings.Remove(building);
              break;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
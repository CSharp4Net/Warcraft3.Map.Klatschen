using Source.Models;
using Source.Statics;
using System;
using WCSharp.Api;

namespace Source.Events.Buildings
{
  internal static class LegionBuilding
  {
    internal static void OnDies()
    {
      try
      {
        unit buildingUnit = Common.GetTriggerUnit();
        unit killingUnit = Common.GetKillingUnit();

        player player = killingUnit.Owner;

        if (!Program.TryGetUserById(player.Id, out UserPlayer user))
          return;

        int unitType = buildingUnit.UnitType;


        // Stoppe Trigger
        if (Program.Legion.SpawnBuildingWest.Wc3Unit == buildingUnit)
        {
          Console.WriteLine($"Das {Program.Legion.SpawnBuildingEast.Wc3Unit.Name} im Westen wurde zerstört!");
          SpecialEffects.CreateSpecialEffect("Abilities\\Spells\\Other\\Doom\\DoomDeath.mdl", Program.Legion.SpawnBuildingWest.CreationArea.Wc3Rectangle.Center, 5f, 5f);
          Program.Legion.SpawnBuildingWest.Destroy();
        }
        else if (Program.Legion.SpawnBuildingEast.Wc3Unit == buildingUnit)
        {
          Console.WriteLine($"Das {Program.Legion.SpawnBuildingEast.Wc3Unit.Name} im Osten wurde zerstört!");
          SpecialEffects.CreateSpecialEffect("Abilities\\Spells\\Other\\Doom\\DoomDeath.mdl", Program.Legion.SpawnBuildingEast.CreationArea.Wc3Rectangle.Center, 5f, 5f);
          Program.Legion.SpawnBuildingEast.Destroy();
        }
        else
          Program.ShowErrorMessage("KlatschenMainBuilding.OnDies", $"Unhandled legion building destroyed: {buildingUnit.Name}");
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("KlatschenMainBuilding.OnDies", ex);
      }
    }
  }
}
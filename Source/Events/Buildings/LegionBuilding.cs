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

        if (Program.Legion.TryGetSpawnBuilding(buildingUnit, out LegionSpawnBuilding building))
        {
          Console.WriteLine($"A {building.Wc3Unit.Name} of the {Program.Legion.ColorizedName} has been destroyed!");
          SpecialEffects.CreateSpecialEffect("Abilities\\Spells\\Other\\Doom\\DoomDeath.mdl", building.CreationArea.Wc3Rectangle.Center, 2f, 3f);
          Program.Legion.RemoveSpawnBuilding(building);
        }
        else
          Program.ShowErrorMessage("LegionBuilding.OnDies", $"Unhandled legion building destroyed: {buildingUnit.Name}");
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("LegionBuilding.OnDies", ex);
      }
    }
  }
}
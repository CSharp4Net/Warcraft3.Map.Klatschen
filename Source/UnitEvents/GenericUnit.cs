using Source.Models;
using System;
using WCSharp.Api;

namespace Source.UnitEvents
{
  internal static class GenericUnit
  {
    internal static void OnUnitDies()
    {
      try
      {
        unit unit = Common.GetTriggerUnit();

        if (Common.IsHeroUnitId(Common.GetUnitTypeId(unit)))
        {
          UserHero.OnDies(unit);
          return;
        }

        player owner = unit.Owner;

        // Getötete Einheit von Spieler entfernen
        if (Program.Humans.Computer.IsOwnerOfUnit(unit))
        {
          Program.Humans.Computer.RemoveUnit(unit);
        }
        else if (Program.Orcs.Computer.IsOwnerOfUnit(unit))
        {
          Program.Orcs.Computer.RemoveUnit(unit);
        }
        else if (Program.Elves.Computer.IsOwnerOfUnit(unit))
        {
          Program.Elves.Computer.RemoveUnit(unit);
        }
        else if (Program.Undeads.Computer.IsOwnerOfUnit(unit))
        {
          Program.Undeads.Computer.RemoveUnit(unit);
        }

        // Verstorbene Einheit nach kurzer Zeit aus Spiel entfernen um RAM zu sparen
        var timer = Common.CreateTimer();
        Common.TimerStart(timer, 10f, false, () =>
        {
          Common.DestroyTimer(timer);
          Common.RemoveUnit(unit);
          // Sicherheitshalber Verweis auf Einheit für GC freigeben
          unit.Dispose();
          unit = null;
        });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
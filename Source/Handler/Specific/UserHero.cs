using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Handler.Specific
{
  internal static class UserHero
  {
    public static void OnBuys()
    {
      try
      {
        unit buyingUnit = Common.GetBuyingUnit();
        unit soldUnit = Common.GetSoldUnit();

        // Nur auf Hero-Selector reagieren!
        if (Common.GetUnitTypeId(buyingUnit) != Constants.UNIT_HELDENSEELE_HERO_SELECTOR)
        {
          Console.WriteLine($"Falsche Event-Registrierung 'BuysUnit' fpr {buyingUnit.Name}!");
          return;
        }

        // Käufer ermitteln
        player buyingPlayer = Common.GetOwningPlayer(buyingUnit);

        // Käufer-Einheit töten
        buyingUnit.Kill();

        // Gekaufte Einheit sofort wieder entfernen und in Player-Base neu erstelleN!
        int unitId = Common.GetUnitTypeId(soldUnit);
        Common.RemoveUnit(soldUnit);
        // Sicherheitshalber Verweis auf Einheit für GC freigeben
        soldUnit.Dispose();
        soldUnit = null;

        if (Program.Humans.ContainsPlayer(buyingPlayer, out UserPlayer user))
        {
#if DEBUG
          soldUnit = user.CreateUnit(unitId, Areas.HumanBaseHeroSpawn); // Center);
          user.ApplyCamera(Areas.HumanBaseHeroSpawn); // Center);
#else
          soldUnit = user.CreateUnit(unitId, Areas.HumanBaseHeroSpawn);
          user.ApplyCamera(Areas.HumanBaseHeroSpawn);
#endif
        }
        else if (Program.Orcs.ContainsPlayer(buyingPlayer, out user))
        {
          soldUnit = user.CreateUnit(unitId, Areas.OrcBaseHeroSpawn);
          user.ApplyCamera(Areas.OrcBaseHeroSpawn);
        }
        else if (Program.Elves.ContainsPlayer(buyingPlayer, out user))
        {
          soldUnit = user.CreateUnit(unitId, Areas.ElfBaseHeroSpawn);
          user.ApplyCamera(Areas.ElfBaseHeroSpawn);
        }
        else if (Program.Undeads.ContainsPlayer(buyingPlayer, out user))
        {
          soldUnit = user.CreateUnit(unitId, Areas.UndeadBaseHeroSpawn);
          user.ApplyCamera(Areas.UndeadBaseHeroSpawn);
        }

        // Einheit automatisch auswählen
        Blizzard.SelectUnitForPlayerSingle(soldUnit, user.Wc3Player);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void OnDies(unit unit)
    {
      // Verstorbenen Held nach gegebener Zeit wieder belegen, derweil Timer anzeigen
      timer timer = Common.CreateTimer();
      timerdialog timerdialog = timer.CreateDialog();
      timerdialog.SetTitle($"{unit.Name} erscheint erneut...");
      timerdialog.IsDisplayed = true;
      Common.TimerStart(timer, unit.HeroLevel + 2, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        timerdialog.Dispose();
        timerdialog = null;

        player owner = unit.Owner;
        if (Program.Humans.ContainsPlayer(owner, out UserPlayer user))
        {
#if DEBUG
          //Common.ReviveHero(unit, Areas.Center.Wc3CenterLocation.X, Areas.Center.Wc3CenterLocation.Y, true);
          //user.ApplyCamera(Areas.Center);

          Common.ReviveHero(unit, Areas.HumanBaseHeroRespawn.Wc3CenterLocation.X, Areas.HumanBaseHeroRespawn.Wc3CenterLocation.Y, true);
          user.ApplyCamera(Areas.HumanBaseHeroRespawn);
#else
          Common.ReviveHero(unit, Areas.HumanBaseHeroRespawn.Wc3CenterLocation.X, Areas.HumanBaseHeroRespawn.Wc3CenterLocation.Y, true);
          user.ApplyCamera(Areas.HumanBaseHeroRespawn);
#endif
        }
        else if (Program.Orcs.ContainsPlayer(owner, out user))
        {
          Common.ReviveHero(unit, Areas.OrcBaseHeroRespawn.Wc3CenterLocation.X, Areas.OrcBaseHeroRespawn.Wc3CenterLocation.Y, true);
          user.ApplyCamera(Areas.OrcBaseHeroRespawn);
        }
        else if (Program.Elves.ContainsPlayer(owner, out user))
        {
          Common.ReviveHero(unit, Areas.ElfBaseHeroRespawn.Wc3CenterLocation.X, Areas.ElfBaseHeroRespawn.Wc3CenterLocation.Y, true);
          user.ApplyCamera(Areas.ElfBaseHeroRespawn);
        }
        else if (Program.Undeads.ContainsPlayer(owner, out user))
        {
          Common.ReviveHero(unit, Areas.UndeadBaseHeroRespawn.Wc3CenterLocation.X, Areas.UndeadBaseHeroRespawn.Wc3CenterLocation.Y, true);
          user.ApplyCamera(Areas.UndeadBaseHeroRespawn);
        }

        // Einheit automatisch auswählen
        Blizzard.SelectUnitForPlayerSingle(unit, user.Wc3Player);

        // TODO : Was ist mit Computer-Heros??
      });
    }
  }
}

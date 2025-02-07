using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Handler.Specific
{
  internal static class UserHero
  {
    public static void OnBuyed()
    {
      try
      {
        unit buyingUnit = Common.GetBuyingUnit();
        unit soldUnit = Common.GetSoldUnit();

        // Nur auf Hero-Selector reagieren!
        if (Common.GetUnitTypeId(buyingUnit) != Constants.UNIT_HELDENSEELE_HERO_SELECTOR)
        {
          Console.WriteLine($"Falsche Event-Registrierung 'OnBuyed' für {buyingUnit.Name}!");
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

        Program.ShowDebugMessage("UserHero.OnBuyed", $"Create hero {unitId} for {buyingPlayer.Name}");

        if (Program.Humans.ContainsPlayer(buyingPlayer, out UserPlayer user))
        {
          user.CreateHero(unitId, Areas.HumanBaseHeroSpawn);
        }
        else if (Program.Orcs.ContainsPlayer(buyingPlayer, out user))
        {
          user.CreateUnit(unitId, Areas.OrcBaseHeroSpawn);
        }
        else if (Program.Elves.ContainsPlayer(buyingPlayer, out user))
        {
          user.CreateUnit(unitId, Areas.ElfBaseHeroSpawn);
        }
        else if (Program.Undeads.ContainsPlayer(buyingPlayer, out user))
        {
          user.CreateUnit(unitId, Areas.UndeadBaseHeroSpawn);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void OnDies(unit unit)
    {
      // Verstorbenen Held nach gegebener Zeit wieder belegen
      timer timer = Common.CreateTimer();
      // Währenddessen Timer-Dialog anzeigen
      timerdialog timerdialog = timer.CreateDialog();
      timerdialog.SetTitle($"{unit.Name} erscheint erneut...");
      timerdialog.IsDisplayed = true;

      Common.TimerStart(timer, unit.HeroLevel + 2, false, () =>
      {
        // Timer wieder zerstören
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        // Timer-Dialog wieder zerstören
        timerdialog.Dispose();
        timerdialog = null;

        player owner = unit.Owner;

        if (Program.Humans.ContainsPlayer(owner, out UserPlayer user))
        {
          user.ReviveHero(Areas.HumanBaseHeroRespawn);
        }
        else if (Program.Orcs.ContainsPlayer(owner, out user))
        {
          user.ReviveHero(Areas.OrcBaseHeroRespawn);
        }
        else if (Program.Elves.ContainsPlayer(owner, out user))
        {
          user.ReviveHero(Areas.ElfBaseHeroRespawn);
        }
        else if (Program.Undeads.ContainsPlayer(owner, out user))
        {
          user.ReviveHero(Areas.UndeadBaseHeroRespawn);
        }

        // Einheit automatisch auswählen
        Blizzard.SelectUnitForPlayerSingle(unit, user.Wc3Player);

        // TODO : Was ist mit Computer-Heros??
      });
    }

    public static void OnLevels()
    {
      try
      {
        unit wc3Unit = Common.GetLevelingUnit();
        player wc3Player = wc3Unit.Owner;

        if (Program.TryGetActiveUser(wc3Player.Id, out UserPlayer user))
        {
          // Level des Helden bei Aufstieg marken
          user.HeroLevelCounter++;

          Program.ShowDebugMessage("UserHero.OnLevels", $"Hero level counter of {user.Wc3Player.Name} increased to {user.HeroLevelCounter}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}

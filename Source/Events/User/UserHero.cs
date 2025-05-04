using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events.Player
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

        int unitId = Common.GetUnitTypeId(soldUnit);
        player player = buyingUnit.Owner;
        int playerId = player.Id;

        // Käufer-Einheit töten
        buyingUnit.Kill();

        // Gekaufte Einheit sofort wieder entfernen und in Player-Base neu erstelleN!
        Common.RemoveUnit(soldUnit);

        // Sicherheitshalber Verweis auf Einheit für GC freigeben
        soldUnit.Dispose();
        soldUnit = null;

        Area spawnArea = null;

        if (Program.Humans.ContainsPlayer(playerId, out UserPlayer user))
        {
          spawnArea = Areas.HumanBaseHeroSpawn;
        }
        else if (Program.Orcs.ContainsPlayer(playerId, out user))
        {
          spawnArea = Areas.OrcBaseHeroSpawn;
        }
        else if (Program.Elves.ContainsPlayer(playerId, out user))
        {
          spawnArea = Areas.ElfBaseHeroSpawn;
        }
        else if (Program.Undeads.ContainsPlayer(playerId, out user))
        {
          spawnArea = Areas.UndeadBaseHeroSpawn;
        }
        else
          Program.ShowDebugMessage("UserHero.OnBuyed", $"Player {player.Name} of buying unit not found in teams!");

        if (user == null)
          return;

#if DEBUG
        //spawnArea = Areas.TestArea;
        //user.HeroLevelCounter = 36;
#endif

        user.CreateHero(unitId, spawnArea);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    internal static void OnDies(unit unit)
    {
      // Verstorbenen Held nach gegebener Zeit wieder belegen
      timer timer = Common.CreateTimer();
      // Währenddessen Timer-Dialog anzeigen
      timerdialog timerdialog = timer.CreateDialog();
      timerdialog.SetTitle($"{unit.Name} erscheint erneut...");
      timerdialog.IsDisplayed = true;

      player player = unit.Owner;
      int playerId = unit.Owner.Id;
      Area respawnArea = null;

      if (Program.Humans.ContainsPlayer(playerId, out UserPlayer user))
      {
        respawnArea = Areas.HumanBaseHeroRespawn;
      }
      else if (Program.Orcs.ContainsPlayer(playerId, out user))
      {
        respawnArea = Areas.OrcBaseHeroRespawn;
      }
      else if (Program.Elves.ContainsPlayer(playerId, out user))
      {
        respawnArea = Areas.ElfBaseHeroRespawn;
      }
      else if (Program.Undeads.ContainsPlayer(playerId, out user))
      {
        respawnArea = Areas.UndeadBaseHeroRespawn;
      }
      else
        Program.ShowDebugMessage("UserHero.OnDies", $"Player {player.Name} of hero {unit.Name} not found in teams!");

      if (user == null)
        return;

      Common.TimerStart(timer, unit.HeroLevel + 2, false, () =>
      {
        try
        {
          // Timer wieder zerstören
          Common.DestroyTimer(timer);
          timer.Dispose();
          timer = null;

          // Timer-Dialog wieder zerstören
          timerdialog.Dispose();
          timerdialog = null;

          Common.ReviveHero(unit, respawnArea.CenterX, respawnArea.CenterY, true);

          user.ApplyCamera(respawnArea);

          Blizzard.SelectUnitForPlayerSingle(unit, unit.Owner);
        }
        catch (Exception ex)
        {
          Program.ShowExceptionMessage("UserHero.OnDies", ex);
        }
      });
    }
  }
}

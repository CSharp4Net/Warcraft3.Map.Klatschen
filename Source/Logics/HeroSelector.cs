using Source.Models;
using WCSharp.Api;

namespace Source.Logics
{
  internal class HeroSelector
  {
    internal static void HandleHeroBuyed(unit buyingUnit, unit soldUnit)
    {
      int soldUnitId = Common.GetUnitTypeId(soldUnit);
      player player = buyingUnit.Owner;
      int playerId = player.Id;

      // Käufer-Einheit töten
      buyingUnit.Kill();

      // Gekaufte Einheit sofort wieder entfernen und in Player-Base neu erstellen!
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
      spawnArea = Areas.TestArea2;
      user.HeroLevelCounter = 50;
      user.Wc3Player.Gold += 5000;
#endif

      user.CreateHero(soldUnitId, spawnArea);
    }
  }
}
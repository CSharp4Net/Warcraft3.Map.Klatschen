using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Events.Other
{
  internal static class Item
  {
    internal static void OnSellsFinished()
    {
      try
      {
        unit unit = Common.GetBuyingUnit();

        item item = Common.GetSoldItem();
        int itemId = item.TypeId;

        if (itemId == Constants.ITEM_GLYPHE_DER_OPFERUNG)
        {
          int playerId = unit.Owner.Id;
          if (Program.TryGetActiveUser(playerId, out UserPlayer user))
          {
            // Merke Heldenstufe
            user.HeroLevelCounter = unit.HeroLevel;
            // Entferne Käufer/Helden aus Spiel
            Common.RemoveUnit(unit);

            // Heldenseele erstellen und Kamera verschieben
            Program.CreateHeroSelectorForPlayerAndAdjustCamera(user);
          }
        }
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Item.OnSellsFinished", ex);
      }
    }
  }
}
using System;
using WCSharp.Api;

namespace Source.Handler.GenericEvents
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

        Console.WriteLine($"Item {item.Name} verkauft an {unit.Owner.Name}!");

        if (itemId == Constants.ITEM_GLYPHE_DER_OPFERUNG)
        {
          Console.WriteLine($"Item {itemId}... try to explode!");
          int playerId = unit.Owner.Id;

          Blizzard.ExplodeUnitBJ(unit);
        }
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Item.OnSellsFinished", ex);
      }
    }
  }
}
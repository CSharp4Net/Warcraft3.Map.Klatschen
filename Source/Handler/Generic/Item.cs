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

        Console.WriteLine($"Item {item.Name} verkauft an {unit.Owner.Name}!");

        if (Common.GetItemTypeId(item) == Constants.ITEM_GLYPHE_DER_BAUKUNST)
        {
          Console.WriteLine("BAUKUNST");
        }
      }
      catch (Exception ex)
      {
        Program.ShowDebugMessage("Item.OnSellsFinished", ex);
      }
    }
  }
}
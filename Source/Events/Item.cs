//using System;
//using WCSharp.Api;

//namespace Source.Events
//{
//  internal static class Item
//  {
//    /// <summary>
//    /// Behandelt den Tod einer Einheit.
//    /// </summary>
//    internal static void OnIsSold()
//    {
//      try
//      {

//        //if (!buyingUnit.IsHero() || !buyingUnit.IsUnitOfUser())
//        //  return;

//        Console.WriteLine("Item sold!");


//        item buyedItem = Common.GetSoldItem();

//        Console.WriteLine(buyedItem.Name);

//        unit buyingUnit = Common.GetBuyingUnit();
//        unit sellingUnit = Common.GetSellingUnit();

//        Logics.UserHero.HandleUpgradeItemBuyed(buyingUnit, buyedItem, sellingUnit);
//      }
//      catch (Exception ex)
//      {
//        Program.ShowExceptionMessage("Item.OnIsSold", ex);
//      }
//    }
//  }
//}
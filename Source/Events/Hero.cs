using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.Events
{
  internal static class Hero
  {
    internal static void OnLevels()
    {
      try
      {
        unit unit = Common.GetLevelingUnit();

        if (!unit.IsUnitOfComputer())
          return;

        Logics.ComputerHero.HandleLeveled();
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Hero.OnLevels", ex);
      }
    }
  }
}
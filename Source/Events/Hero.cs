using Source.Extensions;
using System;
using WCSharp.Api;

namespace Source.Events
{
  /// <summary>
  /// Stellt statische Methoden zum Behandeln von Helden-Events bereit.
  /// </summary>
  internal static class Hero
  {
    /// <summary>
    /// Behandelt den Levelaufsteig einer Heldeneinheit.
    /// </summary>
    internal static void OnLevels()
    {
      try
      {
        unit unit = Common.GetLevelingUnit();

        if (!unit.IsUnitOfComputer())
          return;

        Logics.ComputerHero.HandleLeveled(unit);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("Hero.OnLevels", ex);
      }
    }
  }
}
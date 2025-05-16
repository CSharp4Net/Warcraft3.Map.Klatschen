using WCSharp.Api;

namespace Source.Extensions
{
  internal static class unitExtension
  {
    internal static bool IsHero(this unit unit)
    {
      return unit.IsUnitType(unittype.Hero);
    }

    internal static bool IsUnitOfUser(this unit unit)
    {
      return unit.Owner.Controller == mapcontrol.User;
    }

    internal static bool IsUnitOfComputer(this unit unit)
    {
      return unit.Owner.Controller == mapcontrol.Computer;
    }

    internal static bool IsUnitOfCreep(this unit unit)
    {
      return unit.Owner.Controller == mapcontrol.Creep;
    }
  }
}

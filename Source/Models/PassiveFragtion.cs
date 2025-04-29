using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class PassiveFragtion : FragtionBase
  {
    public PassiveFragtion(player initialPlayer)
      : base(initialPlayer)
    {

    }

    public void ChangeOwner(Team team)
    {
      Wc3Player = team.Computer.Wc3Player;

      // TODO : Change owner of all units and start spawn trigger
    }
  }
}
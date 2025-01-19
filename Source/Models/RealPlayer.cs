using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class RealPlayer : PlayerBase
  {
    public RealPlayer(player player, Team team)
      : base(player)
    {
      Team = team;
    }

    public Team Team { get; init; }
  }
}

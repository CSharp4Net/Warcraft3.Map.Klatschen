using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class UserPlayer : PlayerBase
  {
    public UserPlayer(player player, Team team)
      : base(player)
    {
      Team = team;
    }

    public Team Team { get; init; }
  }
}

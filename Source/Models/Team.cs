using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class Team
  {
    public Team(player computerPlayer)
    {
      Computer = new ComputerPlayer(computerPlayer, this);
    }

    public ComputerPlayer Computer { get; init; }

    public List<RealPlayer> AlliedPlayers { get; set; }
  }
}

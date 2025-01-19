using Source.Abstracts;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class ComputerPlayer : PlayerBase
  {
    public ComputerPlayer(player player, Team team)
      : base(player)
    {
      Team = team;
    }

    public Team Team { get; init; }

    public List<unit> Buildings { get; init; } = new List<unit>();

    public unit CreateBuilding(int unitTypeId, Area area, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      unit unit = Common.CreateUnitAtLoc(Player, Constants.UNIT_TESTSOLDIER, area.CenterLocation, face);
      Buildings.Add(unit);
      return unit;
    }

  }
}

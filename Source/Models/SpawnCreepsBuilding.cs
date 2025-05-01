using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnCreepsBuilding
  {
    public SpawnCreepsBuilding(player player, int unitTypeId, Area creationArea, float face = 0f)
    {
      Wc3Unit = Common.CreateUnitAtLoc(player, unitTypeId, creationArea.Wc3CenterLocation, face);
      Wc3Player = player;
      SpawnTriggers = new List<SpawnTrigger>();
    }

    /// <summary>
    /// WC3-Einheit zu diesem Gebäude.
    /// </summary>
    public unit Wc3Unit { get; init; }

    /// <summary>
    /// Der Computer-Spieler, dem dieses Gebäude gehört.
    /// </summary>
    private player Wc3Player { get; init; }

    /// <summary>
    /// Auflistung von Spawn-Triggers.
    /// </summary>
    private List<SpawnTrigger> SpawnTriggers { get; init; }
  }
}
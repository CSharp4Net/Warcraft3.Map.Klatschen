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

    private List<SpawnTrigger> SpawnTriggers { get; init; } = new List<SpawnTrigger>();

    public unit CreateBuilding(int unitTypeId, Area area, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      unit unit = Common.CreateUnitAtLoc(Player, unitTypeId, area.CenterLocation, face);
      Buildings.Add(unit);
      return unit;
    }

    public void AddSpawnTrigger(float interval, Area spawnArea, params int[] unitIds)
    {
      SpawnTrigger trigger = new SpawnTrigger(this, interval, spawnArea, unitIds);
      SpawnTriggers.Add(trigger);
      trigger.Run();
    }

    public override void Defeat()
    {
      foreach (unit unit in Buildings)
      {
        unit.Kill();
      }

      foreach (SpawnTrigger trigger in SpawnTriggers)
      {
        trigger.Stop();
      }

      base.Defeat();
    }
  }
}

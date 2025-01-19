using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnTrigger
  {
    public SpawnTrigger(ComputerPlayer player, float interval, Area spawnArea, params int[] unitIds)
    {
      Player = player;
      Interval = interval;
      SpawnArea = spawnArea;
      UnitIds = unitIds.ToList();
    }

    public ComputerPlayer Player { get; init; }

    public float Interval { get; init; }

    public Area SpawnArea { get; init; }

    public List<int> UnitIds { get; init; }

    public timer Timer { get; private set; }

    public void Run()
    {
      Timer = timer.Create();
      Timer.Start(Interval, true, Elapsed);
    }

    public void Elapsed()
    {
      foreach (int unitId in UnitIds)
      {
        Player.CreateUnit(unitId, SpawnArea);
      }
    }

    public void Stop()
    {
      Timer.Pause();
      Timer.Dispose();
      Timer = null;
    }
  }
}

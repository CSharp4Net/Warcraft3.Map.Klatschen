using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnTrigger
  {
    public SpawnTrigger(ComputerPlayer player, float interval, Area spawnArea, SpawnedBuilding building = null, params int[] unitIds)
    {
      Player = player;
      Interval = interval;
      SpawnArea = spawnArea;
      Building = building;
      UnitIds = unitIds.ToList();
    }

    public ComputerPlayer Player { get; init; }

    public SpawnedBuilding Building { get; init; }

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
      try
      {
        foreach (int unitId in UnitIds)
        {
          Player.CreateUnit(unitId, SpawnArea);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
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

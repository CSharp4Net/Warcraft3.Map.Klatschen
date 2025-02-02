using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static Source.Models.Enums;

namespace Source.Models
{
  public sealed class SpawnTrigger
  {
    public SpawnTrigger(ComputerPlayer player, float interval, Area spawnArea, UnitSpawnType unitSpawnType, SpawnBuilding building, params int[] unitIds)
    {
      Player = player;
      Interval = interval;
      SpawnArea = spawnArea;
      Building = building;
      UnitSpawnType = unitSpawnType;
      UnitIds = unitIds.ToList();
    }

    private ComputerPlayer Player { get; init; }

    private SpawnBuilding Building { get; init; }

    private float Interval { get; init; }

    private Area SpawnArea { get; init; }

    private List<int> UnitIds { get; init; }

    private timer Timer { get; set; }

    /// <summary>
    /// Typ der erstellenden Einheiten.
    /// </summary>
    public Enums.UnitSpawnType UnitSpawnType { get; init; }

    /// <summary>
    /// Startet den Trigger im angegebenen Interval
    /// </summary>
    public void Run(float delay = 0f)
    {
      // Delay a little since some stuff can break otherwise
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        Start();
      });
    }

    private void Start()
    {
      Timer = timer.Create();
      Timer.Start(Interval, true, Elapsed);
    }

    /// <summary>
    /// Wird vom Trigger im angegeben Interval abgearbeitet.
    /// </summary>
    private void Elapsed()
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

    /// <summary>
    /// Stoppt den Trigger und zerstört ihn für den GC.
    /// </summary>
    public void Stop()
    {
      Timer.Pause();
      Timer.Dispose();
      Timer = null;
    }

    public void Add(SpawnUnitCommand spawnCommand)
    {
      UnitIds.Add(spawnCommand.UnitId);
    }

    public void Upgrade(SpawnUnitCommand spawnCommand)
    {
      for (int i = 0; i < UnitIds.Count; i++)
      {
        if (UnitIds[i] == spawnCommand.UnitIdToUpgrade)
          UnitIds[i] = spawnCommand.UnitId;
      }
    }
  }
}

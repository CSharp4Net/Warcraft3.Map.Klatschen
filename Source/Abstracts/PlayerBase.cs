using Source.Models;
using System;
using System.Collections.Generic;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Abstracts
{
  public abstract class PlayerBase : IDisposable
  {
    public PlayerBase(player player)
    {
      Player = player;
    }

    public player Player { get; init; }
    public List<unit> Units { get; init; } = new List<unit>();

    public unit CreateUnit(int unitTypeId, Area area, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      unit unit = Common.CreateUnitAtLoc(Player, Constants.UNIT_TESTSOLDIER, area.CenterLocation, face);
      Units.Add(unit);
      return unit;
    }

    public void Dispose()
    {
      for (int i = 0; i < Units.Count; i++)
      {
        unit unit = Units[i];
        Common.RemoveUnit(unit);
        unit.Dispose();
        unit = null;
        Units.RemoveAt(i);
      }
    }
  }
}
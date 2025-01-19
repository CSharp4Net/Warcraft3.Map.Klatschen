using Source.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Abstracts
{
  public abstract class PlayerBase
  {
    public PlayerBase(player player)
    {
      Player = player;
    }

    public player Player { get; init; }
    /// <summary>
    /// Auflistung alle Einheiten dieses Spielers
    /// </summary>
    public List<unit> Units { get; init; } = new List<unit>();

    /// <summary>
    /// Erstellt eine Einheit in einem Bereich und fügt sie der Auflist <see cref="Units"/> hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="area"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public unit CreateUnit(int unitTypeId, Area area, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      unit unit = Common.CreateUnitAtLoc(Player, unitTypeId, area.CenterLocation, face);
      Units.Add(unit);
      return unit;
    }

    public virtual void Defeat()
    {
      foreach (unit unit in Units)
      {
        unit.Kill();
      }

      Blizzard.MeleeDoDefeat(Player);
    }

    public virtual void Win()
    {
      foreach (unit unit in Units)
      {
        unit.ForceStopOrder();
        Common.RemoveUnit(unit);        
        unit.Dispose();
      }

      Blizzard.MeleeVictoryDialogBJ(Player, true);
    }
  }
}
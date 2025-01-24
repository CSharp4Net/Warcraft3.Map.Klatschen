using Source.Models;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Abstracts
{
  public abstract class PlayerBase
  {
    public PlayerBase(player wc3Player)
    {
      Wc3Player = wc3Player;
    }

    /// <summary>
    /// WC3-Spielerobjekt
    /// </summary>
    public player Wc3Player { get; init; }

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
      unit unit = Common.CreateUnitAtLoc(Wc3Player, unitTypeId, area.Wc3CenterLocation, face);
      Units.Add(unit);
      return unit;
    }

    public virtual void Defeat()
    {
      foreach (unit unit in Units)
      {
        unit.Kill();
      }

      Blizzard.MeleeDoDefeat(Wc3Player);
    }

    public virtual void Win()
    {
      foreach (unit unit in Units)
      {
        unit.ForceStopOrder();
        Common.RemoveUnit(unit);        
        unit.Dispose();
      }

      Blizzard.MeleeVictoryDialogBJ(Wc3Player, true);
    }

    public bool IsOwnerOfUnit(unit wc3Unit)
    {
      foreach (unit unit in Units)
      {
        if (unit == wc3Unit)        
          return true;        
      }

      return false;
    }
  }
}
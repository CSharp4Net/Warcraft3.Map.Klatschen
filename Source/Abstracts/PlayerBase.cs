using Source.Models;
using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Abstracts
{
  public abstract class PlayerBase
  {
    public PlayerBase(player wc3Player)
    {
      PlayerId = wc3Player.Id;
      Wc3Player = wc3Player;
    }

    public int PlayerId { get; init; }

    /// <summary>
    /// WC3-Spielerobjekt
    /// </summary>
    public player Wc3Player { get; init; }

    /// <summary>
    /// Auflistung aller Einheiten dieses Spielers
    /// </summary>
    private List<SpawnedUnit> Units { get; init; } = new List<SpawnedUnit>();

    public bool Defeated { get; private set; }

    /// <summary>
    /// Erstellt eine Einheit in einem Bereich und fügt sie der Auflist <see cref="Units"/> hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="area"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public SpawnedUnit CreateUnit(int unitTypeId, Area area, float face = 0f)
    {
      SpawnedUnit unit = new SpawnedUnit(this, unitTypeId, area, face);
      Units.Add(unit);
      return unit;
    }

    /// <summary>
    /// Tötet alle Einheiten des Spielers und setzt diesen auf "Besiegt"
    /// </summary>
    public virtual void Defeat()
    {
      for (int i = Units.Count - 1; i >= 0; i--)
      {
        Units[i].Kill();
      }

      Blizzard.MeleeDoDefeat(Wc3Player);

      Defeated = true;
    }

    /// <summary>
    /// Setzt den Spieler auf "Gewonnen"
    /// </summary>
    public virtual void Win()
    {
      //Program.ShowDebugMessage("PlayerBase.Defeat", $"Win WC3 player");
      Blizzard.MeleeVictoryDialogBJ(Wc3Player, true);
    }

    /// <summary>
    /// Gibt True zurück, wenn die übergebene Einheit in der Auflistung aller Einheiten enthalten ist
    /// </summary>
    /// <param name="wc3Unit"></param>
    /// <returns></returns>
    public bool IsOwnerOfUnit(unit wc3Unit, out SpawnedUnit unit)
    {
      if (wc3Unit.Owner.Id != PlayerId)
      {
        unit = null;
        return false;
      }

      foreach (SpawnedUnit spawnedUnit in Units)
      {
        if (spawnedUnit.Wc3Unit == wc3Unit)
        {
          unit = spawnedUnit;
          return true;
        }
      }

      // Dieser Fall kann eintreten, wenn eine statische Computer-Einheit das Event auslöst
      unit = null;
      return false;
    }

    /// <summary>
    /// Entfernt eine Einhaut aus der Auflistung aller Einheiten.
    /// </summary>
    /// <param name="unit"></param>
    public void RemoveUnit(SpawnedUnit unit)
    {
      Units.Remove(unit);
    }
  }
}
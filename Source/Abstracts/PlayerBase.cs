using Source.Models;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
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
    /// Auflistung aller Einheiten dieses Spielers
    /// </summary>
    private List<unit> Units { get; init; } = new List<unit>();

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

    /// <summary>
    /// Tötet alle Einheiten des Spielers und setzt diesen auf "Besiegt"
    /// </summary>
    public virtual void Defeat()
    {
      //Program.ShowDebugMessage("PlayerBase.Defeat", $"Kill units in list...");
      for (int i = Units.Count - 1; i >= 0; i--)
      {
        Units[i].Kill();
      }

      //Program.ShowDebugMessage("PlayerBase.Defeat", $"Defeat WC3 player");
      Blizzard.MeleeDoDefeat(Wc3Player);
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
    public bool IsOwnerOfUnit(unit wc3Unit)
    {
      foreach (unit unit in Units)
      {
        if (unit == wc3Unit)
          return true;
      }

      return false;
    }

    /// <summary>
    /// Entfernt eine Einhaut aus der Auflistung aller Einheiten.
    /// </summary>
    /// <param name="unit"></param>
    public void RemoveUnit(unit unit)
    {
      Units.Remove(unit);
    }
  }
}
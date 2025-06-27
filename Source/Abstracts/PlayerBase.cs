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

    /// <summary>
    /// Id des WC3-Spielerobjekt
    /// </summary>
    public int PlayerId { get; init; }

    /// <summary>
    /// WC3-Spielerobjekt
    /// </summary>
    public player Wc3Player { get; init; }

    /// <summary>
    /// Auflistung aller Einheiten dieses Spielers
    /// </summary>
    protected List<SpawnedUnit> Units { get; init; } = new List<SpawnedUnit>();

    /// <summary>
    /// Spieler wurde besiegt.
    /// </summary>
    public bool Defeated { get; private set; }

    /// <summary>
    /// Erstellt eine Einheit im Zentrum des Gebiets und fügt sie der Auflist <see cref="Units"/> hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="area"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public virtual SpawnedUnit CreateUnit(int unitTypeId, Area area, float face = 0f)
    {
      SpawnedUnit unit = new SpawnedUnit(Wc3Player, unitTypeId, area, face);
      Units.Add(unit);
      return unit;
    }

    /// <summary>
    /// Tötet alle Einheiten des Spielers und setzt dessen Status auf "Besiegt", damit endet für ihn das Spiel.
    /// </summary>
    public virtual void Defeat()
    {
      Blizzard.MeleeDoDefeat(Wc3Player);

      Defeated = true;
    }

    /// <summary>
    /// Setzt den Status des Spieler auf "Gewonnen", für diesen endet damit das Spiel.
    /// </summary>
    public virtual void Win()
    {
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

      int unitId = wc3Unit.UnitType;

      foreach (SpawnedUnit spawnedUnit in Units)
      {
        // Prüfe primär die Einheit-Id, da ein UNIT-Vergleich nicht empfohlen wird!
        // Ein Einheitenvergleich wird zwar nicht empfohlen, ist aber die einzige Möglichkeit diesselbe Einheit zu ermitteln
        if (spawnedUnit.Wc3Unit.UnitType == unitId && spawnedUnit.Wc3Unit == wc3Unit)
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
    /// Fügt der Auflistung erzeugter Einheiten einen Eintrag hinzu.
    /// </summary>
    /// <param name="unit"></param>
    internal void AddUnit(SpawnedUnit unit)
    {
      Units.Add(unit);
    }

    /// <summary>
    /// Entfernt eine Einheit aus der Auflistung erzeugter Einheiten.
    /// </summary>
    /// <param name="unit"></param>
    internal void RemoveUnit(SpawnedUnit unit)
    {
      Units.Remove(unit);
    }
  }
}
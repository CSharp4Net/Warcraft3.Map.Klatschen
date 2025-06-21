using System;

namespace Source.Models
{
  public static class Enums
  {
    public enum ResearchType
    {
      /// <summary>
      /// Unbekannt - konnte nicht ermittelt werden
      /// </summary>
      Unknown = 0,
      /// <summary>
      /// Allgemeines Upgrade bestehender Einheiten.
      /// </summary>
      CommonUpgrade = 1,
      /// <summary>
      /// Neue Einheit in Spawn-Intervalle aufnehmen
      /// </summary>
      AddUnit,
      /// <summary>
      /// Einheiten in Spawn-Intervallen aktualisieren
      /// </summary>
      UpgradeUnit
    }

    public enum UnitUpgradeType
    {
      /// <summary>
      /// Unbekannt - konnte nicht ermittelt werden
      /// </summary>
      Unknown = 0,
      /// <summary>
      /// Automatische Erstellung von Einheiten wird um neue Einheit ergänzt.
      /// </summary>
      AddNewUnitToSpawn = 1,
      /// <summary>
      /// Bestehende Einheit in automatischer Erstellung wird geändert.
      /// </summary>
      UpgradeUnitInSpawn = 2,
    }

    /// <summary>
    /// Stellt die verschiedenen Zeitintervalle dar, in denen Einheiten automatisch gespawned werden.
    /// </summary>
    public enum SpawnInterval
    {
      /// <summary>
      /// Kurzer Intervall
      /// </summary>
      Short = 0,
      /// <summary>
      /// Mittlerer Intervall
      /// </summary>
      Middle = 1,
      /// <summary>
      /// Langer Intervall
      /// </summary>
      Long = 2
    }
  }
}
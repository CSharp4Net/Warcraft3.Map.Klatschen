namespace Source.Models
{
  public static class Enums
  {
    public enum ResearchType
    {
      /// <summary>
      /// Allgemeines Upgrade bestehender Einheiten.
      /// </summary>
      CommonUpgrade = 0,
      /// <summary>
      /// Neue Einheit in Spawn-Intervalle aufnehmen
      /// </summary>
      AddUnit = 1,
      /// <summary>
      /// Einheiten in Spawn-Intervallen aktualisieren
      /// </summary>
      UpgradeUnit = 2
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
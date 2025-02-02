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

    public enum UnitSpawnType
    {
      /// <summary>
      /// Nahkampfeinheiten
      /// </summary>
      Meelee = 0,
      /// <summary>
      /// Fernkampfeinheiten
      /// </summary>
      Distance = 1
    }
  }
}
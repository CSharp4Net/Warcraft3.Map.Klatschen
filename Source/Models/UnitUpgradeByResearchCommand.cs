namespace Source.Models
{
  /// <summary>
  /// Model für den Upgrade-Befehl eines Unit-Spawns.
  /// Achtung: Dieser Befehl wird nur durch Forschung vom Computer-Spieler ausgelöst! 
  /// Er ist als Ersatz für fehlende menschliche Spieler im Team gedacht, um die Unit-Spawns dennoch zu verbessern.
  /// </summary>
  public sealed class UnitUpgradeByResearchCommand
  {
    /// <summary>
    /// Typ der zu spawnenden Einheit
    /// </summary>
    public Enums.SpawnInterval UnitSpawnType { get; set; }

    /// <summary>
    /// Id der Einheit, welche diese Einheit spawned
    /// </summary>
    public int UnitIdOfBuilding { get; set; }

    /// <summary>
    /// Id der neuen zu spawnenden Einheit
    /// </summary>
    public int UnitId { get; set; }

    /// <summary>
    /// Id der zu spawnenden Einheit, welche durch die neue <see cref="UnitId"/> ersetzt wird
    /// </summary>
    public int UnitIdToUpgrade { get; set; }
  }
}
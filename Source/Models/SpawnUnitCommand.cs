namespace Source.Models
{
  public sealed class SpawnUnitCommand
  {
    /// <summary>
    /// Typ der zu spawnenden Einheit
    /// </summary>
    public Enums.UnitClass UnitSpawnType { get; set; }

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
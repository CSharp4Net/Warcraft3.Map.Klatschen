﻿namespace Source.Models
{
  public sealed class AddOrUpgradeSpawnUnitCommand
  {
    public bool IsAddCommand { get; set; }

    /// <summary>
    /// Typ der zu spawnenden Einheit
    /// </summary>
    public Enums.SpawnInterval UnitSpawnType { get; set; }

    /// <summary>
    /// Id der neuen zu spawnenden Einheit
    /// </summary>
    public int NewUnitTypeId { get; set; }

    /// <summary>
    /// Id der zu spawnenden Einheit, welche durch die neue <see cref="UnitId"/> ersetzt wird
    /// </summary>
    public int OldUnitTypeId { get; set; }
  }
}
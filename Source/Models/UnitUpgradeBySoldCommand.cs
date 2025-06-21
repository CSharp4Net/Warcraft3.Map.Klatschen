namespace Source.Models
{
  /// <summary>
  /// Model für den Upgrade-Befehl eines Unit-Spawns.
  /// Achtung: Dieser Befehl wird nur durch Kauf von Einheinte durch menschliche Spieler ausgelöst!
  /// </summary>
  public sealed class UnitUpgradeBySoldCommand
  {
    /// <summary>
    /// Instanziiert einen Hinzufügen-Befehl, welcher die Spawn-Liste eines Triggers um eine Einheit ergänzt.
    /// </summary>
    /// <param name="spawnInterval"></param>
    /// <param name="newUnitTypeIdToAdd"></param>
    /// <param name="nextUnitTypeIdForShop"></param>
    public UnitUpgradeBySoldCommand(Enums.SpawnInterval spawnInterval, int newUnitTypeIdToAdd, int nextUnitTypeIdForShop)
    {
      IsAddCommand = true;
      SpawnInterval = spawnInterval;
      NewUnitTypeId = newUnitTypeIdToAdd;
      NextUnitTypeId = nextUnitTypeIdForShop;
    }
    /// <summary>
    /// Erstellt einen Aktualisieren-Befehl, welcher die Spawn-Liste eines Triggers aktualisiert und eine bestehende Einheit überschreibt.
    /// </summary>
    /// <param name="spawnInterval"></param>
    /// <param name="oldUnitTypeIdToReplace"></param>
    /// <param name="newUnitTypeIdToAdd"></param>
    /// <param name="nextUnitTypeIdForShop"></param>
    public UnitUpgradeBySoldCommand(Enums.SpawnInterval spawnInterval, int oldUnitTypeIdToReplace, int newUnitTypeIdToAdd, int nextUnitTypeIdForShop)
    {
      IsAddCommand = false;
      SpawnInterval = spawnInterval;
      OldUnitTypeId = oldUnitTypeIdToReplace;
      NewUnitTypeId = newUnitTypeIdToAdd;
      NextUnitTypeId = nextUnitTypeIdForShop;
    }

    public bool IsAddCommand { get; init; }

    /// <summary>
    /// Intervall-Typ des Triggers, welche für diese Einheit zuständig ist.
    /// </summary>
    public Enums.SpawnInterval SpawnInterval { get; init; }

    /// <summary>
    /// UnitType-Id der Einheit, welche im Trigger zu ersetzen ist.
    /// </summary>
    public int OldUnitTypeId { get; init; }

    /// <summary>
    /// UnitType-Id der Einheit, welche im Shop erworden wurde.
    /// </summary>
    public int NewUnitTypeId { get; init; }

    /// <summary>
    /// UnitType-Id der Einheit, welche im Anschluss im Shop zu erwerben ist.
    /// </summary>
    public int NextUnitTypeId { get; init; }
  }
}
using Source.Abstracts;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class ComputerPlayer : PlayerBase
  {
    public ComputerPlayer(player player, TeamBase team)
      : base(player)
    {
      Team = team;
    }

    /// <summary>
    /// Das Team, zu dem der Computer-Spieler gehört.
    /// </summary>
    public TeamBase Team { get; init; }

    private SpawnUnitsBuilding BaseBuilding { get; set; }

    private List<SpawnUnitsBuilding> BarrackBuildings { get; init; } = new List<SpawnUnitsBuilding>();

    public SpawnUnitsBuilding CreateBaseBuilding(int unitTypeId, Area creationArea, float face = 0f)
    {
      BaseBuilding = new SpawnUnitsBuilding(this, unitTypeId, creationArea, face);

      // TODO : Add items
      //BaseBuilding.Wc3Unit.AddItem

      return BaseBuilding;
    }

    /// <summary>
    /// Erzeugt ein Gebäude für den Spieler und fügt es der Auflistung aller Gebäude hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="creationArea"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public SpawnUnitsBuilding CreateBarrackBuilding(int unitTypeId, Area creationArea, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      SpawnUnitsBuilding building = new SpawnUnitsBuilding(this, unitTypeId, creationArea, face);

      // Upgrade-Items via Trigger hinzufügen, da diese nur dann auch via Trigger entfernt werden können
      //building.Wc3Unit.AddItemToStock(Constants.ITEM_MELEE_UNIT_LEVEL_2, 1, 1);
      building.Wc3Unit.AddUnitToStock(Constants.UNIT_CAPTAIN_HUMAN, 1, 1);

      BarrackBuildings.Add(building);

      return building;
    }

    /// <summary>
    /// Gibt True zurück, wenn der Spieler der Eigentümer der übergebenen Einheit ist.
    /// </summary>
    /// <param name="wc3Unit">WC3-Einheit</param>
    /// <param name="foundBuilding">Wird gesetzt, wenn True zurück gegeben wurde.</param>
    /// <returns></returns>
    public bool IsOwnerOfBuilding(unit wc3Unit, out SpawnUnitsBuilding foundBuilding)
    {
      foreach (SpawnUnitsBuilding building in BarrackBuildings)
      {
        if (building.Wc3Unit == wc3Unit)
        {
          foundBuilding = building;
          return true;
        }
      }

      foundBuilding = null;
      return false;
    }

    /// <summary>
    /// Entfernt ein Gebäude aus der Auflistung aller Gebäude.
    /// </summary>
    /// <param name="building"></param>
    public void RemoveBuilding(SpawnUnitsBuilding building)
    {
      //Program.ShowDebugMessage("ComputerPlayer.RemoveBuilding", $"Remove building {building.Wc3Unit.Name}");
      BarrackBuildings.Remove(building);
    }

    /// <summary>
    /// Zerstört und entfernt alle Gebäude des Computer-Spielers und setzt diesen auf "Besiegt".
    /// </summary>
    public override void Defeat()
    {
      // Alle gespawnten Gebäude zerstören
      for (int i = BarrackBuildings.Count - 1; i >= 0; i--)
      {
        SpawnUnitsBuilding building = BarrackBuildings[i];

        building.Destroy();

        RemoveBuilding(building);
      }

      base.Defeat();
    }

    public void AddSpawnUnit(SpawnUnitCommand spawnCommand)
    {
      foreach (SpawnUnitsBuilding building in BarrackBuildings)
      {
        if (building.Wc3Unit.UnitType == spawnCommand.UnitIdOfBuilding)
          building.AddUnitSpawn(spawnCommand);
      }
    }

    public void UpgradeSpawnUnit(SpawnUnitCommand spawnCommand)
    {
      foreach (SpawnUnitsBuilding building in BarrackBuildings)
      {
        if (building.Wc3Unit.UnitType == spawnCommand.UnitIdOfBuilding)
          building.UpgradeUnitSpawn(spawnCommand);
      }
    }
  }
}

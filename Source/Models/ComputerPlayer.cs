using Source.Abstracts;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class ComputerPlayer : PlayerBase
  {
    public ComputerPlayer(player player, Team team)
      : base(player)
    {
      Team = team;
    }

    /// <summary>
    /// Das Team, zu dem der Computer-Spieler gehört.
    /// </summary>
    private Team Team { get; init; }

    private List<SpawnBuilding> Buildings { get; init; } = new List<SpawnBuilding>();

    /// <summary>
    /// Erzeugt ein Gebäude für den Spieler und fügt es der Auflistung aller Gebäude hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="creationArea"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public SpawnBuilding CreateBuilding(int unitTypeId, Area creationArea, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      SpawnBuilding building = new SpawnBuilding(this, unitTypeId, creationArea, face);
      Buildings.Add(building);
      return building;
    }

    /// <summary>
    /// Gibt True zurück, wenn der Spieler der Eigentümer der übergebenen Einheit ist.
    /// </summary>
    /// <param name="wc3Unit">WC3-Einheit</param>
    /// <param name="foundBuilding">Wird gesetzt, wenn True zurück gegeben wurde.</param>
    /// <returns></returns>
    public bool IsOwnerOfBuilding(unit wc3Unit, out SpawnBuilding foundBuilding)
    {
      //Program.ShowDebugMessage("ComputerPlayer.IsOwnerOfBuilding", $"Find building in list...");
      foreach (SpawnBuilding building in Buildings)
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
    public void RemoveBuilding(SpawnBuilding building)
    {
      //Program.ShowDebugMessage("ComputerPlayer.RemoveBuilding", $"Remove building {building.Wc3Unit.Name}");
      Buildings.Remove(building);
    }

    /// <summary>
    /// Zerstört und entfernt alle Gebäude und Einheiten des Spielers und setzt diesen auf "Besiegt".
    /// </summary>
    public override void Defeat()
    {
      // Alle gespawnten Gebäude zerstören
      for (int i = Buildings.Count - 1; i >= 0; i--) 
      {
        SpawnBuilding building = Buildings[i];
        //Program.ShowDebugMessage("ComputerPlayer.Defeat", $"Destroy building {building.Wc3Unit.Name}");
        building.Destroy();
        //Program.ShowDebugMessage("ComputerPlayer.Defeat", $"Building destroyed.");
        RemoveBuilding(building);

      }

      base.Defeat();
    }
        
    public void AddSpawnUnit(SpawnUnitCommand spawnCommand)
    {
      foreach (SpawnBuilding building in Buildings)
      {
        if (building.Wc3Unit.UnitType == spawnCommand.UnitIdOfBuilding)
          building.AddUnitSpawn(spawnCommand);
      }
    }

    public void UpgradeSpawnUnit(SpawnUnitCommand spawnCommand)
    {
      foreach (SpawnBuilding building in Buildings)
      {
        if (building.Wc3Unit.UnitType == spawnCommand.UnitIdOfBuilding)
          building.UpgradeUnitSpawn(spawnCommand);
      }
    }
  }
}

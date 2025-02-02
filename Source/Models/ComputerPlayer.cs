using Source.Abstracts;
using Source.Extensions;
using System;
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

    private List<SpawnedBuilding> Buildings { get; init; } = new List<SpawnedBuilding>();

    /// <summary>
    /// Erzeugt ein Gebäude für den Spieler und fügt es der Auflistung aller Gebäude hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="creationArea"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public SpawnedBuilding CreateBuilding(int unitTypeId, Area creationArea, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      SpawnedBuilding building = new SpawnedBuilding(this, unitTypeId, creationArea, face);
      Buildings.Add(building);
      return building;
    }

    /// <summary>
    /// Gibt True zurück, wenn der Spieler der Eigentümer der übergebenen Einheit ist.
    /// </summary>
    /// <param name="wc3Unit">WC3-Einheit</param>
    /// <param name="foundBuilding">Wird gesetzt, wenn True zurück gegeben wurde.</param>
    /// <returns></returns>
    public bool IsOwnerOfBuilding(unit wc3Unit, out SpawnedBuilding foundBuilding)
    {
      //Program.ShowDebugMessage("ComputerPlayer.IsOwnerOfBuilding", $"Find building in list...");
      foreach (SpawnedBuilding building in Buildings)
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
    public void RemoveBuilding(SpawnedBuilding building)
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
        SpawnedBuilding building = Buildings[i];
        //Program.ShowDebugMessage("ComputerPlayer.Defeat", $"Destroy building {building.Wc3Unit.Name}");
        building.Destroy();
        //Program.ShowDebugMessage("ComputerPlayer.Defeat", $"Building destroyed.");
        RemoveBuilding(building);

      }

      base.Defeat();
    }

    /// <summary>
    /// Fügt dem Gebäude eine zusätzliche Einheit hinzu, welche im Intervall erstellt wird.
    /// </summary>
    /// <param name="wc3UnitIdOfSpawnBuilding">Gebäude-Id vom Spawn-Gebäude</param>
    /// <param name="researchedUnitId">Einheit-Id von der Einheit</param>
    public void AddSpawnUnit(int wc3UnitIdOfSpawnBuilding, int researchedUnitId)
    {
      foreach (SpawnedBuilding building in Buildings)
      {
        if (building.Wc3Unit.UnitType == wc3UnitIdOfSpawnBuilding)
          building.AddUnitSpawn(researchedUnitId);
      }
    }
  }
}

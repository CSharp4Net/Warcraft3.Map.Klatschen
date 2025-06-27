using Source.Abstracts;
using Source.Statics;
using System.Collections.Generic;

namespace Source.Models
{
  public sealed class MainBuilding : BuildingBase
  {
    public MainBuilding(ComputerPlayer computer, int unitTypeId, Area creationArea)
      : base(computer, unitTypeId, creationArea) { }

    private List<SpawnAttackRoute> Routes { get; init; } = new List<SpawnAttackRoute>();

    public void AddSpawnAttackRoute(Area spawnArea, Area targetArea)
    {
      Routes.Add(new SpawnAttackRoute(spawnArea, targetArea));
    }

    /// <summary>
    /// Erstellt einmalig eine Einheit für jede Lane und erteilt den Angriff/Bewegen-Befehl zur gegnerischen Base
    /// </summary>
    /// <param name="unitId"></param>
    public void CreateSingleUnitSpawn(int unitId)
    {
      foreach (SpawnAttackRoute route in Routes)
      {
        Computer.CreateUnit(unitId, route.SpawnArea).AttackMoveTimed(route.TargetArea, 0.5f);
      }
    }
  }
}
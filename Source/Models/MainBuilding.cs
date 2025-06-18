using Source.Abstracts;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class MainBuilding : BuildingBase
  {
    public MainBuilding(ComputerPlayer computer, int unitTypeId, Area creationArea)
      : base(computer, unitTypeId, creationArea) { }

    private List<SpawnAttackRoute> Routes { get; set; } = new List<SpawnAttackRoute>();

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
      foreach   (SpawnAttackRoute route in Routes)
      {
        Computer.CreateUnit(unitId, route.SpawnArea).AttackMove(route.TargetArea);
      }     
    }
  }
}
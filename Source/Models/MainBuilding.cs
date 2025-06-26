using Source.Abstracts;
using Source.Statics;
using System.Collections.Generic;

namespace Source.Models
{
  public sealed class MainBuilding : BuildingBase
  {
    public MainBuilding(ComputerPlayer computer, int unitTypeId, Area creationArea, string specialEffectPath)
      : base(computer, unitTypeId, creationArea) 
    {
      SpecialEffectPath = specialEffectPath;
    }

    private List<SpawnAttackRoute> Routes { get; init; } = new List<SpawnAttackRoute>();

    private string SpecialEffectPath { get; init; }

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
        SpecialEffects.CreateSpecialEffect(SpecialEffectPath, route.SpawnArea.Wc3Rectangle.Center, 1f, 0.5f);
        Computer.CreateUnit(unitId, route.SpawnArea).AttackMoveTimed(route.TargetArea, 0.5f);
      }
    }
  }
}
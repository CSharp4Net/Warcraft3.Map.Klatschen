using Source.Abstracts;
using Source.Events.Buildings;
using Source.Statics;
using System;
using System.Collections.Generic;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class MercenaryForce : NeutralForce
  {
    public MercenaryForce(string name, Area buildingArea, Area spawnArea, TeamBase nearTeam, TeamBase opposingTeam, int buildingUnitTypeId, params int[] defenderUnitTypeIds)
      : base(player.NeutralAggressive)
    {
      Name = name;
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Gold}{name}|r";
      SpawnArea = spawnArea;
      BuildingArea = buildingArea;
      NearTeam = nearTeam;
      OpposingTeam = opposingTeam;
      BuildingUnitTypeId = buildingUnitTypeId;
      DefenderUnitTypeIds = defenderUnitTypeIds;
    }

    /// <summary>
    /// Name des Söldnerlagers mit Farberweiterung.
    /// </summary>
    public string ColorizedName { get; init; }
    /// <summary>
    /// Name des Söldnerlagers, welcher in Nachrichten angezeigt wird.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gebiet, in dem automatisiert Einheiten für den Besitzer erstellt werden.
    /// </summary>
    public Area SpawnArea { get; init; }
    /// <summary>
    /// Gebiet, in dem das Hauptgebäude des Söldnerlagers erstellt wird.
    /// </summary>
    public Area BuildingArea { get; init; }
    /// <summary>
    /// Gebiet, welches das Angriff/Bewegen-Befehl der automatisch erstellten Einheiten ist.
    /// </summary>
    public Area AttackTargetArea { get; private set; }

    /// <summary>
    /// Computer-Spieler im Quadrant
    /// </summary>
    public TeamBase NearTeam { get; init; }
    /// <summary>
    /// Computer-Spieler im gegenüberliegenden Quadrant
    /// </summary>
    public TeamBase OpposingTeam { get; init; }

    /// <summary>
    /// Unit-Id des Spawn-Gebäudes, welches die Einheiten automatisch erstellt und das Hauptgebäude des Lagers ist.
    /// </summary>
    public int BuildingUnitTypeId { get; private set; }
    /// <summary>
    /// Unit-Id der mächtigen Einheit, welche das Spawn-Gebäude beacht.
    /// </summary>
    public int[] DefenderUnitTypeIds { get; private set; }

    /// <summary>
    /// Spawn-Gebäude, welches die Einheiten automatisch erstellt und das Hauptgebäude des Lagers ist.
    /// </summary>
    public MercenarySpawnBuilding Building { get; private set; }
    /// <summary>
    /// Auflistung von verteidigenden Einheiten.
    /// </summary>
    public List<SpawnedCreep> DefenderCreeps { get; private set; } = new List<SpawnedCreep>();

    /// <summary>
    /// Team, für das das Söldnerlager automatisch Einheiten erstellt.
    /// </summary>
    public TeamBase OwnerTeam { get; private set; }

    /// <summary>
    /// Erstellt das Spawn-Gebäude des Söldnerlagers.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public MercenarySpawnBuilding InitializeBuilding()
    {
      // Ort anhand Zentrum einer Region erstellen
      Building = new MercenarySpawnBuilding(this, BuildingUnitTypeId, BuildingArea, 0f);
      Building.RegisterOnDies(MercenaryBuilding.OnDies);

      CreateDefenderUnits(false);

      return Building;
    }

    /// <summary>
    /// Setzt den Eigentümer des Söldnerlagers und erstellt ein neues Spawn-Gebäude.
    /// </summary>
    /// <param name="team">Neues Eigentümer-Team</param>
    /// <param name="attackTargetForSpawn">Gebiet, welches das Angriff/Bewegen-Befehl der automatisch erstellten Einheiten ist.</param>
    public void SetOwnerAndRebuild(TeamBase team, Area attackTargetForSpawn)
    {
      OwnerTeam = team;
      AttackTargetArea = attackTargetForSpawn;

      Wc3Player = OwnerTeam.Computer.Wc3Player;

      Program.ShowDebugMessage($"Build building {BuildingUnitTypeId} at {BuildingArea.ToString()}");
      // Ort anhand Zentrum einer Region erstellen
      Building = new MercenarySpawnBuilding(this, BuildingUnitTypeId, BuildingArea, 0f);
      Building.RegisterOnDies(MercenaryBuilding.OnDies);

      CreateDefenderUnits(true);

      // Füge direkt SpawnTrigger hinzu, welche später durch kaufen von Söldnern um Einheiten erweitert werden
      Building.AddSpawnTrigger(Enums.SpawnInterval.Middle, SpawnArea, AttackTargetArea).Run();
    }

    private void CreateDefenderUnits(bool withSpecialEffect)
    {
      Rectangle rectangle = SpawnArea.Wc3Rectangle;

      foreach (int unitTypeId in DefenderUnitTypeIds)
      {
        Point point = rectangle.GetRandomPoint();
        DefenderCreeps.Add(SpawnUnitAtPoint(point, unitTypeId));

        if (withSpecialEffect)
          SpecialEffects.CreateSpecialEffect("UI\\Feedback\\GoldCredit\\GoldCredit.mdl", point, 1f, 1f);
      }
    }
  }
}
using Source.Abstracts;
using Source.Events.Buildings;
using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class CreepCamp : NeutralForce
  {
    public CreepCamp(string name, Area buildingArea, Area spawnArea, TeamBase nearTeam, TeamBase opposingTeam)
      : base(player.NeutralAggressive)
    {
      Name = name;
      ColorizedName = $"|c{ConstantsEx.ColorHexCode_Gold}{name}|r";
      SpawnArea = spawnArea;
      BuildingArea = buildingArea;
      NearTeam = nearTeam;
      OpposingTeam = opposingTeam;
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
    public int BuildingUnitType { get; private set; }
    /// <summary>
    /// Unit-Id der mächtigen Einheit, welche das Spawn-Gebäude beacht.
    /// </summary>
    public int DefenderUnitType { get; private set; }

    /// <summary>
    /// Spawn-Gebäude, welches die Einheiten automatisch erstellt und das Hauptgebäude des Lagers ist.
    /// </summary>
    public SpawnCreepsBuilding Building { get; private set; }

    /// <summary>
    /// Team, für das das Söldnerlager automatisch Einheiten erstellt.
    /// </summary>
    public TeamBase OwnerTeam { get; private set; }

    public void CreateHero(int unitTypeId, int heroLevel = 1, float face = 0f)
    {
      CreateHero(unitTypeId, SpawnArea, heroLevel, face, AttackTargetArea);
    }

    public void ReviveHero(int heroLevel = 1, float face = 0f)
    {
      ReviveHero(SpawnArea, heroLevel, face, AttackTargetArea);
    }

    /// <summary>
    /// Erstellt das Spawn-Gebäude des Söldnerlagers.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public SpawnCreepsBuilding InitializeBuilding(int unitTypeId, int defenderUnitType, float face = 0f)
    {
      BuildingUnitType = unitTypeId;
      DefenderUnitType = defenderUnitType;

      // Ort anhand Zentrum einer Region erstellen
      Building = new SpawnCreepsBuilding(this, unitTypeId, BuildingArea, face);
      Building.RegisterOnDies(CreepMainBuilding.OnDies);

      SpawnUnitInAreaAtRandomPoint(DefenderUnitType);

      return Building;
    }

    /// <summary>
    /// Erzeugt im Spawn-Bereich eine Einheit an einem zufällig Punkt.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <returns></returns>
    public SpawnedCreep SpawnUnitInAreaAtRandomPoint(int unitTypeId)
    {
      Point point = SpawnArea.Wc3Rectangle.GetRandomPoint();

      return new SpawnedCreep(this, unitTypeId, SpawnArea);
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

      Program.ShowDebugMessage($"Build building {BuildingUnitType} at {BuildingArea.ToString()}");
      // Ort anhand Zentrum einer Region erstellen
      Building = new SpawnCreepsBuilding(this, BuildingUnitType, BuildingArea, 0f);
      Building.RegisterOnDies(CreepMainBuilding.OnDies);

      SpawnUnitInAreaAtRandomPoint(DefenderUnitType);

      // Füge direkt SpawnTrigger hinzu, welche später durch kaufen von Söldnern um Einheiten erweitert werden
      Building.InitializeSpawnTrigger(Enums.SpawnInterval.Middle, AttackTargetArea)
        .Run();
    }
  }
}
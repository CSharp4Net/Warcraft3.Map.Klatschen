using Source.Abstracts;
using Source.Events.Buildings;
using System;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class CreepCamp : NeutralForce
  {
    public CreepCamp(string campName, Area campBuilding, Area campSpawnArea, ComputerPlayer nearestForce, ComputerPlayer opposingForce)
      : base(player.NeutralAggressive)
    {
      Name = campName;
      SpawnArea = campSpawnArea;
      BuildingArea = campBuilding;
      NearestForce = nearestForce;
      OpposingForce = opposingForce;
    }

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
    public ComputerPlayer NearestForce { get; init; }
    /// <summary>
    /// Computer-Spieler im gegenüberliegenden Quadrant
    /// </summary>
    public ComputerPlayer OpposingForce { get; init; }

    /// <summary>
    /// Spawn-Gebäude, welches die Einheiten automatisch erstellt und das Hauptgebäude des Lagers ist.
    /// </summary>
    public SpawnCreepsBuilding Building { get; private set; }

    /// <summary>
    /// Team, für das das Söldnerlager automatisch Einheiten erstellt.
    /// </summary>
    public TeamBase OwnerTeam { get; private set; }

    /// <summary>
    /// Erstellt einen Helden im Spawn-Bereich des Söldnerlagers.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="face"></param>
    public void InitializeHero(int unitTypeId, float face = 0f)
    {
      CreateOrReviveHero(unitTypeId, SpawnArea, Hero.HeroLevel, face);
    }

    /// <summary>
    /// Erstellt das Spawn-Gebäude des Söldnerlagers.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public SpawnCreepsBuilding InitializeBuilding(int unitTypeId, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      Building = new SpawnCreepsBuilding(this, unitTypeId, BuildingArea, face);
      Building.RegisterOnDies(CreepMainBuilding.OnDies);

      return Building;
    }

    /// <summary>
    /// Belebt den Helden im Spawn-Bereich des Söldnerlagers wieder.
    /// </summary>
    public void ReviveHero()
    {
      CreateOrReviveHero(Hero.UnitType, SpawnArea, Hero.HeroLevel, 0f);
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

      // Ort anhand Zentrum einer Region erstellen
      Building = new SpawnCreepsBuilding(this, Building.Wc3Unit.UnitType, BuildingArea, 0f);
      Building.RegisterOnDies(CreepMainBuilding.OnDies);

      // Füge direkt SpawnTrigger hinzu, welche später durch kaufen von Söldnern um Einheiten erweitert werden
      Building.InitializeSpawnTrigger(Enums.SpawnInterval.Middle, AttackTargetArea)
        .Run();
    }
  }
}
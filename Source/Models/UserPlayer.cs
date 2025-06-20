﻿using Source.Abstracts;
using System.Xml.Linq;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class UserPlayer : PlayerBase
  {
    public UserPlayer(player player, TeamBase team)
      : base(player)
    {
      Team = team;
    }

    /// <summary>
    /// Team des Benutzers
    /// </summary>
    public TeamBase Team { get; init; }

    public int HeroLevelCounter { get; set; } = 0;

    public void ApplyCamera(Area targetArea)
    {
      camerasetup setup = Common.CreateCameraSetup();

      setup.SetPosition(targetArea.CenterX, targetArea.CenterY);

      Blizzard.CameraSetupApplyForPlayer(true, setup, Wc3Player, 0.0f);
    }

    /// <summary>
    /// Erstellt eine Held für den Benutzer im angegebenen Gebiet.
    /// </summary>
    /// <param name="unitId"></param>
    /// <param name="spawnArea"></param>
    public void CreateHero(int unitId, Area spawnArea)
    {
      unit unit = Common.CreateUnitAtLoc(Wc3Player, unitId, spawnArea.Wc3CenterLocation, 0f);

      if (HeroLevelCounter > 0)
        // Ggf. Level des vorherigen Helden wiederherstellen
        unit.HeroLevel = HeroLevelCounter;

      // Spieler-Kamera auf Helden fokussieren
      ApplyCamera(spawnArea);

      // Helden auswählen
      Blizzard.SelectUnitForPlayerSingle(unit, Wc3Player);
    }

    /// <summary>
    /// Zerstört und entfernt alle Gebäude und Einheiten des Spielers und setzt diesen auf "Besiegt".
    /// </summary>
    public override void Defeat()
    {
      for (int i = Units.Count - 1; i >= 0; i--)
      {
        Units[i].Kill();
      }

      base.Defeat();
    }
  }
}

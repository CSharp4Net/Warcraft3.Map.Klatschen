using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class UserPlayer : PlayerBase
  {
    public UserPlayer(player player, Team team)
      : base(player)
    {
      Team = team;
    }

    /// <summary>
    /// Team des Benutzers
    /// </summary>
    public Team Team { get; init; }

    public int HeroLevelCounter { get; set; } = 50;

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
        unit.HeroLevel = HeroLevelCounter;

      ApplyCamera(spawnArea);
      Blizzard.SelectUnitForPlayerSingle(unit, Wc3Player);
    }
  }
}

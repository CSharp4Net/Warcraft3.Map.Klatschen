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

    public int HeroLevelCounter { get; set; }
    private unit Wc3Hero { get; set; }

    public void ApplyCamera(Area targetArea)
    {
      camerasetup setup = Common.CreateCameraSetup();

      setup.SetPosition(targetArea.Wc3CenterLocation.X, targetArea.Wc3CenterLocation.Y);

      Blizzard.CameraSetupApplyForPlayer(true, setup, Wc3Player, 0.0f);
    }

    /// <summary>
    /// Erstellt eine Held für den Benutzer im angegebenen Gebiet.
    /// </summary>
    /// <param name="unitId"></param>
    /// <param name="spawnArea"></param>
    public void CreateHero(int unitId, Area spawnArea)
    {
      Wc3Hero = CreateUnit(unitId, spawnArea).Wc3Unit;

      if (HeroLevelCounter > 0)
        Wc3Hero.HeroLevel = HeroLevelCounter;

      ApplyCamera(spawnArea);
      Blizzard.SelectUnitForPlayerSingle(Wc3Hero, Wc3Player);
    }

    /// <summary>
    /// Belebt den toten Held des Benutzers im angegebenen Gebiet wieder.
    /// </summary>
    /// <param name="spawnArea"></param>
    public void ReviveHero(Area spawnArea)
    {
      Common.ReviveHero(Wc3Hero, spawnArea.Wc3CenterLocation.X, spawnArea.Wc3CenterLocation.Y, true);
      
      ApplyCamera(Areas.UndeadBaseHeroRespawn);
      Blizzard.SelectUnitForPlayerSingle(Wc3Hero, Wc3Player);
    }
  }
}

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

    public Team Team { get; init; }

    public void ApplyCamera(Area targetArea)
    {
      camerasetup setup = Common.CreateCameraSetup();

      setup.SetPosition(targetArea.Wc3CenterLocation.X, targetArea.Wc3CenterLocation.Y);

      Blizzard.CameraSetupApplyForPlayer(true, setup, Wc3Player, 0.0f);
    }
  }
}

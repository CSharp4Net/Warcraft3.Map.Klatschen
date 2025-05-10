using Source.Models;
using WCSharp.Api;

namespace Source.Abstracts
{
  public abstract class NeutralForce
  {
    public NeutralForce(player wc3ComputerPlayer)
    {
      Wc3Player = wc3ComputerPlayer;
    }

    public player Wc3Player { get; protected set; }

    public unit Hero { get; private set; }

    protected void CreateOrReviveHero(int unitTypeId, Area spawnArea, int heroLevel, float delay)
    {
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {

        if (Hero == null)
        {
          Hero = Common.CreateUnitAtLoc(Wc3Player, unitTypeId, spawnArea.Wc3CenterLocation, 0f);
        }
        else
        {
          Common.ReviveHero(Hero, spawnArea.CenterX, spawnArea.CenterY, true);
        }

        Hero.HeroLevel = heroLevel;
      });
    }
  }
}

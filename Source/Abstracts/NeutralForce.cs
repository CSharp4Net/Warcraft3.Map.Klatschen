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

    public SpawnedCreep Hero { get; private set; }

    /// <summary>
    /// Erstellt eine neue Heldeinheit oder belebt die Heldeinheit wieder und setzt das Heldenlevel.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="spawnArea"></param>
    /// <param name="heroLevel"></param>
    /// <param name="delay"></param>
    protected void CreateHero(int unitTypeId, Area spawnArea, int heroLevel, float delay, Area targetArea = null)
    {
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        Hero = new SpawnedCreep(this, unitTypeId, spawnArea, 0f);
        Hero.Wc3Unit.HeroLevel = heroLevel;

        if (targetArea != null)
          Hero.AttackMove(targetArea);
      });
    }

    /// <summary>
    /// Erstellt eine neue Heldeinheit oder belebt die Heldeinheit wieder und setzt das Heldenlevel.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="spawnArea"></param>
    /// <param name="heroLevel"></param>
    /// <param name="delay"></param>
    protected void ReviveHero(Area spawnArea, int heroLevel, float delay, Area targetArea = null)
    {
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        Common.ReviveHero(Hero.Wc3Unit, spawnArea.CenterX, spawnArea.CenterY, true);

        Hero.Wc3Unit.HeroLevel = heroLevel;
        Hero.Wc3Unit.Mana = Hero.Wc3Unit.MaxMana;

        if (targetArea != null)
          Hero.AttackMove(targetArea);
      });
    }
  }
}

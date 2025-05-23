using Source.Models;
using WCSharp.Api;
using WCSharp.Shared.Data;

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
    /// Erstellt nach festgelegter Wartezeit eine neue Heldeinheit setzt das Heldenlevel.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="spawnArea"></param>
    /// <param name="heroLevel"></param>
    /// <param name="delay"></param>
    /// <param name="targetArea"></param>
    protected void CreateHeroTimed(int unitTypeId, Area spawnArea, int heroLevel, float delay, Area targetArea = null)
    {
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        CreateHero(unitTypeId, spawnArea, heroLevel, targetArea);
      });
    }
    /// <summary>
    /// Erstellt eine neue Heldeinheit oder belebt die Heldeinheit wieder und setzt das Heldenlevel.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="spawnArea"></param>
    /// <param name="heroLevel"></param>
    /// <param name="targetArea"></param>
    protected void CreateHero(int unitTypeId, Area spawnArea, int heroLevel, Area targetArea = null)
    {
      Hero = new SpawnedCreep(this, unitTypeId, spawnArea.Wc3Rectangle.Center, 0f);
      Hero.Wc3Unit.HeroLevel = heroLevel;

      if (targetArea != null)
        Hero.AttackMove(targetArea);
    }

    /// <summary>
    /// Wiederbelebt nach festgelegter Wartzeit eine Heldeinheit und setzt das Heldenlevel.
    /// </summary>
    /// <param name="spawnArea"></param>
    /// <param name="heroLevel"></param>
    /// <param name="delay"></param>
    /// <param name="targetArea"></param>
    protected void ReviveHeroTimed(Area spawnArea, int heroLevel, float delay, Area targetArea = null)
    {
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        ReviveHero(spawnArea, heroLevel, targetArea);
      });
    }
    /// <summary>
    /// Wiederbelebt eine  Heldeinheit und setzt das Heldenlevel.
    /// </summary>
    /// <param name="spawnArea"></param>
    /// <param name="heroLevel"></param>
    /// <param name="targetArea"></param>
    protected void ReviveHero(Area spawnArea, int heroLevel, Area targetArea = null)
    {
      Common.ReviveHero(Hero.Wc3Unit, spawnArea.CenterX, spawnArea.CenterY, true);

      Hero.Wc3Unit.HeroLevel = heroLevel;
      Hero.Wc3Unit.Mana = Hero.Wc3Unit.MaxMana;

      if (targetArea != null)
        Hero.AttackMove(targetArea);
    }

    /// <summary>
    /// Erzeugt im Spawn-Bereich eine Einheit an einem definierten Punkt.
    /// </summary>
    /// <param name="point">Punkt</param>
    /// <param name="unitTypeId">Einheit-Typ</param>
    /// <returns></returns>
    public virtual SpawnedCreep SpawnUnitAtPoint(Point point, int unitTypeId)
    {
      return new SpawnedCreep(this, unitTypeId, point);
    }
  }
}

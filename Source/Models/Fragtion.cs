using WCSharp.Api;

namespace Source.Models
{
  public sealed class Fragtion
  {
    public Fragtion(player wc3ComputerPlayer)
    {
      Wc3Player = wc3ComputerPlayer;
    }

    public player Wc3Player { get; init; }

    public unit Hero { get; private set; }

    public void CreateOrReviveHero(int unitTypeId, Area spawnArea, int heroLevel, int abilitiesLevel, float delay)
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

        // MTA @ 2025-03-07 : Erstmal gehen wir stur davon aus, dass Neutrale Helden immer stets 3 Fähigkeiten haben...
        Hero.SetAbilityLevel(Hero.GetAbilityByIndex(0).Id, abilitiesLevel);
        Hero.SetAbilityLevel(Hero.GetAbilityByIndex(1).Id, abilitiesLevel);
        Hero.SetAbilityLevel(Hero.GetAbilityByIndex(2).Id, abilitiesLevel);

        // TODO : Computer-Helden zaubern NICHT automatisch Heldenzauber, sondern lediglich einfacher Unit-Zauber?
      });
    }
  }
}
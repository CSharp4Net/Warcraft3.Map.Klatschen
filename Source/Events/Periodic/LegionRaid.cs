using Source.Models;
using Source.Statics;
using System;
using System.Linq;
using WCSharp.Api;
using WCSharp.Lightnings;
using WCSharp.Shared.Data;

namespace Source.Events.Periodic
{
  internal static class LegionRaid
  {
    public static int RaidCounts = 0;

    public static bool OnElapsed()
    {
      try
      {
        // Wetter für 60 Sekunden ändern
        weathereffect weathereffect = Common.AddWeatherEffect(Blizzard.GetPlayableMapRect(), ConstantsEx.WEATHER_Rays_of_Sunlight);
        timer weatherTimer = Common.CreateTimer();
        Common.TimerStart(weatherTimer, 60f, false, () =>
        {
          Common.DestroyTimer(weatherTimer);
          weatherTimer.Dispose();
          weatherTimer = null;

          Common.RemoveWeatherEffect(weathereffect);
          weathereffect.Dispose();
          weathereffect = null;
        });

        player player = player.NeutralAggressive;

        RaidCounts++;

        Rectangle centerRect = Areas.CenterComplete.Wc3Rectangle;
        Rectangle CenterBottomRect = Areas.CenterBottom.Wc3Rectangle;
        Rectangle CenterLeftRect = Areas.MiddleLaneSpawnEast.Wc3Rectangle;
        Rectangle CenterTopRect = Areas.CenterTop.Wc3Rectangle;
        Rectangle CenterRightRect = Areas.MiddleLaneSpawnWest.Wc3Rectangle;

        Console.WriteLine($"The {Program.Legion.ColorizedName} is approaching, abandon all hope and despair...");

        Pentagram pentaCenter = new Pentagram(centerRect.Center, 10f);
        Pentagram pentaBottom = new Pentagram(CenterBottomRect.Center, 5f);
        Pentagram pentaLeft = new Pentagram(CenterLeftRect.Center, 5f);
        Pentagram pentaTop = new Pentagram(CenterTopRect.Center, 5f);
        Pentagram pentaRight = new Pentagram(CenterRightRect.Center, 5f);

        // Musik (Dauert etwa 55 Sekunden) einmal spielen
        Common.PlayThematicMusic("war3mapImported\\blowitup_cutted.mp3");

        // Pentagram zeichen nach 1,5 Sekunden für 5 Sekunden
        int timer1Count = 0;
        timer pentaTimer = Common.CreateTimer();
        Common.TimerStart(pentaTimer, 1f, true, () =>
        {
          // Zentrum
          pentaCenter.CreateLightning();
          pentaBottom.CreateLightning();
          pentaLeft.CreateLightning();
          pentaTop.CreateLightning();
          pentaRight.CreateLightning();

          timer1Count++;
          if (timer1Count >= 5)
          {
            pentaTimer.Pause();

            Common.DestroyTimer(pentaTimer);
            pentaTimer.Dispose();
            pentaTimer = null;
          }
        });

        // Legion-Held wird im Zentrum erzeugt, bekommt ggf. den höchsten Spielerlevel und wird traininert
#if DEBUG
        int maxHeroLevel = 0;
#else
        int maxHeroLevel = Program.AllActiveUsers.Max(user => user.HeroLevelCounter);
#endif
        if (maxHeroLevel == 0)
          maxHeroLevel = RaidCounts;

        timer spawnTimer = Common.CreateTimer();
        Common.TimerStart(spawnTimer, 5f, false, () =>
        {
          Common.DestroyTimer(spawnTimer);
          spawnTimer.Dispose();
          spawnTimer = null;

          try
          {
            Program.Legion.CreateOrRefreshSpawnBuildings(RaidCounts);
            Program.Legion.CreateOrReviveHero(Constants.UNIT_DEMON_LORD_LEGION, Areas.Center, maxHeroLevel, RaidCounts);

            // Zentrum - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnit(centerRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
            Program.Legion.CreateUnit(centerRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
            Program.Legion.CreateUnit(centerRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
            Program.Legion.CreateUnit(centerRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);

            // Bottom Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnit(CenterBottomRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
            Program.Legion.CreateUnit(CenterBottomRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);

            // Left Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnit(CenterLeftRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
            Program.Legion.CreateUnit(CenterLeftRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);

            // Top Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnit(CenterTopRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
            Program.Legion.CreateUnit(CenterTopRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);

            // Right Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnit(CenterRightRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
            Program.Legion.CreateUnit(CenterRightRect, Constants.UNIT_INFERNAL_LEGION, RaidCounts);
          }
          catch (Exception ex)
          {
            Program.ShowExceptionMessage("LegionRaid.OnElapsed", ex);
          }
        });
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("LegionRaid.OnElapsed", ex);
      }

      return true;
    }

    private static void CreateUnitAtRandomPointWithEffectTimed(Rectangle rectangle, int unitTypeId, float delay)
    {
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        Program.Legion.CreateUnit(rectangle, unitTypeId, RaidCounts, 0f);
      });
    }

    private static void CreateAtDummyAndCastAbilityTimed(player player, Rectangle rectangle, int abilityId, int abilityLevel, int orderId, float delay, float duration = 2f)
      => CreateAtDummyAndCastAbilityTimed(player, rectangle.GetRandomPoint(), abilityId, abilityLevel, orderId, delay, duration);
    private static void CreateAtDummyAndCastAbilityTimed(player player, Point point, int abilityId, int abilityLevel, int orderId, float delay, float duration = 2f)
    {
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        CreateAtDummyAndCastAbility(player, point, abilityId, abilityLevel, orderId, duration);
      });
    }
    private static void CreateAtDummyAndCastAbility(player player, Point point, int abilityId, int abilityLevel, int orderId, float duration = 2f)
    {
      unit dummy = Common.CreateUnit(player, Constants.UNIT_DUMMY, point.X, point.Y, 0f);

      dummy.AddAbility(abilityId);
      dummy.SetAbilityLevel(abilityId, abilityLevel);
      dummy.IssueOrder(orderId, dummy);

      // Dummy nach Gebrauch wieder zerstören und freigeben
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, duration, false, () =>
      {
        Common.DestroyTimer(timer);
        timer.Dispose();
        timer = null;

        Common.RemoveUnit(dummy);
        dummy.Dispose();
        dummy = null;
      });
    }

    private static void CreateLightning(unit caster, unit target, float duration, float fadeDuration)
    {
      var lightning = new Lightning("AFOD", caster, target)
      {
        Duration = duration,
        FadeDuration = fadeDuration,
        CasterHeightOffset = 50f,
        TargetHeightOffset = 50f,
      };

      LightningSystem.Add(lightning);
    }
  }
}
﻿using Source.Models;
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
    /// <summary>
    /// Anzahl an Raids
    /// </summary>
    public static int RaidRound = 0;

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

        RaidRound++;

        Rectangle centerRect = Areas.CenterComplete.Wc3Rectangle;
        Rectangle CenterBottomRect = Areas.LegionSpawnBottom.Wc3Rectangle;
        Rectangle CenterLeftRect = Areas.LegionSpawnEast.Wc3Rectangle;
        Rectangle CenterTopRect = Areas.LegionSpawnTop.Wc3Rectangle;
        Rectangle CenterRightRect = Areas.LegionSpawnWest.Wc3Rectangle;

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
          maxHeroLevel = RaidRound;

        timer spawnTimer = Common.CreateTimer();
        Common.TimerStart(spawnTimer, 5f, false, () =>
        {
          Common.DestroyTimer(spawnTimer);
          spawnTimer.Dispose();
          spawnTimer = null;

          try
          {
            Program.Legion.CreateOrRefreshSpawnBuildings(RaidRound);
            Program.Legion.CreateOrReviveHero(Constants.UNIT_DEMON_LORD_LEGION, Areas.Center, maxHeroLevel, RaidRound);

            // Zentrum - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnitAtRandomPoint(centerRect, Constants.UNIT_INFERNAL_LEGION)
              .AttackMoveTimed(Areas.HumanBase, 1);
            Program.Legion.CreateUnitAtRandomPoint(centerRect, Constants.UNIT_INFERNAL_LEGION)
              .AttackMoveTimed(Areas.OrcBase, 1);
            Program.Legion.CreateUnitAtRandomPoint(centerRect, Constants.UNIT_INFERNAL_LEGION)
              .AttackMoveTimed(Areas.ElfBase, 1);
            Program.Legion.CreateUnitAtRandomPoint(centerRect, Constants.UNIT_INFERNAL_LEGION)
              .AttackMoveTimed(Areas.UndeadBase, 1);

            // Bottom Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnBottom1, Constants.UNIT_INFERNAL_LEGION)
              .AttackMoveTimed(Areas.ElfBase, 1);
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnBottom2, Constants.UNIT_INFERNAL_LEGION, 180f)
              .AttackMoveTimed(Areas.UndeadBase, 1);

            // Left Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnEast1, Constants.UNIT_INFERNAL_LEGION, 270f)
              .AttackMoveTimed(Areas.OrcBase, 1);
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnEast2, Constants.UNIT_INFERNAL_LEGION, 90f)
              .AttackMoveTimed(Areas.UndeadBase, 1);

            // Top Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnTop1, Constants.UNIT_INFERNAL_LEGION)
              .AttackMoveTimed(Areas.HumanBase, 1);
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnTop2, Constants.UNIT_INFERNAL_LEGION, 180f)
              .AttackMoveTimed(Areas.OrcBase, 1);

            // Right Lane - Weitere Einheiten via Cast hinzurufen
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnWest1, Constants.UNIT_INFERNAL_LEGION, 270f)
              .AttackMoveTimed(Areas.HumanBase, 1);
            Program.Legion.CreateUnitInArea(Areas.LegionSpawnWest2, Constants.UNIT_INFERNAL_LEGION, 90f)
              .AttackMoveTimed(Areas.ElfBase, 1);
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

        Program.Legion.CreateUnitAtRandomPoint(rectangle, unitTypeId);
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
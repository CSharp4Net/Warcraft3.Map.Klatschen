using Source.Handler.GenericEvents;
using Source.Models;
using System;
using System.Threading;
using WCSharp.Api;
using WCSharp.Effects;
using WCSharp.Lightnings;
using WCSharp.Shared.Data;

namespace Source.Handler.Periodic
{
  internal static class Slapping
  {
    private static int executions = 0;

    public static bool OnElapsed()
    {
      try
      {
        weathereffect weathereffect = Common.AddWeatherEffect(Blizzard.GetPlayableMapRect(), ConstantsEx.WEATHER_Lorderon_Heavy_Rain);
        timer weatherTimer = Common.CreateTimer();
        Common.TimerStart(weatherTimer, Program.KlatschenInterval / 5, false, () =>
        {
          Common.RemoveWeatherEffect(weathereffect);
          weathereffect.Dispose();
          weathereffect = null;
        });

        player player = player.NeutralAggressive;

        executions++;

        Console.WriteLine("Klatschen!");

        Rectangle centerRect = Areas.CenterComplete.Wc3Rectangle;
        Rectangle CenterBottomRect = Areas.CenterBottom.Wc3Rectangle;
        Rectangle CenterLeftRect = Areas.CenterLeft.Wc3Rectangle;
        Rectangle CenterTopRect = Areas.CenterTop.Wc3Rectangle;
        Rectangle CenterRightRect = Areas.CenterRight.Wc3Rectangle;

        Point centerPoint = centerRect.Center;
        Point centerBottomPoint = CenterBottomRect.Center;
        Point centerLeftPoint = CenterLeftRect.Center;
        Point centerTopPoint = CenterTopRect.Center;
        Point centerRightPoint = CenterRightRect.Center;

        // Effekt für Ankündigung für 6 Sekunden
        CreateSpecialEffect("Abilities\\Spells\\Human\\FlameStrike\\FlameStrikeTarget.mdl", centerPoint, 3f, 5f);

        float centerX = centerPoint.X;
        float centerY = centerPoint.Y - 100;

        // Zentrum
        ComputePentagramPoints(centerPoint, 10f,
          out Point pentaCenterPointBottom,
          out Point pentaCenterPointTopLeft,
          out Point pentaCenterPointTopRight,
          out Point pentaCenterPointLeft,
          out Point pentaCenterPointRight);

        // Left Lane
        ComputePentagramPoints(centerBottomPoint, 5f,
          out Point pentaBottomPointBottom,
          out Point pentaBottomPointTopLeft,
          out Point pentaBottomPointTopRight,
          out Point pentaBottomPointLeft,
          out Point pentaBottomPointRight);

        // Left Lane
        ComputePentagramPoints(centerLeftPoint, 5f,
          out Point pentaLeftPointBottom,
          out Point pentaLeftPointTopLeft,
          out Point pentaLeftPointTopRight,
          out Point pentaLeftPointLeft,
          out Point pentaLeftPointRight);

        // Top Lane
        ComputePentagramPoints(centerTopPoint, 5f,
          out Point pentaTopPointBottom,
          out Point pentaTopPointTopLeft,
          out Point pentaTopPointTopRight,
          out Point pentaTopPointLeft,
          out Point pentaTopPointRight);

        // Right Lane
        ComputePentagramPoints(centerRightPoint, 5f,
          out Point pentaRightPointBottom,
          out Point pentaRightPointTopLeft,
          out Point pentaRightPointTopRight,
          out Point pentaRightPointLeft,
          out Point pentaRightPointRight);

        // Zentrum - Nach 5 Sekunden die Schaden-Effekte anzeigen
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaCenterPointBottom, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaCenterPointTopLeft, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaCenterPointTopRight, 5f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaCenterPointLeft, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaCenterPointRight, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Demon\\DarkPortal\\DarkPortalTarget.mdl", centerPoint, 3, 5f);

        // Bottom Lange - Nach 5 Sekunden die Schaden-Effekte anzeigen
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", centerBottomPoint, 3f, 5f, 5f);

        // Left Lange - Nach 5 Sekunden die Schaden-Effekte anzeigen
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", centerLeftPoint, 3f, 5f, 5f);

        // Top Lange - Nach 5 Sekunden die Schaden-Effekte anzeigen
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", centerTopPoint, 3f, 5f, 5f);

        // Right Lange - Nach 5 Sekunden die Schaden-Effekte anzeigen
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", centerRightPoint, 3f, 5f, 5f);

        // Zentrum - Nach 5 Sekunden die Schaden-Ability zünden
        CreateAtDummyAndCastAbilityTimed(player, centerPoint, Constants.ABILITY_PHOENIXFEUER_DUMMY, executions, Constants.ORDER_PHOENIX_FIRE, 5.5f);

        // Pentagram zeichen nach 1,5 Sekunden für 5 Sekunden
        int timer1Count = 0;
        timer pentaTimer = Common.CreateTimer();
        Common.TimerStart(pentaTimer, 0.5f, true, () =>
        {
          // Zentrum
          CreateLightning(pentaCenterPointBottom, pentaCenterPointTopLeft);
          CreateLightning(pentaCenterPointTopLeft, pentaCenterPointRight);
          CreateLightning(pentaCenterPointRight, pentaCenterPointLeft);
          CreateLightning(pentaCenterPointLeft, pentaCenterPointTopRight);
          CreateLightning(pentaCenterPointTopRight, pentaCenterPointBottom);

          // Bottom Lane
          CreateLightning(pentaBottomPointBottom, pentaBottomPointTopLeft);
          CreateLightning(pentaBottomPointTopLeft, pentaBottomPointRight);
          CreateLightning(pentaBottomPointRight, pentaBottomPointLeft);
          CreateLightning(pentaBottomPointLeft, pentaBottomPointTopRight);
          CreateLightning(pentaBottomPointTopRight, pentaBottomPointBottom);

          // Left Lane
          CreateLightning(pentaLeftPointBottom, pentaLeftPointTopLeft);
          CreateLightning(pentaLeftPointTopLeft, pentaLeftPointRight);
          CreateLightning(pentaLeftPointRight, pentaLeftPointLeft);
          CreateLightning(pentaLeftPointLeft, pentaLeftPointTopRight);
          CreateLightning(pentaLeftPointTopRight, pentaLeftPointBottom);

          // Top Lane
          CreateLightning(pentaTopPointBottom, pentaTopPointTopLeft);
          CreateLightning(pentaTopPointTopLeft, pentaTopPointRight);
          CreateLightning(pentaTopPointRight, pentaTopPointLeft);
          CreateLightning(pentaTopPointLeft, pentaTopPointTopRight);
          CreateLightning(pentaTopPointTopRight, pentaTopPointBottom);

          // Right Lane
          CreateLightning(pentaRightPointBottom, pentaRightPointTopLeft);
          CreateLightning(pentaRightPointTopLeft, pentaRightPointRight);
          CreateLightning(pentaRightPointRight, pentaRightPointLeft);
          CreateLightning(pentaRightPointLeft, pentaRightPointTopRight);
          CreateLightning(pentaRightPointTopRight, pentaRightPointBottom);

          timer1Count++;
          if (timer1Count >= 10)
          {
            pentaTimer.Pause();
            pentaTimer.Dispose();
            pentaTimer = null;
          }
        });

        // Zentrum - Helden beleben nach 5 Sekunden
        Program.Slappers.CreateOrReviveHero(Constants.UNIT_GRUBENLORD_KLATSCHEN, Areas.Center, executions * 10, executions * 2, 5.5f);

        // Zentrum - Weitere Einheiten via Cast hinzurufen
        CreateAtDummyAndCastAbilityTimed(player, centerRect, Constants.ABILITY_H_LLENBESTIEN_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4f);
        CreateAtDummyAndCastAbilityTimed(player, centerRect, Constants.ABILITY_TEUFELSWACHEN_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4f);
        CreateAtDummyAndCastAbilityTimed(player, centerRect, Constants.ABILITY_TEUFELSFRESSERER_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4f);
        CreateAtDummyAndCastAbilityTimed(player, centerRect, Constants.ABILITY_SCH_NDLICHE_FOLTERKNECHTE_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4.5f);
        CreateAtDummyAndCastAbilityTimed(player, centerRect, Constants.ABILITY_MAIDS_DES_SCHRECKENS_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4.5f);
        CreateAtDummyAndCastAbilityTimed(player, centerRect, Constants.ABILITY_H_LLENMASCHINEN_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 5f);

        // Bottom Lane - Weitere Einheiten via Cast hinzurufen
        CreateAtDummyAndCastAbilityTimed(player, CenterBottomRect, Constants.ABILITY_H_LLENBESTIEN_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4f);
        CreateAtDummyAndCastAbilityTimed(player, CenterBottomRect, Constants.ABILITY_MAIDS_DES_SCHRECKENS_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4.5f);

        // Left Lane - Weitere Einheiten via Cast hinzurufen
        CreateAtDummyAndCastAbilityTimed(player, CenterLeftRect, Constants.ABILITY_H_LLENBESTIEN_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4f);
        CreateAtDummyAndCastAbilityTimed(player, CenterLeftRect, Constants.ABILITY_MAIDS_DES_SCHRECKENS_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4.5f);

        // Top Lane - Weitere Einheiten via Cast hinzurufen
        CreateAtDummyAndCastAbilityTimed(player, CenterTopRect, Constants.ABILITY_H_LLENBESTIEN_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4f);
        CreateAtDummyAndCastAbilityTimed(player, CenterTopRect, Constants.ABILITY_MAIDS_DES_SCHRECKENS_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4.5f);

        // Right Lane - Weitere Einheiten via Cast hinzurufen
        CreateAtDummyAndCastAbilityTimed(player, CenterRightRect, Constants.ABILITY_H_LLENBESTIEN_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4f);
        CreateAtDummyAndCastAbilityTimed(player, CenterRightRect, Constants.ABILITY_MAIDS_DES_SCHRECKENS_KLATSCHEN, executions, Constants.ORDER_RAIN_OF_CHAOS, 4.5f);
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("SlapAround.OnElapsed", ex);
      }

      return true;
    }

    private static void CreateSpecialEffect(string modelPath, Point point, float scale, float duration = 0.03125f)
    {
      effect e = Common.AddSpecialEffect(modelPath, point.X, point.Y);
      e.Scale = scale;
      EffectSystem.Add(e, duration);
    }

    private static void CreateSpecialEffectTimed(string modelPath, Point point, float scale, float delay, float duration = 0.03125f)
    {
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        CreateSpecialEffect(modelPath, point, scale, duration);
      });
    }

    private static void CreateAtDummyAndCastAbility(player player, Point point, int abilityId, int abilityLevel, int orderId, float duration = 2f)
    {
      unit dummy = Common.CreateUnit(player, Constants.UNIT_DUMMY, point.X, point.Y, 0f);
      //DummySystem.RecycleDummy(dummy, duration);
      dummy.AddAbility(abilityId);
      dummy.SetAbilityLevel(abilityId, abilityLevel);
      dummy.IssueOrder(orderId, dummy);

      // Dummy nach Gebrauch wieder zerstören und freigeben
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, duration, false, () =>
      {
        Common.RemoveUnit(dummy);
        dummy.Dispose();
        dummy = null;
      });
    }

    private static void CreateAtDummyAndCastAbilityTimed(player player, Rectangle rectangle, int abilityId, int abilityLevel, int orderId, float delay, float duration = 2f)
      => CreateAtDummyAndCastAbilityTimed(player, rectangle.GetRandomPoint(), abilityId, abilityLevel, orderId, delay, duration);
    private static void CreateAtDummyAndCastAbilityTimed(player player, Point point, int abilityId, int abilityLevel, int orderId, float delay, float duration = 2f)
    {
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        CreateAtDummyAndCastAbility(player, point, abilityId, abilityLevel, orderId, duration);
      });
    }

    private static void CreateLightning(Point caster, Point target)
    {
      // https://www.hiveworkshop.com/threads/beginners-guide-to-lightning-effects.220370/#herp
      var lightning = Common.AddLightningEx("AFOD", true, caster.X, caster.Y, 50, target.X, target.Y, 50);

      timer timer1 = Common.CreateTimer();
      Common.TimerStart(timer1, 1f, true, () =>
      {
        try
        {
          Common.DestroyLightning(lightning);
          lightning.Dispose();
          lightning = null;
        }
        catch (Exception ex)
        {
          Program.ShowExceptionMessage("SlapAround.CreateLightning", ex);
        }
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

    private static void ComputePentagramPoints(Point center, float size,
      out Point pentaPointBottom,
      out Point pentaPointTopLeft,
      out Point pentaPointTopRight,
      out Point pentaPointLeft,
      out Point pentaPointRight)
    {
      float centerX = center.X;
      float centerY = center.Y - 100;

      pentaPointBottom = new Point(centerX, centerY - (90f * size));
      pentaPointTopLeft = new Point(centerX - (60f * size), centerY + (75f * size));
      pentaPointTopRight = new Point(centerX + (60f * size), centerY + (75f * size));
      pentaPointLeft = new Point(centerX - (90f * size), centerY - (30f * size));
      pentaPointRight = new Point(centerX + (90f * size), centerY - (30f * size));
    }
  }
}
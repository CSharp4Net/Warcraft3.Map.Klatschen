using Source.Handler.GenericEvents;
using Source.Models;
using System;
using WCSharp.Api;
using WCSharp.Effects;
using WCSharp.Lightnings;
using WCSharp.Shared.Data;

namespace Source.Handler.Periodic
{
  internal static class Klatschen
  {
    private static int executions = 0;

    public static bool OnElapsed()
    {
      try
      {
        player player = player.NeutralAggressive;

        executions++;

        Console.WriteLine("Brennt, ihr Narren!");

        Point center = Areas.CenterComplete.Wc3Rectangle.Center;

        // Effekt für Ankündigung für 6 Sekunden
        CreateSpecialEffect("Abilities\\Spells\\Human\\FlameStrike\\FlameStrikeTarget.mdl", center, 3f, 5f);


        float centerX = center.X;
        float centerY = center.Y - 100;

        Point pentaPointBottom = new Point(centerX, centerY - 900);
        Point pentaPointTopLeft = new Point(centerX - 600, centerY + 750);
        Point pentaPointTopRight = new Point(centerX + 600, centerY + 750);
        Point pentaPointLeft = new Point(centerX - 900, centerY - 300);
        Point pentaPointRight = new Point(centerX + 900, centerY - 300);

        // Nach 5 Sekunden die Schaden-Effekte anzeigen
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaPointBottom, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaPointTopLeft, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaPointTopRight, 5f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaPointLeft, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", pentaPointRight, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", center, 5f, 5f, 5f);

        // Nach 5 Sekunden die Schaden-Ability zünden
        CreateAtDummyAndCastAbilityTimed(player, center, Constants.ABILITY_PHOENIXFEUER_DUMMY, executions, Constants.ORDER_PHOENIX_FIRE, 5.5f);

        int timer1Count = 0;
        timer pentaTimer = Common.CreateTimer();
        Common.TimerStart(pentaTimer, 0.5f, true, () =>
        {
          try
          {
            CreateLightning(pentaPointBottom, pentaPointTopLeft);
            CreateLightning(pentaPointTopLeft, pentaPointRight);
            CreateLightning(pentaPointRight, pentaPointLeft);
            CreateLightning(pentaPointLeft, pentaPointTopRight);
            CreateLightning(pentaPointTopRight, pentaPointBottom);


            timer1Count++;
            if (timer1Count >= 10)
            {
              pentaTimer.Pause();
              pentaTimer.Dispose();
              pentaTimer = null;
            }
          }
          catch (Exception ex)
          {
            Program.ShowExceptionMessage("SlapAround.Pentagram", ex);
          }
        });

        //timer timer1 = Common.CreateTimer();
        //Common.TimerStart(timer1, 1f, false, () =>
        //{
        //  Program.ShowDebugMessage("Call meteors");
        //  for (int i = 0; i < 8; i++)
        //  {
        //    Point point = rectangle.GetRandomPoint();

        //    effect e = Common.AddSpecialEffect("Units\\Demon\\Infernal\\InfernalBirth.mdl", point.X, point.Y);
        //    e.SetColor(255, 0, 0);
        //    EffectSystem.Add(e);
        //  }
        //});
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
  }
}
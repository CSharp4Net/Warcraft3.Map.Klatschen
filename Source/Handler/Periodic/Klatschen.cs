using Source.Models;
using System;
using WCSharp.Api;
using WCSharp.Effects;
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

        Console.WriteLine("Die brennende Legion beansprucht das Zentrum, flieht ihr Narren...");

        // Effekt für Ankündigung für 6 Sekunden
        CreateSpecialEffect("Abilities\\Spells\\Human\\FlameStrike\\FlameStrikeTarget.mdl", Areas.Center, 3f, 6f);

        // Nach 5 Sekunden die Schaden-Effekte anzeigen
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", Areas.CenterHuman, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", Areas.CenterOrc, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", Areas.Center, 5f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", Areas.CenterElf, 3f, 5f, 5f);
        CreateSpecialEffectTimed("Abilities\\Spells\\Human\\FlameStrike\\FlameStrike1.mdl", Areas.CenterUndead, 3f, 5f, 5f);

        // Nach 5 Sekunden die Schaden-Ability zünden
        //CreateAtDummyAndCastAbilityTimed(player, Areas.CenterHuman, Constants.ABILITY_PHOENIXFEUER_DUMMY, executions, Constants.ORDER_PHOENIX_FIRE, 5.5f);
        //CreateAtDummyAndCastAbilityTimed(player, Areas.CenterOrc, Constants.ABILITY_PHOENIXFEUER_DUMMY, executions, Constants.ORDER_PHOENIX_FIRE, 5.5f);
        CreateAtDummyAndCastAbilityTimed(player, Areas.Center, Constants.ABILITY_PHOENIXFEUER_DUMMY, executions, Constants.ORDER_PHOENIX_FIRE, 5.5f);
        //CreateAtDummyAndCastAbilityTimed(player, Areas.CenterElf, Constants.ABILITY_PHOENIXFEUER_DUMMY, executions, Constants.ORDER_PHOENIX_FIRE, 5.5f);
        //CreateAtDummyAndCastAbilityTimed(player, Areas.CenterUndead, Constants.ABILITY_PHOENIXFEUER_DUMMY, executions, Constants.ORDER_PHOENIX_FIRE, 5.5f);

        Rectangle rectangle = Areas.CenterComplete.Wc3Rectangle;

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

    private static void CreateSpecialEffect(string modelPath, Area area, float scale, float duration = 0.03125f)
    {
      effect e = Common.AddSpecialEffect(modelPath, area.CenterX, area.CenterY);
      e.Scale = scale;
      EffectSystem.Add(e, duration);
    }

    private static void CreateSpecialEffectTimed(string modelPath, Area area, float scale, float delay, float duration = 0.03125f)
    {
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        CreateSpecialEffect(modelPath, area, scale, duration);
      });
    }

    private static void CreateAtDummyAndCastAbility(player player, Area area, int abilityId, int abilityLevel, int orderId, float duration = 2f)
    {
      unit dummy = Common.CreateUnitAtLoc(player, Constants.UNIT_DUMMY, area.Wc3CenterLocation, 0f);
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
    private static void CreateAtDummyAndCastAbilityTimed(player player, Area area, int abilityId, int abilityLevel, int orderId, float delay, float duration = 2f)
    {
      timer timer = Common.CreateTimer();
      Common.TimerStart(timer, delay, false, () =>
      {
        CreateAtDummyAndCastAbility(player, area, abilityId, abilityLevel, orderId, duration);
      });
    }
  }
}
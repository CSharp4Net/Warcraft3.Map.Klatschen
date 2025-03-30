using System;
using WCSharp.Api;

namespace Source.Handler.Periodic
{
  public static class ResearchCheckHumans
  {
    public static bool OnElapsed()
    {
      if (Program.Humans.Defeated)
        return true;

      try
      {
        // TODO

        player player = Program.Humans.Computer.Wc3Player;

        //int player.Gold;

        if (CheckTechLevelAndIncrease(player, Constants.UPGRADE_EINHEIT_SCH_TZE_TEAM, 1))
          return true;
        if (CheckTechLevelAndIncrease(player, Constants.UPGRADE_EINHEIT_SCH_TZE_TEAM, 2))
          return true;
        else if (CheckTechLevelAndIncrease(player, Constants.UPGRADE_EINHEIT_REITER_TEAM, 1))
          return true;


        else
          return true;
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("ResearchCheckHumans.OnElapsed", ex);

        return true;
      }
    }

    private static bool CheckTechLevelAndIncrease(player player, int techId, int targetLevel)
    {
      //Program.ShowDebugMessage($"Validate tech {techId}");
      //int currentTechLevel = Common.GetPlayerTechCount(player, techId, true);
      //if (currentTechLevel == targetLevel - 1)
      //{

      //  Program.ShowDebugMessage($"Cost: {techCost} Gold");
      //}

      return false;
    }
  }
}
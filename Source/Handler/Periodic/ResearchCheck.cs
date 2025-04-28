using Source.Models;
using System;
using WCSharp.Api;

namespace Source.Handler.Periodic
{
  public static class ResearchCheck
  {
    // Computer-Spielen zahlen 2,5fachen Preis für Forschungen, sonst bietet sich für echte Spieler wenig Anreiz
    private const int GoldPriceBase = 250; // 100
    private const int GoldPriceBaseBuilding = 500; // 200
    private const int GoldPriceBaseArtillery = 625; // 250

    public static bool OnElapsed()
    {
      if (!Program.Humans.Defeated)
        ProcessComputerTechCheck(Program.Humans);

      if (!Program.Orcs.Defeated)
        ProcessComputerTechCheck(Program.Orcs);

      if (!Program.Elves.Defeated)
        ProcessComputerTechCheck(Program.Elves);

      if (!Program.Undeads.Defeated)
        ProcessComputerTechCheck(Program.Undeads);

      return true;
    }

    private static bool ProcessComputerTechCheck(Team team)
    {
      try
      {
        player player = team.Computer.Wc3Player;

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_NAHK_MPFER_ANGRIFF_TEAM, GoldPriceBase);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_NAHK_MPFER_R_STUNG_TEAM, GoldPriceBase);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_FERNK_MPFER_ANGRIFF_TEAM, GoldPriceBase);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_FERNK_MPFER_R_STUNG_TEAM, GoldPriceBase);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_MAGIER_ANGRIFF_TEAM, GoldPriceBase);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_MAGIER_VERTEIDIGUNG_TEAM, GoldPriceBase);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_GEB_UDE_ANGRIFF_TEAM, GoldPriceBaseBuilding);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_GEB_UDE_VERTEIDIGUNG_TEAM, GoldPriceBaseBuilding);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_ARTILLERIE_ANGRIFF_TEAM, GoldPriceBaseArtillery);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_ARTILLERIE_VERTEIDIGUNG_TEAM, GoldPriceBaseArtillery);

        // Keine bezahlbare Forschung übrig
        return true;
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("ResearchCheckHumans.OnElapsed", ex);

        return false;
      }
    }

    private static void IncreaseTechIfAffordable(Team team, player computerPlayer, int techId, int goldPriceBase)
    {
      int currentTechLevel = Common.GetPlayerTechCount(computerPlayer, techId, true);
      if (currentTechLevel == Common.GetPlayerTechMaxAllowed(computerPlayer, techId))
      {
        // Spieler hat maximale Stufe der Forschung erreicht
        Program.ShowDebugMessage($"Fraction has research max level of tech: {techId}");
        return;
      }

      int nextTechLevel = currentTechLevel + 1;
      if (computerPlayer.Gold >= goldPriceBase * nextTechLevel)
      {
        team.IncreaseTechForAllPlayers(techId, nextTechLevel);
        computerPlayer.Gold -= (goldPriceBase * nextTechLevel);
        team.DisplayChatMessage($"Eure Fraktion hat eine Forschung abgeschlossen!");

        // TODO : Name der Forschung anhand ID ermitteln und mit ausgeben?
      }
    }
  }
}
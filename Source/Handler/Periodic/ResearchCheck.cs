using Source.Abstracts;
using Source.Handler.User;
using Source.Models;
using System;
using WCSharp.Api;
using static Source.Models.Enums;

namespace Source.Handler.Periodic
{
  public static class ResearchCheck
  {
    // Computer-Spielen zahlen 2,5fachen Preis für Forschungen, sonst bietet sich für echte Spieler wenig Anreiz
    private const int BaseGoldPriceUnitResearch = 250; // 100
    private const int BaseGoldPriceUnitResearchBuilding = 500; // 200
    private const int BaseGoldPriceUnitResearchArtillery = 625; // 250
    private const int BaseGoldPriceUnitUpgrade = 400; // 200
    private const int BaseGoldPriceUnitUpgradeArtillery = 1000; // 500

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

    private static bool ProcessComputerTechCheck(TeamBase team)
    {
      try
      {
        player player = team.Computer.Wc3Player;

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_NAHK_MPFER_ANGRIFF_TEAM, BaseGoldPriceUnitResearch);
        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_NAHK_MPFER_R_STUNG_TEAM, BaseGoldPriceUnitResearch);
        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_FERNK_MPFER_ANGRIFF_TEAM, BaseGoldPriceUnitResearch);
        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_FERNK_MPFER_R_STUNG_TEAM, BaseGoldPriceUnitResearch);
        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_MAGIER_ANGRIFF_TEAM, BaseGoldPriceUnitResearch);
        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_MAGIER_VERTEIDIGUNG_TEAM, BaseGoldPriceUnitResearch);

        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_GEB_UDE_ANGRIFF_TEAM, BaseGoldPriceUnitResearchBuilding);
        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_GEB_UDE_VERTEIDIGUNG_TEAM, BaseGoldPriceUnitResearchBuilding);

        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_ARTILLERIE_ANGRIFF_TEAM, BaseGoldPriceUnitResearchArtillery);
        //IncreaseTechIfAffordable(team, player, Constants.UPGRADE_UPGRADE_ARTILLERIE_VERTEIDIGUNG_TEAM, BaseGoldPriceUnitResearchArtillery);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_EINHEIT_SOLDAT_TEAM, BaseGoldPriceUnitUpgrade);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_EINHEIT_SCH_TZE_TEAM, BaseGoldPriceUnitUpgrade);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_EINHEIT_REITER_TEAM, BaseGoldPriceUnitUpgrade);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_EINHEIT_MAGIER_TEAM, BaseGoldPriceUnitUpgrade);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_EINHEIT_BELAGERUNGSMASCHINE_TEAM, BaseGoldPriceUnitUpgradeArtillery);

        // Keine bezahlbare Forschung übrig
        return true;
      }
      catch (Exception ex)
      {
        Program.ShowExceptionMessage("ResearchCheckHumans.OnElapsed", ex);

        return false;
      }
    }

    private static bool IncreaseTechIfAffordable(TeamBase team, player computerPlayer, int techId, int goldPriceBase)
    {
      int currentTechLevel = Common.GetPlayerTechCount(computerPlayer, techId, true);
      if (currentTechLevel == Common.GetPlayerTechMaxAllowed(computerPlayer, techId))
      {
        // Spieler hat maximale Stufe der Forschung erreicht
        Program.ShowDebugMessage($"Fraction has research max level of tech: {techId}");
        return false;
      }

      int nextTechLevel = currentTechLevel + 1;

      if (computerPlayer.Gold < goldPriceBase * nextTechLevel)
        return false;

      team.IncreaseTechForAllPlayers(techId, nextTechLevel);
      computerPlayer.Gold -= (goldPriceBase * nextTechLevel);

      // TODO : Name der Forschung anhand ID ermitteln und mit ausgeben?

      ResearchType researchType = team.GetTechType(techId, nextTechLevel, out SpawnUnitCommand spawnCommand);

      if (researchType == ResearchType.AddUnit)
      {
        team.Computer.AddSpawnUnit(spawnCommand);
        team.DisplayChatMessage($"Eure Fraktion hat seine Streitmacht aufgestockt!");
      }
      else if (researchType == ResearchType.UpgradeUnit)
      {
        team.Computer.UpgradeSpawnUnit(spawnCommand);
        team.DisplayChatMessage($"Eure Fraktion hat seine Streitmacht verbessert!");
      }
      else
      {
        team.DisplayChatMessage($"Eure Fraktion hat eine Forschung abgeschlossen!");
      }

      return true;

    }
  }
}
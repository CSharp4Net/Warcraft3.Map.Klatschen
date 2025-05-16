using Source.Abstracts;
using Source.Models;
using System;
using WCSharp.Api;
using static Source.Models.Enums;

namespace Source.Events.Periodic
{
  public static class ResearchCheck
  {
    // Computer-Spielen zahlen 2,5fachen Preis für Forschungen, sonst bietet sich für echte Spieler wenig Anreiz
    private const int BaseGoldPriceUnitResearch = 250; // 100
    private const int BaseGoldPriceUnitResearchBuilding = 500; // 200
    private const int BaseGoldPriceUnitResearchArtillery = 625; // 250
    private const int BaseGoldPriceUnitUpgrade = 500; // 200
    private const int BaseGoldPriceUnitUpgradeArtillery = 1250; // 500

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

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MELEE_ATTACK_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MELEE_DEFENSE_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_DISTANCE_ATTACK_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_DISTANCE_DEFENSE_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MAGE_ATTACK_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MAGE_DEFENSE_TEAM, BaseGoldPriceUnitResearch);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_BUILDING_ATTACK_TEAM, BaseGoldPriceUnitResearchBuilding);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_BUILDING_DEFENSE_TEAM, BaseGoldPriceUnitResearchBuilding);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MELEE_UNIT_TEAM, BaseGoldPriceUnitUpgrade);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_DISTANCE_UNIT_TEAM, BaseGoldPriceUnitUpgrade);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_FLIGHT_UNIT_TEAM, BaseGoldPriceUnitUpgrade);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MAGE_UNIT_TEAM, BaseGoldPriceUnitUpgrade);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_SIEGE_ATTACK_TEAM, BaseGoldPriceUnitResearchArtillery);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_SIEGE_DEFENSE_TEAM, BaseGoldPriceUnitResearchArtillery);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_SIEGE_UNIT_TEAM, BaseGoldPriceUnitUpgradeArtillery);

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
        team.DisplayChatMessage($"Mit dem gesammelten Gold wurden der Streitmacht weitere Einheiten hinzugefügt.");
      }
      else if (researchType == ResearchType.UpgradeUnit)
      {
        team.Computer.UpgradeSpawnUnit(spawnCommand);
        team.DisplayChatMessage($"Mit dem gesammelten Gold wurde Einheiten der Streitmacht aufgewertet.");
      }
      else
      {
        team.DisplayChatMessage($"Mit dem gesammelten Gold wurde eine Forschung abgeschlossen.");
      }

      return true;

    }
  }
}
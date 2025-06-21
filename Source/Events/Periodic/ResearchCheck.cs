using Source.Abstracts;
using Source.Models;
using System;
using WCSharp.Api;
using static Source.Models.Enums;

namespace Source.Events.Periodic
{
  public static class ResearchCheck
  {
    // Computer-Spielen zahlen 2 fachen Preis für Forschungen, sind also langsamer beim Forschen.
    // Grund: Für menschlicher Spieler lohnt es sich sonst nicht zu forschen, da der Computer dies
    // sowieso macht.
    private const int BaseGoldPriceUnitResearch = 200; // 100
    private const int BaseGoldPriceUnitResearchBuilding = 400; // 200
    private const int BaseGoldPriceUnitResearchArtillery = 500; // 250
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

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MELEE_ATTACK_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MELEE_DEFENSE_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_DISTANCE_ATTACK_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_DISTANCE_DEFENSE_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MAGE_ATTACK_TEAM, BaseGoldPriceUnitResearch);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MAGE_DEFENSE_TEAM, BaseGoldPriceUnitResearch);

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_BUILDING_ATTACK_TEAM, BaseGoldPriceUnitResearchBuilding);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_BUILDING_DEFENSE_TEAM, BaseGoldPriceUnitResearchBuilding);

        if (team.Users.Count == 0)
        {
          // Teams ohne menschlichen Mitspieler upgrade ihre Unit-Spawn
          IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MELEE_UNIT_TEAM, BaseGoldPriceUnitUpgrade);
          IncreaseTechIfAffordable(team, player, Constants.UPGRADE_DISTANCE_UNIT_TEAM, BaseGoldPriceUnitUpgrade);
          IncreaseTechIfAffordable(team, player, Constants.UPGRADE_FLIGHT_UNIT_TEAM, BaseGoldPriceUnitUpgrade);
          IncreaseTechIfAffordable(team, player, Constants.UPGRADE_MAGE_UNIT_TEAM, BaseGoldPriceUnitUpgrade);
        }

        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_SIEGE_ATTACK_TEAM, BaseGoldPriceUnitResearchArtillery);
        IncreaseTechIfAffordable(team, player, Constants.UPGRADE_SIEGE_DEFENSE_TEAM, BaseGoldPriceUnitResearchArtillery);

        if (team.Users.Count == 0)
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
        //Program.ShowDebugMessage($"Fraction has research max level of tech: {techId}");
        return false;
      }

      int nextTechLevel = currentTechLevel + 1;

      if (computerPlayer.Gold < goldPriceBase * nextTechLevel)
        return false;

      team.IncreaseTechForAllPlayers(techId, nextTechLevel);
      computerPlayer.Gold -= (goldPriceBase * nextTechLevel);

      ResearchType researchType = team.GetUnitUpgradeByResearch(techId, nextTechLevel, out UnitUpgradeByResearchCommand command);

      if (researchType == ResearchType.Unknown)
      {
        return false;
      }
      else if (researchType == ResearchType.CommonUpgrade)
      {
        team.DisplayChatMessage(ConstantsEx.Message_CollectedGoldToResearchTech);
      }
      else if (researchType == ResearchType.AddUnit)
      {
        team.Computer.AddSpawnUnit(command);
        team.DisplayChatMessage(ConstantsEx.Message_CollectedGoldForMoreUnits);
      }
      else if (researchType == ResearchType.UpgradeUnit)
      {
        team.Computer.UpgradeSpawnUnit(command);
        team.DisplayChatMessage(ConstantsEx.Message_CollectedGoldToUpgradeUnits);
      }
      else
      {
        Program.ShowErrorMessage("ResearchCheck.IncreaseTechIfAffordable", $"Unsopported research tyoe {researchType.ToString()}!");
      }

      return true;

    }
  }
}
﻿using Source.Models;
using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Abstracts
{
  public abstract class TeamBase
  {
    public TeamBase(player wc3ComputerPlayer, Area teamBaseArea, string specialEffectPath)
    {
      Name = wc3ComputerPlayer.Name;

      Computer = new ComputerPlayer(wc3ComputerPlayer, this, specialEffectPath);
      Computer.Wc3Player.SetState(playerstate.GivesBounty, 1);

      TeamBaseArea = teamBaseArea;

      Users = new List<UserPlayer>();

      // Alle Spieler der Streitmacht vom Computer-Spiler abrufen
      force force = Blizzard.GetPlayersAllies(Computer.Wc3Player);
      force.ForEach(() =>
      {
        player player = Common.GetEnumPlayer();

        // Aktive echte Spieler in die Liste aufnehmen
        if (player.Controller == mapcontrol.User && player.SlotState == playerslotstate.Playing)
        {
          // Einmalige Eigenschaften aktivieren/setzen
          player.SetState(playerstate.GivesBounty, 1);

          UserPlayer user = new UserPlayer(player, this);
          Users.Add(user);
          Program.AllActiveUsers.Add(user);
        }
      });
    }

    /// <summary>
    /// Name des Teams
    /// </summary>
    public string Name { get; init; }
    /// <summary>
    /// Name des Teams mit Farberweiterung.
    /// </summary>
    public string ColorizedName { get; init; }

    /// <summary>
    /// Computer-Spieler dieser Streitmacht.
    /// </summary>
    public ComputerPlayer Computer { get; init; }

    /// <summary>
    /// Gebiet, auf dem das Hauptgebäude dieser Streitmacht steht.
    /// </summary>
    public Area TeamBaseArea { get; init; }

    /// <summary>
    /// Auflistung menschlicher Mitspieler in dieser Streitmacht.
    /// </summary>
    public List<UserPlayer> Users { get; init; }

    /// <summary>
    /// Wenn True, wurden alle Spieler dieser Streitmacht besiegt.
    /// </summary>
    public bool Defeated { get; private set; }

    /// <summary>
    /// Löst für alle Spieler dieser Streitmacht die Niederlage aus.
    /// </summary>
    public void Defeat()
    {
      // Töte alle Computer-Einheiten
      Computer.Defeat();

      // Alle echten Spieler durchlaufen
      foreach (UserPlayer player in Users)
      {
        player.Defeat();
      }

      Defeated = true;
    }

    /// <summary>
    /// Löst für alle Spieler dieser Streitmacht den Sieg aus.
    /// </summary>
    public void Win()
    {
      // Töte alle Computer-Einheiten
      Computer.Win();

      // Alle echten Spieler durchlaufen
      foreach (UserPlayer player in Users)
      {
        player.Win();
      }
    }

    /// <summary>
    /// Gibt True zurück, wenn der <paramref name="wc3Player"/> zu einem menschlichen Spieler in diesem Team gehört.
    /// </summary>
    /// <param name="wc3Player">Wacraft-Spieler</param>
    /// <param name="userOfPlayer">Gefundener Benutzer</param>
    /// <returns></returns>
    public bool ContainsPlayer(int playerId, out UserPlayer userOfPlayer)
    {
      foreach (UserPlayer user in Users)
      {
        if (user.PlayerId == playerId)
        {
          userOfPlayer = user;
          return true;
        }
      }

      userOfPlayer = null;
      return false;
    }

    /// <summary>
    /// Erhöht die Stufe einer Forschung für alle Spieler im Team.
    /// </summary>
    /// <param name="techId">Forschung-Id</param>
    /// <param name="techLevel">Forschung-Stufe</param>
    public void IncreaseTechForAllPlayers(int techId, int techLevel)
    {
      Common.SetPlayerTechResearched(Computer.Wc3Player, techId, techLevel);

      foreach (UserPlayer user in Users)
      {
        if (user.Wc3Player.SlotState == playerslotstate.Playing)
          Common.SetPlayerTechResearched(user.Wc3Player, techId, techLevel);
      }
    }

    /// <summary>
    /// Zeigt allen menschlichen Mitspielern des Teams eine Chat-Nachricht an.
    /// </summary>
    /// <param name="message">Nachricht</param>
    public void DisplayChatMessage(string message)
    {
      foreach (UserPlayer user in Users)
      {
        Common.BlzDisplayChatMessage(Computer.Wc3Player, user.PlayerId, message);
      }
    }

    /// <summary>
    /// Virtuelle Methode für das Auswerten einer Technologie und der daraus resultierenden Spawn-Befehle.
    /// Dieser Methode liefert keine verwertbaren Daten und muss pro Streitmacht überschrieben werden!
    /// </summary>
    /// <param name="techId">Technologie-Id</param>
    /// <param name="techLevel">Technologie-Stufe</param>
    /// <param name="command">Spawn-Befehl, welcher sich aus dieser Konstellation ergibt.</param>
    /// <returns></returns>
    public virtual Enums.ResearchType GetUnitUpgradeByResearch(int techId, int techLevel, out UnitUpgradeByResearchCommand command)
    {
      Program.ShowErrorMessage("TeamBase.GetUnitUpgradeByResearch", $"Method not implemented yet for player {ColorizedName}!");

      command = null;

      return Enums.ResearchType.Unknown;
    }

    /// <summary>
    /// Ermittelt anhand der UnitType-Id den Spawn-Command, welche alle nötigen Informationen zum Upgrade der Einheit, sowie zum Ändern des Shops enthält.
    /// </summary>
    /// <param name="baseUnitTypeId">UnitType-Id der gekauften Einheit</param>
    /// <param name="command">Upgrade-Command</param>
    /// <returns></returns>
    public virtual Enums.UnitUpgradeType GetUnitUpgradeBySold(int baseUnitTypeId, out UnitUpgradeBySoldCommand command)
    {
      Program.ShowErrorMessage("TeamBase.GetUnitUpgradeBySold", $"Method not implemented yet for player {ColorizedName}!");

      command = null;

      return Enums.UnitUpgradeType.Unknown;
    }

    /// <summary>
    /// Erstellt alle initialen Gebäude für den Computer-Spieler des Teams.
    /// </summary>
    public virtual void CreateBuildings()
    {
      Program.ShowErrorMessage("TeamBase.CreateBuildings", $"Method not implemented yet for player {ColorizedName}!");
    }
  }
}

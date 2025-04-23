using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class Team
  {
    public Team(player wc3ComputerPlayer)
    {
      Computer = new ComputerPlayer(wc3ComputerPlayer, this);
      Computer.Wc3Player.SetState(playerstate.GivesBounty, 1);

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
    /// Computer-Spieler dieser Streitmacht
    /// </summary>
    public ComputerPlayer Computer { get; init; }

    /// <summary>
    /// Menschliche Mitspieler in dieser Streitmacht
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
      //Program.ShowDebugMessage("Team.Defeat", $"Defeat computer");
      // Töte alle Computer-Einheiten
      Computer.Defeat();

      //Program.ShowDebugMessage("Team.Defeat", $"Defeat players");
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

    public void DisplayChatMessage(string message)
    {
      foreach (UserPlayer user in Users)
      {
        Common.BlzDisplayChatMessage(user.Wc3Player, user.PlayerId, message);
      }
    }
  }
}

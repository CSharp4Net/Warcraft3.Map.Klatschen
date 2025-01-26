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
      Users = new List<UserPlayer>();

      // Alle Spieler der Streitmacht vom Computer-Spiler abrufen
      force force = Blizzard.GetPlayersAllies(Computer.Wc3Player);
      force.ForEach(() =>
      {
        player player = Common.GetEnumPlayer();

        // Aktive echte Spieler in die Liste aufnehmen
        if (player.Controller == mapcontrol.User && player.SlotState == playerslotstate.Playing)
          Users.Add(new UserPlayer(player, this));
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
    /// <param name="foundUser">Gefundener Benutzer</param>
    /// <returns></returns>
    public bool ContainsUser(player wc3Player, out UserPlayer foundUser)
    {
      foreach (UserPlayer user in Users)
      {
        if (user.Wc3Player.Id == wc3Player.Id)
        {
          Console.WriteLine($"Player {wc3Player.Id} found!");
          foundUser = user;
          return true;
        }
      }

      foundUser = null;
      return false;
    }
  }
}

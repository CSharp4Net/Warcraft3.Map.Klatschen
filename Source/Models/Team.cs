using System;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class Team
  {
    public Team(player computerPlayer)
    {
      Computer = new ComputerPlayer(computerPlayer, this);
      AlliedPlayers = new List<RealPlayer>();

      // Alle Spieler der Streitmacht vom Computer-Spiler abrufen
      force force = Blizzard.GetPlayersAllies(Computer.Player);
      force.ForEach(() =>
      {
        player player = Common.GetEnumPlayer();

        // Aktive echte Spieler in die Liste aufnehmen
        if (player.Controller == mapcontrol.User && player.SlotState == playerslotstate.Playing)
          AlliedPlayers.Add(new RealPlayer(player, this));
      });
    }

    /// <summary>
    /// Computer-Spieler dieser Streitmacht
    /// </summary>
    public ComputerPlayer Computer { get; init; }

    /// <summary>
    /// Menschliche Mitspieler in dieser Streitmacht
    /// </summary>
    public List<RealPlayer> AlliedPlayers { get; init; }

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
      foreach (RealPlayer player in AlliedPlayers)
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
      foreach (RealPlayer player in AlliedPlayers)
      {
        player.Win();
      }
    }
  }
}

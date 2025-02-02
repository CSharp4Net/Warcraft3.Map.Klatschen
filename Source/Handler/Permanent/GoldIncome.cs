using WCSharp.Api;

namespace Source.PermanentEvents
{
  internal static class GoldIncome
  {
    public static bool OnElapsed()
    {
      force force = Blizzard.GetPlayersAll();
      force.ForEach(() =>
      {
        player player = Common.GetEnumPlayer();

        if (player.SlotState == playerslotstate.Playing)
          player.Gold += 1;
      });

      return true;
    }
  }
}

using Source.Models;

namespace Source.Events.Periodic
{
  internal static class GoldIncome
  {
    public static bool OnElapsed()
    {
      for( int i = Program.AllActiveUsers.Count - 1; i>= 0; i --)
      {
        UserPlayer user = Program.AllActiveUsers[i];

        if (!user.Defeated)
        {
          user.Wc3Player.Gold += 1;
        }
      }

      return true;
    }
  }
}

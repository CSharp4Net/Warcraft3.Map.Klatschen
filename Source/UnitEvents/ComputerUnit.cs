using WCSharp.Api;

namespace Source.UnitEvents
{
  internal static class ComputerUnit
  {
    internal static void OnUnitDies()
    {
      unit unit = Common.GetTriggerUnit();

      if (unit.Owner.Controller == mapcontrol.User)
        // TODO : Wenn die Einheit (Held) eines Spielers stirbt, wird diese nicht entfernt, sondern wiedergeboren
        return;

      // Verstorbene Einheit nach kurzer Zeit aus Spiel entfernen um RAM zu sparen
      var timer = Common.CreateTimer();
      Common.TimerStart(timer, 10f, false, () =>
      {
        Common.DestroyTimer(timer);
        Common.RemoveUnit(unit);
        // Sicherheitshalber Verweis auf Einheit für GC freigeben
        unit.Dispose();
        unit = null;
      });
    }
  }
}
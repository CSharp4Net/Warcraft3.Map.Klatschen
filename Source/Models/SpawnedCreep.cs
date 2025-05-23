using Source.Abstracts;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Models
{
  public sealed class SpawnedCreep
  {
    /// <summary>
    /// Erstellt eine neue Einheit im Zentrum eines Gebiets.
    /// </summary>
    /// <param name="owner">Besitzer</param>
    /// <param name="unitType">Einheit-Typ</param>
    /// <param name="area">Gebiet</param>
    /// <param name="face">Blickrichtung (0 = rechts, 90 = oben, 180 = unten, 270 = links)</param>
    public SpawnedCreep(NeutralForce owner, int unitType, Point point, float face = 0f)
    {
      Owner = owner;

      Wc3Unit = Common.CreateUnit(owner.Wc3Player, unitType, point.X, point.Y, face);
    }

    /// <summary>
    /// Besitzer der Einheit
    /// </summary>
    public NeutralForce Owner { get; init; }

    /// <summary>
    /// Typ der erstellten Einheit
    /// </summary>
    public int Wc3UnitTypeId { get; init; }
    /// <summary>
    /// Warcraft-Verweis auf Einheit
    /// </summary>
    public unit Wc3Unit { get; init; }

    /// <summary>
    /// Gebiet, welches das Ziel des letzten Angriff/Bewegen-Befehls war.
    /// </summary>
    public Area LastAreaTarget { get; private set; }

    /// <summary>
    /// Gibt der Einheit einen Angriff/Bewegen-Befehl bis zum Zentrum eines Gebiets.
    /// </summary>
    /// <param name="targetArea">Zielgebiet</param>
    public void AttackMove(Area targetArea, float delay = 0f)
    {
      LastAreaTarget = targetArea;

      if (delay == 0f)
        Wc3Unit.IssueOrder(Constants.ORDER_ATTACK, LastAreaTarget.CenterX, LastAreaTarget.CenterY);
      else
      {
        var timer = Common.CreateTimer();
        Common.TimerStart(timer, delay, false, () =>
        {
          Wc3Unit.IssueOrder(Constants.ORDER_ATTACK, LastAreaTarget.CenterX, LastAreaTarget.CenterY);
        });
      }
    }

    /// <summary>
    /// Gibt der Einheit erneut einen Angriff/Bewegen-Befehl zum letzten Zielgebiet, falls bekannt.
    /// </summary>
    public void RepeatAttackMove()
    {
      if (LastAreaTarget != null)
      {
        Wc3Unit.IssueOrder(Constants.ORDER_ATTACK, LastAreaTarget.CenterX, LastAreaTarget.CenterY);
      }
    }

    /// <summary>
    /// Tötet die Einheit, falls diese noch am Leben ist.
    /// </summary>
    public void Kill()
    {
      if (Wc3Unit.Alive)
        Wc3Unit.Kill();
    }
  }
}
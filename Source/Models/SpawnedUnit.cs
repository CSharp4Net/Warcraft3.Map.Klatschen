using Source.Abstracts;
using System.Drawing;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class SpawnedUnit
  {
    /// <summary>
    /// Erstellt eine neue Einheit im Zentrum eines Gebiets.
    /// </summary>
    /// <param name="owner">Besitzer</param>
    /// <param name="unitType">Einheit-Typ</param>
    /// <param name="area">Gebiet</param>
    /// <param name="face">Blickrichtung (0 = rechts, 90 = oben, 180 = unten, 270 = links)</param>
    public SpawnedUnit(player owner, int unitType, Area area, float face = 0f)
    {
      SpawnArea = area;
      Wc3Unit = Common.CreateUnitAtLoc(owner, unitType, area.Wc3CenterLocation, face);

    }

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
    /// Gebiet, in dem die Einheit initial erstellt wurde.
    /// </summary>
    public Area SpawnArea { get; private set; }

    /// <summary>
    /// Gibt der Einheit einen Angriff/Bewegen-Befehl bis zum Zentrum eines Gebiets.
    /// </summary>
    /// <param name="targetArea">Zielgebiet</param>
    public void AttackMove(Area targetArea)
    {
      LastAreaTarget = targetArea;

      Wc3Unit.IssueOrder(Constants.ORDER_ATTACK, LastAreaTarget.CenterX, LastAreaTarget.CenterY);
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

using Source.Abstracts;
using WCSharp.Api;

namespace Source.Models
{
  public sealed class PassiveFragtion : FragtionBase
  {
    public PassiveFragtion(player initialPlayer)
      : base(initialPlayer)
    {

    }

    /// <summary>
    /// Erzeugt ein Gebäude für den Spieler und fügt es der Auflistung aller Gebäude hinzu.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="creationArea"></param>
    /// <param name="face"></param>
    /// <returns></returns>
    public SpawnCreepsBuilding CreateBuilding(int unitTypeId, Area creationArea, float face = 0f)
    {
      // Ort anhand Zentrum einer Region erstellen
      return new SpawnCreepsBuilding(Wc3Player, unitTypeId, creationArea, face);
    }
  }
}
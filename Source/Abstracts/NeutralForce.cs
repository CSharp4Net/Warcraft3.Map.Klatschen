using Source.Models;
using WCSharp.Api;
using WCSharp.Shared.Data;

namespace Source.Abstracts
{
  public abstract class NeutralForce
  {
    public NeutralForce(player wc3ComputerPlayer)
    {
      Wc3Player = wc3ComputerPlayer;
    }

    public player Wc3Player { get; protected set; }

    /// <summary>
    /// Erstellt eine neue Heldeinheit oder belebt die Heldeinheit wieder und setzt das Heldenlevel.
    /// </summary>
    /// <param name="unitTypeId"></param>
    /// <param name="spawnArea"></param>
    /// <param name="heroLevel"></param>
    /// <param name="targetArea"></param>
    protected SpawnedCreep CreateHero(int unitTypeId, Area spawnArea, int heroLevel, float face = 0f)
    {
      SpawnedCreep result = new SpawnedCreep(this, unitTypeId, spawnArea.Wc3Rectangle.Center, face);
      result.Wc3Unit.HeroLevel = heroLevel;
      return result;
    }

    /// <summary>
    /// Erzeugt im Spawn-Bereich eine Einheit an einem definierten Punkt.
    /// </summary>
    /// <param name="point">Punkt</param>
    /// <param name="unitTypeId">Einheit-Typ</param>
    /// <returns></returns>
    public virtual SpawnedCreep SpawnUnitAtPoint(Point point, int unitTypeId)
    {
      return new SpawnedCreep(this, unitTypeId, point);
    }
  }
}

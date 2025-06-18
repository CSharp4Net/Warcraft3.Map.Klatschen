namespace Source.Models
{
  public sealed class SpawnAttackRoute
  {
    public SpawnAttackRoute(Area spawnArea, Area targetArea)
    {
      SpawnArea = spawnArea;
      TargetArea = targetArea;
    }

    public Area SpawnArea { get; init; }
    public Area TargetArea { get; init; }
  }
}
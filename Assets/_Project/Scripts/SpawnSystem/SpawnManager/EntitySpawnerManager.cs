using UnityEngine;

public abstract class EntitySpawnerManager : MonoBehaviour
{
  [SerializeField] protected SpawnPointStrategyType spawnPointStrategyType = SpawnPointStrategyType.Liner;
  [SerializeField] protected Transform[] spawnPoints;

  [SerializeField] protected ISpawnPointStrategy spawnPointStrategy;

  protected enum SpawnPointStrategyType
  {
    Liner,
    Random
  }

  protected virtual void Awake()
  {
    switch (spawnPointStrategyType)
    {
      case SpawnPointStrategyType.Liner:
        spawnPointStrategy = new LinearSpawnPointStrategy(spawnPoints);
        break;
      case SpawnPointStrategyType.Random:
        spawnPointStrategy = new RandomSpawnPointStrategy(spawnPoints);
        break;
      default:
        break;
    }
  }

  public abstract void Spawn();
}

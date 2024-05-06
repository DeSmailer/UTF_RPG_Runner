using UnityEngine;

public class RoadSpawnerManager : EntitySpawnerManager
{
  [SerializeField] private RoadData[] roadDatas;
  [SerializeField] private float spawnInterval = 1f;

  private EntitySpawner<Road> spawner;

  public static RoadSpawnerManager Instance { get; private set; }

  protected override void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }

    base.Awake();

    spawner = new EntitySpawner<Road>(new EntityFactory<Road>(roadDatas), spawnPointStrategy);

    Spawn();
  }

  public override void Spawn()
  {
    Road road = spawner.Spawn();
    spawnPointStrategy = new SequentialSpawnPointStrategy(road.NextSpawnPoint);
    spawner = new EntitySpawner<Road>(new EntityFactory<Road>(roadDatas), spawnPointStrategy);
  }
}
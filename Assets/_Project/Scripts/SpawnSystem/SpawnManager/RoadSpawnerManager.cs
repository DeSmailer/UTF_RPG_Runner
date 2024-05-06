using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerManager : EntitySpawnerManager
{
  [SerializeField] private RoadData[] roadDatas;
  [SerializeField] private float spawnInterval = 1f;
  //[SerializeField] private int maxCount;

  private EntitySpawner<Road> spawner;
  private CountdownTimer spawnTimer;
  //private int counter;

  protected override void Awake()
  {
    base.Awake();

    spawner = new EntitySpawner<Road>(new EntityFactory<Road>(roadDatas), spawnPointStrategy);

    spawnTimer = new CountdownTimer(spawnInterval);
    spawnTimer.OntimerStop += () =>
    {
      //if (counter >= spawnPoints.Length || counter >= maxCount)
      //{
      //  spawnTimer.Stop();
      //  return;
      //}
      Spawn();
      //counter++;
      spawnTimer.Start();
    };
  }

  private void Start()
  {
    spawnTimer.Start();
  }

  private void Update()
  {
    spawnTimer.Tick(Time.deltaTime);
  }

  public override void Spawn()
  {
    Road road = spawner.Spawn();
    spawnPointStrategy = new SequentialSpawnPointStrategy(road.NextSpawnPoint);
    spawner = new EntitySpawner<Road>(new EntityFactory<Road>(roadDatas), spawnPointStrategy);
  }
}
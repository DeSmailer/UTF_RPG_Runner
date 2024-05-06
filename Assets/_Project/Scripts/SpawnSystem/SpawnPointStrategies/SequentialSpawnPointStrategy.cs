using System.Collections.Generic;
using UnityEngine;

public class SequentialSpawnPointStrategy : ISpawnPointStrategy
{
  //private List<Transform> unusedSpawnPoints;
  private Transform spawnPoint;

  public SequentialSpawnPointStrategy(Transform spawnPoint)
  {
    SetNewSpawnPoint(spawnPoint);
    Debug.Log(spawnPoint.parent.name);
    //unusedSpawnPoints = new List<Transform>();
  }

  public void SetNewSpawnPoint(Transform spawnPoint)
  {
    this.spawnPoint = spawnPoint;
  }

  public Transform NextSpawnPoint()
  {
    //if (!unusedSpawnPoints.Any())
    //{
    //  unusedSpawnPoints = new List<Transform>(spawnPoints);
    //}

    //var randomIndex = Random.Range(0, unusedSpawnPoints.Count);
    //Transform result = unusedSpawnPoints[randomIndex];
    //unusedSpawnPoints.RemoveAt(randomIndex);
    return spawnPoint;
  }
}

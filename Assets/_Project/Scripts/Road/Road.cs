using UnityEngine;

public class Road : Entity
{
  [SerializeField] private Transform nextSpawnPoint;

  public Transform NextSpawnPoint => nextSpawnPoint;
}

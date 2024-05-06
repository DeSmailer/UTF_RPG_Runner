using UnityEngine;

public class SpawnNewRoadTriger : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    PlayerController player = other.GetComponent<PlayerController>();
    if (player != null)
    {
      RoadSpawnerManager.Instance.Spawn();
    }
  }
}
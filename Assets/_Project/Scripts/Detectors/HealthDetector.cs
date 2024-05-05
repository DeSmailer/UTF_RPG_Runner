using UnityEngine;

public class HealthDetector : MonoBehaviour
{
  public Health Health { get; private set; }

  public bool Detected => Health != null;
  public bool detected = false; 

  private void OnTriggerEnter(Collider other)
  {
    Health health = other.GetComponent<Health>();
    if (health != null)
    {
      Health = health;
      detected = true;
    } 
  }
}

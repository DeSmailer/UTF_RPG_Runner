using UnityEngine;

public class ParticleSystemAutoDestroy : MonoBehaviour
{
  [SerializeField] private ParticleSystem ps;

  public void FixedUpdate()
  {
    if (ps && !ps.IsAlive())
    {
      Destroy(gameObject);
    }
  }
}
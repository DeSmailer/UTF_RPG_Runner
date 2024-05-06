using UnityEngine;

public class Medkit : Entity
{
  private float hp;

  public override void Initialize(EntityData data)
  {
    if (data is MedkitData medkitData)
    {
      hp = medkitData.hp;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    Health HP = other.GetComponent<Health>();
    if (HP != null)
    {
      HP.RestoreHealth(hp);
      Destroy(gameObject);
    }
  }
}

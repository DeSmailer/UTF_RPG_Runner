using UnityEngine;

public class DamageBooster : Entity
{
  private int damage;

  public override void Initialize(EntityData data)
  {
    if (data is DamageBoosterData damageBoosterData)
    {
      damage = damageBoosterData.damage;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    PlayerController player = other.GetComponent<PlayerController>();
    if (player != null)
    {
      player.IncreaseDamage(damage);
      Destroy(gameObject);
    }
  }
}

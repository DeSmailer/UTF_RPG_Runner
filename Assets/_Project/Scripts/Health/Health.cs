using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] private float maxHp;
  [SerializeField] private float currentHp;

  public void Initialize(float maxHp, float currentHp)
  {
    this.maxHp = maxHp;
    this.currentHp = currentHp;
  }

  public void TakeDamage(float damage)
  {
    currentHp -= damage;
    Debug.Log("currentHp " + currentHp);
  }
}

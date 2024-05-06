using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
  public float MaxHp { get; private set; }
  public float CurrentHp { get; private set; }

  public UnityEvent OnChange;
  public UnityEvent OnDie;

  public bool IsDead => CurrentHp <= 0;

  public void Initialize(float maxHp)
  {
    CurrentHp = MaxHp = maxHp;
  }

  public void TakeDamage(float damage)
  {
    CurrentHp -= damage;
    if (CurrentHp <= 0)
    {
      Die();
    }
    OnChange?.Invoke();
    Debug.Log("currentHp " + CurrentHp);
  }

  internal void RestoreHealth(float hp)
  {
    CurrentHp += hp;
    if (CurrentHp > MaxHp)
    {
      CurrentHp = MaxHp;
    }
    OnChange?.Invoke();
  }

  void Die()
  {
    OnDie?.Invoke();
  }

  public float GetHpPercentage()
  {
    return CurrentHp / MaxHp;
  }

}

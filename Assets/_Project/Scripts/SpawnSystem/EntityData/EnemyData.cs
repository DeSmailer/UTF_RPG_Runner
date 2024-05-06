using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/Enemy Data")]
public class EnemyData : EntityData
{
  public float damage;
  public float maxHealth;
  public float timerBeetweenAttacks;
  public float timerBeetweenDestroy;
  public int score;
}
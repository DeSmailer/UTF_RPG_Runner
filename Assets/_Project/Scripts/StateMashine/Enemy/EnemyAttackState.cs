using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
  public EnemyAttackState(Enemy enemy, Animator animator, Health playerHealth) : base(enemy, animator) { }

  public override void OnEnter()
  {
    Debug.Log("Attack2");
    animator.CrossFade(attackHash, crossFadeDuration);
  }

  public override void Update()
  {
    enemy.Attack();
  }
}
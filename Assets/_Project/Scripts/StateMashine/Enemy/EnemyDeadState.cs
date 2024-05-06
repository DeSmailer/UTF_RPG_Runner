using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
  public EnemyDeadState(Enemy enemy, Animator animator) : base(enemy, animator) { }

  public override void OnEnter()
  {
    animator.CrossFade(dieHash, crossFadeDuration);
    enemy.Dead();
  }
}
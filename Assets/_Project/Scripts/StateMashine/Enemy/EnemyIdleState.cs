using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
  public EnemyIdleState(Enemy enemy, Animator animator) : base(enemy, animator) { }

  public override void OnEnter()
  {
    animator.CrossFade(idleHash, crossFadeDuration);
  }
}
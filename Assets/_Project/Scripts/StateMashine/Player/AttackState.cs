using UnityEngine;

public class AttackState : BaseState
{
  public AttackState(PlayerController player, Animator animator, Health playerHealth) : base(player, animator) { }

  public override void OnEnter()
  {
    Debug.Log("Attack3");
    animator.CrossFade(attackHash, crossFadeDuration);
  }

  public override void Update()
  {
    player.Attack();
  }
}

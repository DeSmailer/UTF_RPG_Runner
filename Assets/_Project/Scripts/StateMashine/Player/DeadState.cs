using UnityEngine;

public class DeadState : BaseState
{
  public DeadState(PlayerController player, Animator animator) : base(player, animator) { }

  public override void OnEnter()
  {
    animator.CrossFade(dieHash, crossFadeDuration);
    player.Dead();
  }
}

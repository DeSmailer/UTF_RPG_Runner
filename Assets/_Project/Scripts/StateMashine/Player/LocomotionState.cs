using UnityEngine;

public class LocomotionState : BaseState
{
  public LocomotionState(PlayerController player, Animator animator) : base(player, animator) { }

  public override void OnEnter()
  {
    animator.CrossFade(LocomotionHash, crossFadeDuration);
  }

  public override void Update()
  {
    player.MoveForvard();
    player.HandleMovement();
  }
}

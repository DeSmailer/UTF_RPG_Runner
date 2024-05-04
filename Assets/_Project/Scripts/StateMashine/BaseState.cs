using UnityEngine;

public abstract class BaseState : IState
{
  protected readonly PlayerController player;
  protected readonly Animator animator;

  protected static readonly int LocomotionHash = Animator.StringToHash("Locomotion");
  protected const float crossFadeDuration = 0.1f;

  public BaseState(PlayerController player, Animator animator)
  {
    this.player = player;
    this.animator = animator;
  }

  public virtual void FixedUpdate()
  {
    throw new System.NotImplementedException();
  }

  public virtual void OnEnter()
  {
    throw new System.NotImplementedException();
  }

  public virtual void OnExit()
  {
    throw new System.NotImplementedException();
  }

  public virtual void Update()
  {
    throw new System.NotImplementedException();
  }
}
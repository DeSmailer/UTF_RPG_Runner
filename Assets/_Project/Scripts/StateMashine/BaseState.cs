using UnityEngine;

public abstract class BaseState : IState
{
  protected readonly PlayerController player;
  protected readonly Animator animator;

  protected static readonly int LocomotionHash = Animator.StringToHash("Locomotion");
  protected static readonly int attackHash = Animator.StringToHash("Attack");
  protected static readonly int dieHash = Animator.StringToHash("Die");
  protected const float crossFadeDuration = 0.1f;

  public BaseState(PlayerController player, Animator animator)
  {
    this.player = player;
    this.animator = animator;
  }

  public virtual void OnEnter()
  {
    Debug.Log("FixedUpdate");
  }

  public virtual void Update()
  {
    Debug.Log("Update");
  }

  public virtual void FixedUpdate()
  {
    Debug.Log("FixedUpdate");
  }

  public virtual void OnExit()
  {
    Debug.Log("OnExit");
  }

}
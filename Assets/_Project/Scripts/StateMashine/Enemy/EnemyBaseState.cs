using UnityEngine;

public abstract class EnemyBaseState : IState
{
  protected readonly Enemy enemy;
  protected readonly Animator animator;

  protected static readonly int idleHash = Animator.StringToHash("Idle");
  protected static readonly int attackHash = Animator.StringToHash("Attack");
  protected static readonly int dieHash = Animator.StringToHash("Die");
  protected const float crossFadeDuration = 0.1f;

  protected EnemyBaseState(Enemy enemy, Animator animator)
  {
    this.enemy = enemy;
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


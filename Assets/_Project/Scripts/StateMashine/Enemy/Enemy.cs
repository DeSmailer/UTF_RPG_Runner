using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
  [SerializeField] private Animator animator;
  [SerializeField] private HealthDetector healthDetector;

  [SerializeField] private float timerBeetweenAttacks = 1;
  [SerializeField] private float damage = 2f;

  CountdownTimer attackTimer;

  private StateMashine stateMashine;

  private void Awake()
  {
    Initialize();
  }

  public void Initialize()
  {
    attackTimer = new CountdownTimer(timerBeetweenAttacks);

    stateMashine = new StateMashine();

    var idleState = new EnemyIdleState(this, animator);
    var attackState = new EnemyAttackState(this, animator, healthDetector.Health);

    Any(idleState, new FuncPredicate(() => !healthDetector.Detected));
    At(idleState, attackState, new FuncPredicate(() => healthDetector.Detected));

    stateMashine.SetState(idleState);
  }

  private void At(IState from, IState to, IPredicate condition) => stateMashine.AddTransition(from, to, condition);
  private void Any(IState to, IPredicate condition) => stateMashine.AddAnyTransition(to, condition);

  private void Update()
  {
    stateMashine.Update();
    attackTimer.Tick(Time.deltaTime);
  }

  private void FixedUpdate()
  {
    stateMashine.FixedUpdate();
  }

  public void Attack()
  {
    if (attackTimer.IsRunning)
    {
      return;
    }
    attackTimer.Start();
    Debug.Log("Attack");
  }
}

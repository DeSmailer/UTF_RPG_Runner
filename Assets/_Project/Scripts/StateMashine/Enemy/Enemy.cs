using UnityEngine;

public partial class Enemy : MonoBehaviour
{
  [Header("Refarences")]
  [SerializeField] private Animator animator;
  [SerializeField] private HealthDetector healthDetector;

  [Header("Health")]
  [SerializeField] private Health health;
  [SerializeField] private float maxHp;

  [Header("Attack")]
  [SerializeField] private float timerBeetweenAttacks = 1;
  [SerializeField] private float damage = 2f;

  private CountdownTimer attackTimer;

  private StateMashine stateMashine;

  private void Awake()
  {
    Initialize();
  }

  public void Initialize()
  {
    attackTimer = new CountdownTimer(timerBeetweenAttacks);
    health.Initialize(maxHp);

    SetupStateMashine();
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

  private void SetupStateMashine()
  {
    stateMashine = new StateMashine();

    var idleState = new EnemyIdleState(this, animator);
    var attackState = new EnemyAttackState(this, animator, healthDetector.Health);

    Any(idleState, new FuncPredicate(() => !healthDetector.Detected));
    At(idleState, attackState, new FuncPredicate(() => healthDetector.Detected));

    stateMashine.SetState(idleState);
  }

  public void Attack()
  {
    if (attackTimer.IsRunning)
    {
      return;
    }
    attackTimer.Start();
    healthDetector.Health.TakeDamage(damage);
  }
}

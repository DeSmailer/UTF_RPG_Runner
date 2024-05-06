using UnityEngine;

public partial class Enemy : Entity
{
  [Header("Refarences")]
  [SerializeField] private Animator animator;
  [SerializeField] private HealthDetector healthDetector;

  [Header("Health")]
  [SerializeField] private Health health;

  [Header("Attack")]
  [SerializeField] private float timerBeetweenAttacks;
  [SerializeField] private float damage;

  [Header("Score")]
  [SerializeField] private int score;

  [SerializeField] private float timerBeetweenDestroy;

  private CountdownTimer attackTimer;
  private CountdownTimer deadTimer;

  private StateMashine stateMashine;

  public override void Initialize(EntityData data)
  {
    if (data is EnemyData enemyData)
    {
      damage = enemyData.damage;
      health.Initialize(enemyData.maxHealth);
      score = enemyData.score;
      timerBeetweenAttacks = enemyData.timerBeetweenAttacks;
      timerBeetweenDestroy = enemyData.timerBeetweenDestroy;
    }

    attackTimer = new CountdownTimer(timerBeetweenAttacks);
    deadTimer = new CountdownTimer(timerBeetweenDestroy);

    SetupStateMashine();
  }

  private void At(IState from, IState to, IPredicate condition) => stateMashine.AddTransition(from, to, condition);
  private void Any(IState to, IPredicate condition) => stateMashine.AddAnyTransition(to, condition);

  private void Update()
  {
    stateMashine.Update();
    attackTimer.Tick(Time.deltaTime);
    deadTimer.Tick(Time.deltaTime);
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
    var deadState = new EnemyDeadState(this, animator);

    Any(idleState, new FuncPredicate(() => !healthDetector.Detected));
    At(idleState, attackState, new FuncPredicate(() => healthDetector.Detected));
    At(attackState, deadState, new FuncPredicate(() => health.IsDead));

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

  public void Dead()
  {
    deadTimer.Start();
    deadTimer.OntimerStop += () =>
    {
      ScoreManager.Instance.AddScore(score);
      Destroy(gameObject);
    };
  }
}

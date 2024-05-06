using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
  [Header("Refarences")]
  [SerializeField] private CharacterController controller;
  [SerializeField] private Animator animator;
  [SerializeField] private HealthDetector healthDetector;
  [SerializeField] private InputReader inputReader;

  [Header("Health")]
  [SerializeField] private Health health;
  [SerializeField] private float maxHp;

  [Header("Speed")]
  [SerializeField] private float initSpeed = 5;
  [SerializeField] private float currentSpeed = 5;

  [Header("Track")]
  [SerializeField] private RunningTrack runningTrack;
  [SerializeField] private float trackChangeDuration = 1f;
  private bool canChangeTrack = true;

  [Header("Attack")]
  CountdownTimer attackTimer;
  [SerializeField] private float timerBeetweenAttacks = 1f;
  [SerializeField] private float damage = 5f;

  private StateMashine stateMashine;

  private static readonly int Speed = Animator.StringToHash("Speed");

  public void Initialize()
  {
    currentSpeed = initSpeed;
    transform.position = new Vector3(runningTrack.GetCurrentTrackXCoordinate(), transform.position.y, transform.position.z);
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

    UpdadeteAnimator();
  }

  private void FixedUpdate()
  {
    stateMashine.FixedUpdate();
  }

  private void SetupStateMashine()
  {
    stateMashine = new StateMashine();

    var locomotionState = new LocomotionState(this, animator);
    var attackState = new AttackState(this, animator, healthDetector.Health);

    Any(locomotionState, new FuncPredicate(() => !healthDetector.Detected));
    At(locomotionState, attackState, new FuncPredicate(() => healthDetector.Detected));

    stateMashine.SetState(locomotionState);
  }

  private void UpdadeteAnimator()
  {
    animator.SetFloat(Speed, currentSpeed);
  }

  public void HandleMovement()
  {
    if (!canChangeTrack)
    {
      return;
    }

    if (inputReader.Directions.x > 0)
    {
      canChangeTrack = false;
      transform.DOMoveX(runningTrack.GetRigtTrackXCoordinate(), trackChangeDuration).OnComplete(() => { canChangeTrack = true; });
    }
    else if (inputReader.Directions.x < 0)
    {
      canChangeTrack = false;
      transform.DOMoveX(runningTrack.GetLeftTrackXCoordinate(), trackChangeDuration).OnComplete(() => { canChangeTrack = true; });
    }
  }

  public void MoveForvard()
  {
    var adjustedMovement = Vector3.forward * currentSpeed * Time.deltaTime;
    controller.Move(adjustedMovement);
  }

  public void IncreaseDamage(float damage)
  {
    this.damage += damage;
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

  private void OnDestroy()
  {
    transform.DOKill();
  }
}

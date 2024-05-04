using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
  [Header("Refarences")]
  [SerializeField] private CharacterController controller;
  [SerializeField] private Animator animator;

  [SerializeField] private InputReader inputReader;

  [Header("Settings")]
  [SerializeField] private float initSpeed = 5;
  [SerializeField] private float currentSpeed = 5;

  [Header("Track")]
  [SerializeField] private RunningTrack runningTrack;
  [SerializeField] private float trackChangeDuration = 1f;
  private bool canChangeTrack = true;

  private StateMashine stateMashine;

  private static readonly int Speed = Animator.StringToHash("Speed");

  public void Initialize()
  {
    currentSpeed = initSpeed;
    transform.position = new Vector3(runningTrack.GetCurrentTrackXCoordinate(), transform.position.y, transform.position.z);

    stateMashine = new StateMashine();

    var locomotionState = new LocomotionState(this, animator);
    var locomotionTest2State = new LocomotionTest2State(this, animator);
    //https://youtu.be/NnH6ZK5jt7o?si=-piZRbINZYFou3Mt&t=739

    At(locomotionState, locomotionTest2State, new FuncPredicate(() => canChangeTrack));
    At(locomotionTest2State, locomotionState, new FuncPredicate(() => canChangeTrack));

    stateMashine.SetState(locomotionState);
  }

  private void At(IState from, IState to, IPredicate condition) => stateMashine.AddTransition(from, to, condition);
  private void Any(IState to, IPredicate condition) => stateMashine.AddAnyTransition(to, condition);

  private void Update()
  {
    stateMashine.Update();

    UpdadeteAnimator();
  }

  private void FixedUpdate()
  {
    stateMashine.FixedUpdate();
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

  private void OnDestroy()
  {
    transform.DOKill();
  }
}

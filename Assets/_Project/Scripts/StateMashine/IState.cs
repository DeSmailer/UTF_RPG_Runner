public interface IState
{
  public void OnEnter();
  public void Update();
  public void FixedUpdate();
  public void OnExit();
}

public interface ITransition
{
  IState To { get; }
  IPredicate Condition { get; }
}
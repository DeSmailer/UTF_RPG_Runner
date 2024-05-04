using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/InputReader", order = 1)]
public class InputReader : ScriptableObject, PlayerInputActions.IPlayerActions
{
  public event UnityAction<Vector2> Move;

  private PlayerInputActions inputActions;

  public Vector3 Directions => inputActions.Player.Move.ReadValue<Vector2>();

  private void OnEnable()
  {
    if (inputActions == null)
    {
      inputActions = new PlayerInputActions();
      inputActions.Player.SetCallbacks(this);
    }
    inputActions.Enable();
  }

  public void OnFire(InputAction.CallbackContext context)
  {
    //throw new System.NotImplementedException();
  }

  public void OnLook(InputAction.CallbackContext context)
  {
    //throw new System.NotImplementedException();
  }

  public void OnMove(InputAction.CallbackContext context)
  {
    Move?.Invoke(context.ReadValue<Vector2>());
  }
}

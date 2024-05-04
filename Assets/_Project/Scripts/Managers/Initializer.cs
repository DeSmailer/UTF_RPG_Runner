using UnityEngine;

public class Initializer : MonoBehaviour
{
  [SerializeField] private PlayerController playerController;
  [SerializeField] private CameraFollow cameraFollow;

  private void Awake()
  {
    playerController.Initialize();
    cameraFollow.Initialize();
  }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Transform target;
  [SerializeField] private float smoothSpeed = 0.125f;
  [SerializeField] private Vector3 offset;

  public void Initialize()
  {
    offset = transform.position - target.position;
  }

  private void LateUpdate()
  {
    Follow();
  }

  private void Follow()
  {
    Vector3 newTargetPosition = new Vector3(offset.x, target.position.y, target.position.z);

    Vector3 desiredPosition = newTargetPosition + offset;
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    transform.position = smoothedPosition;
  }
}
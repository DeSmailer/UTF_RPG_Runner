using UnityEngine;

public abstract class EffectsCreator : MonoBehaviour, IEffectsCreator
{
  [SerializeField] protected GameObject vfx;
  [SerializeField] protected AudioSource audioSource;
  [SerializeField] protected float animationDuration = 1f;

  public virtual void Execute()
  {
    if (vfx != null)
    {
      Instantiate(vfx, transform.position, Quaternion.identity);
    }
    if (audioSource != null)
    {
      audioSource.Play();
    }
  }
}

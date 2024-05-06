using DG.Tweening;
using UnityEngine;

public class DestroyEffects : EffectsCreator
{
  private void OnDestroy()
  {
    Execute();
  }

  public override void Execute()
  {
    transform.localScale = Vector3.one;
    transform.DOScale(Vector3.zero, animationDuration).SetEase(Ease.OutBack);

    if (vfx != null)
    {
      Instantiate(vfx, transform.position, Quaternion.identity);
    }
    if (vfx != null)
    {
      AudioSource audio = Instantiate(audioSource, transform.position, Quaternion.identity);
      audio.Play();
    }
  }
}
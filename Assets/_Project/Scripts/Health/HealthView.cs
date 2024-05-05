using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
  [SerializeField] private Health health ;
  [SerializeField] private Slider hpSlider;

  private void Start()
  {
    health.OnChange.AddListener(Display);
  }

  public void Display()
  {
    hpSlider.value = health.GetHpPercentage();
  }
}

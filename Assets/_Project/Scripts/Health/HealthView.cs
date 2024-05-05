using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
  [SerializeField] private Health health;
  [SerializeField] private Slider hpSlider;

  private void Start()
  {
    health.OnChange.AddListener(Display);
    Display();
  }

  public void Display()
  {
    Debug.Log(health.MaxHp);
    Debug.Log(health.CurrentHp);
    Debug.Log(health.GetHpPercentage());
    hpSlider.value = health.GetHpPercentage();
  }
}

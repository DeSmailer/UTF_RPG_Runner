using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
  [SerializeField] private TMP_Text scoreText;
  [SerializeField] private TMP_Text bestScoreText;

  private const string score = "Score: ";
  private const string bestScore = "BestScore: ";

  private void Start()
  {
    ScoreManager.Instance.OnChange.AddListener(Display);
    Display();
  }

  public void Display()
  {
    scoreText.text = string.Concat(score, ScoreManager.Instance.Score.ToString());
    bestScoreText.text = string.Concat(bestScore, ScoreManager.Instance.BestScore.ToString());
  }
}

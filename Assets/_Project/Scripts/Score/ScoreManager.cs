using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager Instance { get; private set; }

  private const int defaultBestScore = 0;
  private const string bestScoreKey = "BestScore";

  public int Score { get; private set; }
  public int BestScore
  {
    get
    {
      if (PlayerPrefs.HasKey(bestScoreKey))
      {
        int bestScore = PlayerPrefs.GetInt(bestScoreKey, defaultBestScore);
        return bestScore;
      }
      return defaultBestScore;
    }
    private set
    {
      if (Score > BestScore)
      {
        PlayerPrefs.SetInt(bestScoreKey, Score);
      }
    }
  }

  public UnityEvent OnChange;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
    }
  }

  public void AddScore(int score)
  {
    Score += score;
    BestScore = Score;
    OnChange?.Invoke();
  }
}

﻿using UnityEngine;

public class Collectible : Entity
{
  private int score;

  public override void Initialize(EntityData data)
  {
    if (data is CollectibleData collectibleDate)
    {
      score = collectibleDate.score;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    PlayerController player = other.GetComponent<PlayerController>();
    if (player != null)
    {
      ScoreManager.Instance.AddScore(score);
      Destroy(gameObject);
    }
  }
}

using UnityEngine;

[CreateAssetMenu(fileName = "LevelParameters", menuName = "ScriptableObjects/LevelParameters", order = 1)]
public class LevelParameters : ScriptableObject
{
  [SerializeField] private float trackWidth;

  public float TrackWidth => trackWidth;
}

using UnityEngine;

[CreateAssetMenu(fileName = "LevelParameters", menuName = "ScriptableObjects/LevelParameters", order = 1)]
public class LevelParameters : ScriptableObject
{
  [SerializeField] private float trackWidth;
  [SerializeField] private int trackCount;
  [SerializeField] private int startingTrack;

  public float TrackWidth => trackWidth;
  public int TrackCount => trackCount;
  public int StartingTrack => startingTrack;
}

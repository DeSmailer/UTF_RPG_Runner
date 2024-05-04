using UnityEngine;

public class RunningTrack : MonoBehaviour
{
  [SerializeField] private float[] tracksX = new float[] { -2, 0, 2 };
  [SerializeField] private int currentTrack = 1;

  public float[] TracksX => tracksX;
  public int CurrentTrack => currentTrack;

  public float GetCurrentTrackXCoordinate()
  {
    return GetXCoordinate(currentTrack);
  }

  public float GetLeftTrackXCoordinate()
  {
    if (currentTrack - 1 >= 0)
    {
      currentTrack--;
    }
    return GetXCoordinate(currentTrack);
  }

  public float GetRigtTrackXCoordinate()
  {
    if (currentTrack + 1 < tracksX.Length)
    {
      currentTrack++;
    }
    return GetXCoordinate(currentTrack);
  }

  private float GetXCoordinate(int index)
  {
    return tracksX[index];
  }
}

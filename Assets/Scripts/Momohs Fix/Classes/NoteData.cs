using UnityEngine;

[System.Serializable]
public class NoteData
{
    public float hitTime;
    public int lane;

    public NoteData(float time, int laneIndex)
    {
        hitTime = time;
        lane = laneIndex;
    }
}

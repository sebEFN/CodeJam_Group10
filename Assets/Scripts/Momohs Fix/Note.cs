using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInsantiated;
    public float assignedTime;

    void Start()
    {
        timeInsantiated = SongManager.GetAudioSourceTime();
    }

    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInsantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));
    }
}

using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    //When the note should be hit
    public float HitTime;

    public float noteTravelTime;

    //Where the note should end up
    public Transform target;

    Vector3 spawnPos;
    Vector3 targetPos;
    private Rhythm rhythm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rhythm = FindObjectOfType<Rhythm>();

        spawnPos = transform.position;
        targetPos = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        float SongTime = rhythm.SongPosition;

        float TimeToHit = HitTime - SongTime;
        float progress = 1f - (TimeToHit / noteTravelTime);
        progress = Mathf.Clamp01(progress);

        // update the target in case the target transform moves
        if (target != null)
            targetPos = target.position;

        //Move toward the target based on time
        transform.position = Vector3.Lerp(spawnPos, targetPos, progress);

        if (SongTime > HitTime + 0.5f)
        {
            Destroy(gameObject);
        }
    }
}

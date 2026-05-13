using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    public float HitTime;
    public float noteTravelTime;
    public Transform target;

    [Header("SFX")]
    public AudioClip missSfx;

    private Rhythm rhythm;

    private Vector3 spawnPos;
    private Vector3 targetPos;

    void Start()
    {
        rhythm = FindObjectOfType<Rhythm>();

        spawnPos = transform.position;
        targetPos = target.position;
    }

    void Update()
    {
        float songTime = rhythm.SongPosition;

        float spawnTime = HitTime - noteTravelTime;

        float progress = (songTime - spawnTime) / noteTravelTime;
        progress = Mathf.Clamp01(progress);

        if (target != null)
            targetPos = target.position;

        transform.position = Vector3.Lerp(spawnPos, targetPos, progress);

        if (songTime > HitTime + 0.1f)
        {
            if (missSfx != null)
            {
                AudioSource.PlayClipAtPoint(missSfx, transform.position, 50f);
            }

            Destroy(gameObject);
        }
    }
}
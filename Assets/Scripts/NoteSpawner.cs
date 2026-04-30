using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public OsuManiaParser parser;
    public GameObject notePrefab;

    public Transform[] lanePositions; // assign in inspector

    public float songTime;
    public float noteSpawnOffset = 2f; 

    int nextNoteIndex = 0;

    void Update()
    {
        songTime += Time.deltaTime;

        while (nextNoteIndex < parser.notes.Count)
        {
            var note = parser.notes[nextNoteIndex];

            if (note.time > songTime + noteSpawnOffset)
                break;

            Spawn(note);
            nextNoteIndex++;
        }
    }

    void Spawn(ManiaNote note)
    {
        Transform lane = lanePositions[note.lane];
        Debug.Log("Spawning lane: " + note.lane);
        GameObject obj = Instantiate(notePrefab, lane.position, Quaternion.identity);

        Note noteScript = obj.GetComponent<Note>();
        noteScript.lane = note.lane;
        noteScript.hitTime = note.time;
    }
}
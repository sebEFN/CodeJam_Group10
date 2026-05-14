using Unity.VisualScripting;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;

    public bool hasStarted;

    public int scrollSpeed = (int)1u;

    void Start()
    {
        beatTempo = scrollSpeed;
    }

 
    void Update()
    {
        if (!hasStarted)
        {
            /* if(Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }
        else
            {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}

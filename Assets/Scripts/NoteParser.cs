using UnityEngine;

public class Note : MonoBehaviour
{
    public int lane;
    public float hitTime;

    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
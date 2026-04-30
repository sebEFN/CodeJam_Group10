using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(t.position);
                    Collider2D hit = Physics2D.OverlapPoint(new Vector2(worldPoint.x, worldPoint.y));
                    if (hit != null && canBePressed)
                    {
                        gameObject.SetActive(false);

                        GameManager.instance.NoteHit();
                        return;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
        }
    }
}

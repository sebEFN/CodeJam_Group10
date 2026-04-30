using UnityEngine;

public class ButtonController : MonoBehaviour
{
   private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode KeyToPress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       theSR = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            if (hit != null && hit.gameObject == gameObject)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    theSR.sprite = pressedImage;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    theSR.sprite = defaultImage;
                }
            }
        }
        if (Input.GetKeyDown(KeyToPress))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(KeyToPress))
        {
            theSR.sprite = defaultImage;
        }
        
    }
    
 }

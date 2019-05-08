using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Sprite mouseIdleSprite, mouseClickSprite;

    SpriteRenderer cursorSprite;


    void Start()
    {
        Cursor.visible = false;
        cursorSprite = GetComponent<SpriteRenderer>();

        cursorSprite.sprite = mouseIdleSprite;
    }


    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            cursorSprite.sprite = mouseClickSprite;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            cursorSprite.sprite = mouseIdleSprite;
        }
    }
}

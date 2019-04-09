using UnityEngine;

public class MousePosition : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite mouseClickSprite, mouseIdleSprite;


    void Start()
    {
        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.sprite = mouseClickSprite;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            spriteRenderer.sprite = mouseIdleSprite;
        }
    }
}

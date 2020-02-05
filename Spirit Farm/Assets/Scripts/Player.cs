using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public static int foodPoints;
    public static bool hasHarvested;
    
    public Sprite playerUp, playerDown, playerLeft, playerRight;

    Vector2 moveInput;
    SpriteRenderer playerSprite;
    Rigidbody2D rigidBody;


    void Awake()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("FirstHorizontal"), Input.GetAxisRaw("FirstVertical")).normalized;

        if (Input.GetKey(KeyCode.S))
        {
            playerSprite.sprite = playerDown;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            playerSprite.sprite = playerUp;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerSprite.sprite = playerRight;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerSprite.sprite = playerLeft;
        }
    }


    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveInput * moveSpeed * Time.deltaTime);
    }
}

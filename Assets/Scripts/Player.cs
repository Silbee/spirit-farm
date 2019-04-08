using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public bool hasHarvested;
    public SpriteRenderer crop;
    public GameObject left, right, front, back;

    Vector2 moveInput;
    Rigidbody2D rigidBody;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("FirstHorizontal"), Input.GetAxisRaw("FirstVertical")).normalized;

        if (Input.GetKeyDown(KeyCode.A))
        {
            left.SetActive(true);
            right.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            left.SetActive(false);
            right.SetActive(true);
            front.SetActive(false);
            back.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            left.SetActive(false);
            right.SetActive(false);
            front.SetActive(false);
            back.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            left.SetActive(false);
            right.SetActive(false);
            front.SetActive(true);
            back.SetActive(false);
        }

    }


    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveInput * moveSpeed * Time.deltaTime);
    }
}

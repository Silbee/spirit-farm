using UnityEngine;

public class SecondPlayer : MonoBehaviour
{
    public float moveSpeed;
    public bool hasHarvested;
    public GameObject left, right, front, back;

    Vector2 moveInput;
    Rigidbody2D rigidBody;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }


    void Update() // owo this game has been hacked by hester owo
    {
        moveInput = new Vector2(Input.GetAxisRaw("SecondHorizontal"), Input.GetAxisRaw("SecondVertical")).normalized;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left.SetActive(true);
            right.SetActive(false);
            front.SetActive(false);
            back.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            left.SetActive(false);
            right.SetActive(true);
            front.SetActive(false);
            back.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            left.SetActive(false);
            right.SetActive(false);
            front.SetActive(false);
            back.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
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

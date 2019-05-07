using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public float smoothTime = 0.1F;
    public Vector2 offset;

    Vector2 velocity;

    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, new Vector2(playerPosition.transform.position.x, playerPosition.transform.position.y) + offset, ref velocity, smoothTime);
    }
}

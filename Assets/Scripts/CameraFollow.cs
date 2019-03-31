using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset = Vector3.back;

    void Update()
    {
        transform.position = playerPosition.position + offset;
    }
}

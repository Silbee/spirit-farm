using UnityEngine;

public class SpawnFriend : MonoBehaviour
{
    public AudioSource SummonSound;
    public GameObject Friend;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Friend.SetActive(true);
            SummonSound.Play();
        }
    }
}

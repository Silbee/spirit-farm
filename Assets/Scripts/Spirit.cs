using UnityEngine;

public class Spirit : MonoBehaviour
{
    public Quest questGiven;

    public Inventory inventory;

    AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.CompareTag("Player") && Player.hasHarvested)
        {
            Player.hasHarvested = false;
            inventory.currentCropImage.enabled = false;
            audioSource.Play();
        }
    }
}

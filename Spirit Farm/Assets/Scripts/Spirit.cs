using UnityEngine;

public class Spirit : MonoBehaviour
{
    public Inventory inventory;
    
    bool interactable;

    AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            interactable = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            interactable = false;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Player.hasHarvested && interactable)
        {
            Player.hasHarvested = false;
            inventory.AddCrop();
            audioSource.Play();
        }
    }
}

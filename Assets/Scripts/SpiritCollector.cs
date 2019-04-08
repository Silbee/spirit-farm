using UnityEngine;

public class SpiritCollector : MonoBehaviour
{
    public Player player;
    public SpriteRenderer crop;

    public static int foodPoints;

    AudioSource aud;


    void Awake()
    {
        aud = GetComponent<AudioSource>();    
    }


    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.CompareTag("Player") && player.hasHarvested)
        {
            player.hasHarvested = false;
            player.crop.enabled = false;
            aud.Play();
            foodPoints++;

            if(foodPoints >= 5)
            {
                print("Game has been won.");
            }
        }
    }
}

using UnityEngine;

public class SpiritCollector : MonoBehaviour
{
    public Player player;
    public SpriteRenderer crop;
    public AudioSource deliverSound;
    public Canvas winScreen;

    public static int foodPoints;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.CompareTag("Player") && player.hasHarvested)
        {
            player.hasHarvested = false;
            crop.enabled = false;
            deliverSound.Play();
            foodPoints++;

            if(foodPoints >= 5)
            {   
                winScreen.enabled = true;
            }
        }
    }
}

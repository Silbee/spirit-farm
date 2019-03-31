using UnityEngine;

public class SpiritCollector : MonoBehaviour
{
    public FirstPlayer player;
    public SpriteRenderer crop;
    public AudioSource deliverSound;
    public Canvas winScreen;

    public int foodPoints;


    /*
     * Negeer dit, dit is bedoeld voor affinity
     * public SpriteRenderer[] hearts;
    */

    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E) && collider.CompareTag("Player1") && player.hasHarvested)
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

using UnityEngine;
using System.Collections;

public class Plot : MonoBehaviour
{
    public enum Crop
    {
        Strawberry,
        Potato,
        Eggplant
    };
    public Crop cropType;

    public Inventory inventory;

    public Sprite[] plantStages;
    
    int cropIndex;
    bool cropsAreGrowing, cropsAreReady, interactable;
    
    SpriteRenderer plotSprite;
    AudioSource audioSource;


    void Awake()
    {
        plotSprite = GetComponent<SpriteRenderer>();
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
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            if (!cropsAreGrowing && !cropsAreReady && !Player.hasHarvested)
            {
                StartCoroutine(CropGrowing());
            }
            else if (cropsAreReady && !Player.hasHarvested)
            {
                audioSource.Play();
                cropIndex = 0;
                inventory.currentCropImage.enabled = true;

                switch (cropType)
                {
                    case Crop.Strawberry:
                        inventory.currentCropImage.sprite = inventory.crops[0].cropSprite;
                        break;
                    case Crop.Potato:
                        inventory.currentCropImage.sprite = inventory.crops[1].cropSprite;
                        break;
                    case Crop.Eggplant:
                        inventory.currentCropImage.sprite = inventory.crops[2].cropSprite;
                        break;
                }

                Player.hasHarvested = true;
                cropsAreReady = false;
                plotSprite.sprite = null;
            }
        }
    }

    
    IEnumerator CropGrowing()
    {
        cropsAreGrowing = true;

        while (plotSprite.sprite != plantStages[plantStages.Length - 1])
        {
            plotSprite.sprite = plantStages[cropIndex];

            if (plotSprite.sprite == plantStages[plantStages.Length - 1])
            {
                cropsAreGrowing = false;
                cropsAreReady = true;

                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(2);
                cropIndex++;
            }
        }
    }
}

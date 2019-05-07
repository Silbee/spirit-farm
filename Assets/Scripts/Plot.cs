using UnityEngine;
using System.Collections;

public class Plot : MonoBehaviour
{
    public Inventory inventory;

    public enum Crop { Strawberry, Potato, Eggplant };
    public Crop cropToHarvest;

    public Sprite[] plantStages;
    
    int cropIndex;
    bool cropsAreGrowing, cropsAreReady;

    SpriteRenderer plotSprite;
    AudioSource audioSource;


    void Awake()
    {
        plotSprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!cropsAreGrowing && !cropsAreReady && !Player.hasHarvested)
            {
                print("Harvesting...");
                StartCoroutine(CropGrowing());
            }
            else if (cropsAreReady && !Player.hasHarvested)
            {
                audioSource.Play();
                cropIndex = 0;
                inventory.currentCropImage.enabled = true;

                switch (cropToHarvest)
                {
                    case Crop.Strawberry:
                        inventory.currentCropImage.sprite = inventory.cropSprites[0];
                        break;
                    case Crop.Potato:
                        inventory.currentCropImage.sprite = inventory.cropSprites[1];
                        break;
                    case Crop.Eggplant:
                        inventory.currentCropImage.sprite = inventory.cropSprites[2];
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

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
                StartCoroutine(CropGrowing());
            }
            else if (cropsAreReady && !Player.hasHarvested)
            {
                audioSource.Play();
                cropIndex = 0;
                inventory.currentCropImage.enabled = true;

                switch (cropType)
                {
                    case (Crop.Strawberry):
                        inventory.crops[0].cropAmount++;
                        inventory.currentCropImage.sprite = inventory.crops[0].cropSprite;
                        break;
                    case (Crop.Potato):
                        inventory.crops[1].cropAmount++;
                        inventory.currentCropImage.sprite = inventory.crops[1].cropSprite;
                        break;
                    case (Crop.Eggplant):
                        inventory.crops[2].cropAmount++;
                        inventory.currentCropImage.sprite = inventory.crops[2].cropSprite;
                        break;
                }

                inventory.UpdateText();
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

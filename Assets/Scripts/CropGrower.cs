using UnityEngine;

public class CropGrower : MonoBehaviour
{
    public enum Crop { Strawberry, Rice, Potato };
    public Crop crop;

    public float growDuration = 3F;

    public SpriteRenderer cropGrowing, cropReady;

    float _growDuration;

    bool isGrowing, cropsAreReady;

    Player player;
    AudioSource aud;


    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        aud = GetComponent<AudioSource>();
    }


    void Start()
    {
        _growDuration = growDuration;
    }


    void Update()
    {
        if (isGrowing)
        {
            if (_growDuration <= 0) // Crops are done growing
            {
                cropGrowing.enabled = false;
                cropReady.enabled = true;
                isGrowing = false;
                cropsAreReady = true;

                _growDuration = growDuration;

                return;
            }

            _growDuration -= Time.deltaTime; // Crops will continue to grow
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cropsAreReady && !player.hasHarvested) // Plot will  be reset
            {
                aud.Play();

                cropGrowing.enabled = false;
                cropReady.enabled = false;
                cropsAreReady = false;
                player.crop.enabled = true;
                player.hasHarvested = true;

                return;
            }
            else if (_growDuration == growDuration && !player.hasHarvested) // Crops will start to grow
            {
                cropGrowing.enabled = true;
                cropReady.enabled = false;
                isGrowing = true;
            }
            else if(cropsAreReady && !player.hasHarvested) // Plot will  be reset
            {
                aud.Play();

                cropGrowing.enabled = false;
                cropReady.enabled = false;
                cropsAreReady = false;
                player.hasHarvested = true;

                return;
            }
            else if(_growDuration == growDuration && !player.hasHarvested) // Crops will start to grow
            {
                cropGrowing.enabled = true;
                cropReady.enabled = false;
                isGrowing = true;
            }
        }
    }
}

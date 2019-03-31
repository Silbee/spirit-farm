using UnityEngine;

public class CropGrower : MonoBehaviour
{
    public FirstPlayer player;
    public SpriteRenderer crop;

    public float growDuration = 3;
    float _growDuration;

    bool isGrowing, cropsAreReady;

    public GameObject cropsGrowing, cropsReady;

    /*
     * De bedoeling is dat als je meerdere gewas-stages hebt en dat ie door elke stage loopt
     * 
     * [Tooltip("The first index is considered the first stage and the last index the last stage.")]
     * public GameObject[] cropStages; 
    */

    AudioSource aud;


    void Awake()
    {
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
                cropsGrowing.SetActive(false);
                cropsReady.SetActive(true);
                isGrowing = false;
                cropsAreReady = true;

                _growDuration = growDuration;

                return;
            }

            _growDuration -= Time.deltaTime; // Crops will continue to grow
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (cropsAreReady && !player.hasHarvested) // Plot will  be reset
            {
                aud.Play();

                cropsGrowing.SetActive(false);
                cropsReady.SetActive(false);
                cropsAreReady = false;
                player.hasHarvested = true;
                crop.enabled = true;

                return;
            }
            else if (_growDuration == growDuration && !player.hasHarvested) // Crops will start to grow
            {
                cropsGrowing.SetActive(true);
                cropsReady.SetActive(false);
                isGrowing = true;
            }
        }
    }
}

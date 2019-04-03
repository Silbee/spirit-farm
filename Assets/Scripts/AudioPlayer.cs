using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource aud;
    public AudioClip clip;

    [Tooltip("Usually meant for music.")]
    public bool playAudioOnStart;


    void Awake()
    {
        aud = GetComponent<AudioSource>();
    }


    void Start()
    {
        aud.clip = clip;

        if (playAudioOnStart)
        {
            aud.Play();
        }
    }
}

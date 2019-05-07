using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;


    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayAudio();
    }


    public void PlayAudio()
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}

using UnityEngine;

public class RandomZombieNoise : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.time = Random.Range(0f, audioSource.clip.length);
        audioSource.Play();
    }
}

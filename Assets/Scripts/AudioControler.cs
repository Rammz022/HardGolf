using UnityEngine;

public class AudioControler : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicVolume = 0.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void SetVolume(float volume)
    {
       musicVolume = volume;
    }
}

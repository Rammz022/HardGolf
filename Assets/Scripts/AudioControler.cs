using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    private AudioSource audioSource;
    private float misicVolume = 1.0f;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = misicVolume;
    }

    public void SetVolume(float volume)
    {
        misicVolume = volume;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectsVolume : MonoBehaviour
{

    private AudioSource m_AudioSource;
    private float m_Volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_AudioSource.volume = m_Volume;
    }

    public void SetVolume(float volume)
    {
        m_AudioSource.Play();
        m_Volume = volume;
    }
}

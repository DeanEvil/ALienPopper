using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Set the background music
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Loop the background music
            audioSource.Play(); // Start playing the background music
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

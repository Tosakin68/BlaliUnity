using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        if (GameObject.Find("AudioPlayer") != gameObject)
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void NewAudioClip(AudioClip audioClip, float volume)
    {
        AudioSource sfx = GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioSource>();
        if(sfx.clip != audioClip)
        {
            sfx.clip = audioClip;
            if (volume < 1)
            {
                sfx.volume = volume;
            }
            sfx.Play();
        }
    }
}

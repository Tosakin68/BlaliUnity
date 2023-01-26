using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioClip audioclip;
    public float volume;
    private void Awake()
    {
        MusicPlayer.NewAudioClip(audioclip, volume);
    }
}

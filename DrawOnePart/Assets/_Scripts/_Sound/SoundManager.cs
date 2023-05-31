using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource backGroundMusicSource;
    public AudioSource drawingSoundSource;
    public AudioSource winSoundSource;
    public AudioSource buttonClickSource;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

     
}
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Utility;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource bgMusic;
    public AudioSource[] soundEffects;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bgMusic.volume = Utility.SettingsData.bgMusicVol;
        foreach (AudioSource audio in soundEffects)
        {
            audio.volume = Utility.SettingsData.soundEffectVol;
        }
    }


   

    
}

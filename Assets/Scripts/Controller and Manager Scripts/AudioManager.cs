using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using Utility;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
   


    public AudioMixer mixer;
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
        
        mixer.SetFloat(AudioMixerParams.bgMusicVolume, Utility.SettingsData.bgMusicVol);
        mixer.SetFloat(AudioMixerParams.soundEffectVolume, Utility.SettingsData.soundEffectVol);
        
    }

    public void SetBGMusicVol(float value)
    {
        mixer.SetFloat(AudioMixerParams.bgMusicVolume, value);
    }

    public void SetSoundEffectVol(float value)
    {
        mixer.SetFloat(AudioMixerParams.soundEffectVolume, value);
    }

    public void PlayJumpSoundeffect()
    {
        soundEffects[2].Play();
    }


   

    
}

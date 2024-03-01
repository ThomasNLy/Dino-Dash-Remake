using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System.IO;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    public Slider soundEffectsSlider;
    public Slider bgMusicSlider;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            LoadAudioSettings();
            //used to check if the slider exists as the object this script is attached to will be in other scenes also.
            //that don't have the slider avaiable in it.
            if (soundEffectsSlider != null)
            {
                soundEffectsSlider.value = Utility.SettingsData.soundEffectVol;
                bgMusicSlider.value = Utility.SettingsData.bgMusicVol;
            }

        }
    }
    public void ChangeAudioSettings(Slider s)
    {
        if (AudioManager.Instance != null)
        {

            switch (s.gameObject.name)
            {
                case SettingsName.soundEffectsVol:
                    Utility.SettingsData.soundEffectVol = s.value;
                    AudioManager.Instance.SetSoundEffectVol(s.value);

                    break;
                case SettingsName.bgMusicVol:
                    Utility.SettingsData.bgMusicVol = s.value;
                    AudioManager.Instance.SetBGMusicVol(s.value);
                    break;
            }
        }



    }
    public void LoadAudioSettings()
    {

        SettingsSaveData settingsSaveData = new SettingsSaveData();
        if (Utility.SettingsData.bgMusicVol > -11)
        {
            Utility.SettingsData.bgMusicVol = -11;
        }
        else
        {
            settingsSaveData.bgMusicVol = Utility.SettingsData.bgMusicVol;
            settingsSaveData.soundEffectVol = Utility.SettingsData.soundEffectVol;
            Utility.SettingsData.bgMusicVol = settingsSaveData.bgMusicVol;
            Utility.SettingsData.soundEffectVol = settingsSaveData.soundEffectVol;

        }






    }
    public void SaveAudioSettings()
    {

        SettingsSaveData settingsSaveData = new SettingsSaveData();
        settingsSaveData.soundEffectVol = Utility.SettingsData.soundEffectVol;
        settingsSaveData.bgMusicVol = Utility.SettingsData.bgMusicVol;

    }
}

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
        if(AudioManager.Instance != null)
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
        string fileLoc = $"{Application.persistentDataPath}/Settings.json";
        if (File.Exists(fileLoc))
        {
            SettingsSaveData settingsSaveData = JsonUtility.FromJson<SettingsSaveData>(File.ReadAllText(fileLoc));
            
            Utility.SettingsData.bgMusicVol = settingsSaveData.bgMusicVol;
            Utility.SettingsData.soundEffectVol = settingsSaveData.soundEffectVol;
        }
        else
        {
            SettingsSaveData settingsSaveData = new SettingsSaveData();
            settingsSaveData.soundEffectVol = 1.0f;
            settingsSaveData.bgMusicVol = 1.0f;
            string json = JsonUtility.ToJson(settingsSaveData);
            Utility.SettingsData.bgMusicVol = 1.0f;
            Utility.SettingsData.soundEffectVol = 1.0f;
            File.WriteAllText(fileLoc, json);
        }




    }
    public void SaveAudioSettings()
    {
        

        try
        {
            string fileLoc = $"{Application.persistentDataPath}/Settings.json";
            if (File.Exists(fileLoc))
            {
                SettingsSaveData settingsSaveData = new SettingsSaveData();
                settingsSaveData.soundEffectVol = Utility.SettingsData.soundEffectVol;
                settingsSaveData.bgMusicVol = Utility.SettingsData.bgMusicVol;
                string json = JsonUtility.ToJson(settingsSaveData);

                File.WriteAllText(fileLoc, json);
            }
         

         
        }
        catch (FileNotFoundException e)
        {
            string fileLoc = $"{Application.persistentDataPath}/Settings.json";
            Debug.LogError(e.Message);
            Debug.LogError("No settings save file found creating one");
            SettingsSaveData settingsSaveData = new SettingsSaveData();
            settingsSaveData.soundEffectVol = 0f;
            settingsSaveData.bgMusicVol = 0f;
            string json = JsonUtility.ToJson(settingsSaveData);

            File.WriteAllText(fileLoc, json);

        }
       





    }
}

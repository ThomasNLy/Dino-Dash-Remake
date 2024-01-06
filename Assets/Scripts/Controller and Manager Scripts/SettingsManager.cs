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
        }
    }
    public void ChangeAudioSettings(Slider s)
    {

        switch (s.gameObject.name)
        {
            case "Sound Effects Slider":
                Utility.SettingsData.soundEffectVol = s.value;
                for(int i = 0; i < AudioManager.Instance.soundEffects.Length; i++)
                {
                    AudioManager.Instance.soundEffects[i].volume = s.value;
                }
                
                break;
            case "BG Music Slider":
                Utility.SettingsData.bgMusicVol = s.value;
                AudioManager.Instance.bgMusic.volume = s.value;
                break;
        }


    }
    public void LoadAudioSettings()
    {
        string fileLoc = $"{Application.persistentDataPath}/Settings.json";
        if (File.Exists(fileLoc))
        {
            SettingsSaveData settingsSaveData = JsonUtility.FromJson<SettingsSaveData>(File.ReadAllText(fileLoc));
            Debug.Log(settingsSaveData);
            Utility.SettingsData.bgMusicVol = settingsSaveData.bgMusicVol;
            Utility.SettingsData.soundEffectVol = settingsSaveData.soundEffectVol;
        }
        else
        {
            SettingsSaveData settingsSaveData = new SettingsSaveData();
            settingsSaveData.soundEffectVol = 1.0f;
            settingsSaveData.bgMusicVol = 1.0f;
            string json = JsonUtility.ToJson(settingsSaveData);

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
            settingsSaveData.soundEffectVol = 1.0f;
            settingsSaveData.bgMusicVol = 1.0f;
            string json = JsonUtility.ToJson(settingsSaveData);

            File.WriteAllText(fileLoc, json);

        }
       





    }
}

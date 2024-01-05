using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using UnityEngine;
using Utility;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

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
        SaveAudioSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAudioSettings(string settingName, float volLevel)
    {
        
        switch (settingName)
        {
            case "soundEffect":
                Utility.SettingsData.soundEffectVol = volLevel;
                break;
            case "bgMusic":
                Utility.SettingsData.bgMusicVol = volLevel;
                break;
        }
                
        
    }
    public void SaveAudioSettings()
    {
        SettingsSaveData settingsSaveData = new SettingsSaveData();
        settingsSaveData.soundEffectVol = Utility.SettingsData.soundEffectVol;
        settingsSaveData.bgMusicVol= Utility.SettingsData.bgMusicVol;
        string json = JsonUtility.ToJson(settingsSaveData);
        string fileLoc =  $"{Application.persistentDataPath}/Settings.json";
    
        File.WriteAllText(fileLoc, json);

    }

    
}

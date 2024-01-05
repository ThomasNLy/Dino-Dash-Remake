
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Utility;


public class SaveFileManager : MonoBehaviour
{
 
    public static SaveFileManager Instance;
   



    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            LoadSaveData();

           // LoadSaveData2();
           

        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
      
       
    }


    public void SaveScore(int score)
    {
   
        if (score > Utility.SaveData.highScore)
        {
            Utility.SaveData.highScore = score;
           
        }

        LevelSaveDataInfo data = new LevelSaveDataInfo("Level1", Utility.SaveData.highScore);
        string jsonString = JsonUtility.ToJson(data);
        string saveFile = Application.persistentDataPath + "/SaveFile.json";
        File.WriteAllText(saveFile, jsonString);

       


    }

    public void SaveScore2(int score)
    {
        if (score > Utility.SaveData.highScore)
        {
            Utility.SaveData.highScore = score;

        }

        LevelSaveDataInfo data = new LevelSaveDataInfo("Level1", Utility.SaveData.highScore);
        SaveFileMultiLevels datafile = new SaveFileMultiLevels(1, new[] { data});
        string jsonString = JsonUtility.ToJson(datafile);
        string saveFile = Application.persistentDataPath + "/SaveFile.json";
        File.WriteAllText(saveFile, jsonString);
    }

  
    public int GetHighScore()
    {
        return Utility.SaveData.highScore;
    }

    private void LoadSaveData()
    {
        string saveFile = Application.persistentDataPath + "/SaveFile.json";
        try
        {
            if (File.Exists(saveFile))
            {
                LevelSaveDataInfo saveDataInfo = JsonUtility.FromJson<LevelSaveDataInfo>(File.ReadAllText(saveFile));
                Utility.SaveData.highScore = saveDataInfo.highscore;
               
            }
            else
            {
             
                Utility.SaveData.highScore = 0;
                LevelSaveDataInfo data = new LevelSaveDataInfo("level1", Utility.SaveData.highScore);
                string jsonString = JsonUtility.ToJson(data);
                File.WriteAllText(saveFile, jsonString);

            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(e.Message);
        }
    }

    /**
     * for usage when having multiple levels/ different levels in the game in the future
     */
    private void LoadSaveData2()
    {
        string saveFile = Application.persistentDataPath + "/SaveFile2.json";
        try
        {
            if (File.Exists(saveFile))
            {
                SaveFileMultiLevels saveDataInfo = JsonUtility.FromJson<SaveFileMultiLevels>(File.ReadAllText(saveFile));
                Debug.Log(saveDataInfo.levels[0]);
                LevelSaveDataInfo d = JsonUtility.FromJson<LevelSaveDataInfo>(saveDataInfo.levels[0]);
              
            }
            else
            {


                SaveFileMultiLevels data = new SaveFileMultiLevels(1, new[] { new LevelSaveDataInfo("Level1", 0) });
                string jsonString = JsonUtility.ToJson(data);
                File.WriteAllText(saveFile, jsonString);

            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(e.Message);
        }
    }






}

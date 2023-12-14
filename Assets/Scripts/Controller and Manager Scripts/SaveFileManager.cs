using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class SaveFileManager : MonoBehaviour
{
    SaveDataInfo saveDataInfo = new SaveDataInfo();
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
        }
        saveDataInfo.score = Utility.SaveData.score;
        saveDataInfo.highScore = Utility.SaveData.highScore;
    }

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(saveDataInfo.highScore);
    }


    public void SaveScore(int score)
    {
        Utility.SaveData.score = score;
        saveDataInfo.score = score;
        if (score > saveDataInfo.highScore)
        {
            Utility.SaveData.highScore = score;
            saveDataInfo.highScore = score;
        }



    }

    public int GetScore()
    {
        return saveDataInfo.score;
    }
    public int GetHighScore()
    {
        return saveDataInfo.highScore;
    }

    public SaveDataInfo GetSaveData()
    {
        return saveDataInfo;
    }



    
}

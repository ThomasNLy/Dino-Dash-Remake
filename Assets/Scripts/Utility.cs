using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public static class Tags
{
    public static string player = "Player";
    public static string obstacle = "Obstacle";
    public static string powerup = "Powerup";

}

public static class AnimationStates
{
    public static string attacking = "IsAttacking";
    public static string jumping = "IsJumping";
    public static string grounded = "IsGrounded";
}

public static class SettingsName
{
    public const string soundEffectsVol = "Sound Effects Slider";
    public const string bgMusicVol = "BG Music Slider";
}

namespace Utility {
    public static class SaveData
    {
  
        public static int highScore;
    }
    public static class SettingsData
    {
        public static float soundEffectVol;
        public static float bgMusicVol;
    }
    public struct SettingsSaveData
    {
        public float soundEffectVol;
        public float bgMusicVol;
    }
    public struct SaveDataInfo
    {
        public int highscore;
      
        public SaveDataInfo(int highscore)
        {
            
            this.highscore = highscore;
         
        }

    }

    /**
     * 
     * code below for future use when having multiple levels
     * 
     */
    public struct LevelSaveDataInfo
    {
        public string levelName;
        public int highscore;
        public LevelSaveDataInfo(string lvName, int score)
        {
            this.levelName = lvName;
            this.highscore = score;
        }

    }
    public struct SaveFileMultiLevels
    {
        public string[] levels;
        public SaveFileMultiLevels(int numLvls, LevelSaveDataInfo[] jsonData)
        {
            levels = new string[numLvls];
            for (int i = 0; i < numLvls; i++)
            {
                levels[i] = JsonUtility.ToJson(jsonData[i]);
            }

        }
        
    }

}


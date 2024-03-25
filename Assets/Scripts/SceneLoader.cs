using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
   

    public void LoadScene(string sceneName)
    {
        // ensures that time is running since the pause menu freezes time and exiting the game/loading scene doesn't reset it
        Time.timeScale = 1.0f;  
        
        SceneManager.LoadScene(sceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{

    public GameObject settingsMenu;
    public GameObject audioSettingsMenu;
    public GameObject controlsSettingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    public void HideSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void ShowAudioSettinsgMenu()
    { 
        audioSettingsMenu.SetActive(true);
    }
    public void HideAudioSettingsMenu()
    { 
        audioSettingsMenu.SetActive(false);
    }
    public void ShowControlsSettingsMenu()
    {
        controlsSettingsMenu.SetActive(true);
    }
    public void HideControlsSettingsMenu()
    {
        controlsSettingsMenu.SetActive(false);
    }

    public void QuitApplication()
    {
        Application.Quit();   
    }
}

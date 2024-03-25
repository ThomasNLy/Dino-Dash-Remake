using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{

    public GameObject settingsMenu;
    public GameObject audioSettingsMenu;
    public GameObject controlsSettingsMenu;
    public static MainMenuUIManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void ShowSettingsMenu()
    {
        settingsMenu.SetActive(true);
        MainMenuInputController.Instance.exitFunction = HideSettingsMenu;
    }
    public void HideSettingsMenu()
    {
        settingsMenu.SetActive(false);
        MainMenuInputController.Instance.exitFunction = Application.Quit;
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

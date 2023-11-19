using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Slider powerupBar;

    public GameObject pauseMenu;

    private void Awake()
    {

        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            pauseMenu = GameObject.Find("Pause Menu");
            pauseMenu.SetActive(false);
            
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerupBar.value = GameManager.Instance.PowerUpPoints;
        
    }

    public void ShowPauseMenu(bool pauseGame)
    {
        
        pauseMenu.SetActive(pauseGame);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Slider powerupBar;

    public GameObject pauseMenu;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;

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
            gameOverScreen = GameObject.Find("Game Over Screen");
            gameOverScreen.SetActive(false);
            
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateUI()
    {
        powerupBar.value = GameManager.Instance.PowerUpPoints;
        scoreText.text = $"Score {GameManager.Instance.Score.ToString()}";
    }
    public void ShowPauseMenu(bool pauseGame)
    {
        
        pauseMenu.SetActive(pauseGame);
    }

    public void TurnOnGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void TurnOffGameOverScreen()
    {
        gameOverScreen.SetActive(false);
    }
}

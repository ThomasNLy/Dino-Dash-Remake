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
    public TextMeshProUGUI highScoreText;
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
        highScoreText.text = $" Highscore {Utility.SaveData.highScore.ToString()}";
        highScoreText.gameObject.SetActive(Utility.SaveData.highScore > 0 ? true : false);
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

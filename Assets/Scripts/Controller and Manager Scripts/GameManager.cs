using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Points and Gameplay Stats")]
    [SerializeField]
    private int powerUpPoints;
    [SerializeField]
    private int score;
    [SerializeField]
    private float scoreTimer;

    [Header("Floor and obstacle scrolling speed")]
    public int scrollingSpeed;

    [Header("Floor parrallax game object")]
    public ScrollingParallax floor;


    [Header("Game State")]
    private bool gamePaused;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Time.timeScale = 1.0f;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUpPoints = 0;
        score = 0;
        scrollingSpeed = -5;
        scoreTimer = 0f;


    }

    // Update is called once per frame
    void Update()
    {
        floor.ScrollingSpeed = scrollingSpeed;
        ScoreTimer();
      
        UIManager.Instance.UpdateUI();
     
       
    }

    public int PowerUpPoints
    {
        get { return powerUpPoints; }
        set { powerUpPoints = value; }
    }
    public int Score
    {
        get { return score; }
        set { score = value;  }
    }

    public bool GamePaused
    {
        get { return gamePaused; }
        set { gamePaused = value; }
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void ToggleGamePaused()
    {

        gamePaused = !gamePaused;
        if (gamePaused)
        {
            Debug.Log("PauseGame");
            PauseGame();
          
        }
        else
        {
            ResumeGame();
        }
        Debug.Log($"Game manager is paused: {gamePaused}");
        UIManager.Instance.ShowPauseMenu(gamePaused);
    }

    private void ScoreTimer()
    {
        if (scoreTimer < 3f)
        {
            scoreTimer += Time.deltaTime;
           
        }
        else
        {
            scoreTimer = 0f;
            score += 1;
        }
    }
 
    
}

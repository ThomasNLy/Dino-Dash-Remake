using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Points and Gameplay Stats")]
    [SerializeField]
    private int powerUpPoints;

    [Header("Floor and obstacle scrolling speed")]
    public int scrollingSpeed;

    [Header("Floor parrallax game object")]
    public ScrollingParallax floor;
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
        scrollingSpeed = -5;
    }

    // Update is called once per frame
    void Update()
    {
        floor.ScrollingSpeed = scrollingSpeed;
    }

    public int PowerUpPoints
    {
        get { return powerUpPoints; }
        set { powerUpPoints = value; }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}

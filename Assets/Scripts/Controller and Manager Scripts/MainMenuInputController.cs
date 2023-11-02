using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInputController : MonoBehaviour
{

    public static MainMenuInputController Instance;
    private PlayerInputActions inputs;
    public SceneLoader startButton;

    private void Awake()
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

    // Start is called before the first frame update
    void Start()
    {
        inputs = new PlayerInputActions();
        inputs.Menu.Enable();
        inputs.Menu.Start.performed += ctx => 
        {
            Debug.Log("Game Started");
            startButton.LoadScene("Level1");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

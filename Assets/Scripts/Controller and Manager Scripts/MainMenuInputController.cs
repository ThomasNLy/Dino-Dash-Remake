using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuInputController : MonoBehaviour
{

    public static MainMenuInputController Instance;
    private PlayerInputActions inputs;
    public SceneLoader startButton;
    public delegate void ExitFunction();
    public ExitFunction exitFunction;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            exitFunction = Application.Quit;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputs = new PlayerInputActions();
        inputs.Menu.Enable();
        inputs.Menu.Start.performed += StartGame;

        inputs.Menu.Exit.performed += Exit;
    }

    private void OnDestroy()
    {
        inputs.Menu.Exit.performed -= Exit;
        inputs.Menu.Start.performed -=StartGame;
    }

    private void Exit(InputAction.CallbackContext ctx)
    {
        exitFunction();
      
    }

    private void StartGame(InputAction.CallbackContext ctx)
    {

        
        startButton.LoadScene("Level1");
    }

   
}

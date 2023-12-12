using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        inputs.Menu.Start.performed += StartGame;

        inputs.Menu.Exit.performed += ExitGame;
    }

    private void OnDestroy()
    {
        inputs.Menu.Exit.performed -= ExitGame;
        inputs.Menu.Start.performed -=StartGame;
    }

    private void ExitGame(InputAction.CallbackContext ctx)
    {
        Debug.Log("main menu, Exit GAME");
      
    }

    private void StartGame(InputAction.CallbackContext ctx)
    {

        Debug.Log("Game Started");
        startButton.LoadScene("Level1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    
    public PlayerSpriteObject player;
    

    PlayerInputActions inputs;
    // Start is called before the first frame update


    [Header("Debug")]
    private bool pauseGame;

    private void Awake()
    {
        if (Instance != null && this != Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        inputs = new PlayerInputActions();
        inputs.Gameplay.Enable();
        inputs.Menu.Enable();
        inputs.Gameplay.Jump.performed += onJump;
        inputs.Gameplay.Attack.performed += onAttack;

        //pause menu 
        inputs.Menu.Exit.performed += OnExit;
    }

    // Update is called once per frame
    void Update()
    {
        player.UpdateSprite();
        player.HandleAttack();
        
    }

    private void OnDestroy()
    {
        inputs.Menu.Exit.performed -= OnExit;
        inputs.Gameplay.Jump.performed -= onJump;
        inputs.Gameplay.Attack.performed -= onAttack;
    }


    private void OnExit(InputAction.CallbackContext context)
    {
        
        GameManager.Instance.ToggleGamePaused();

        if (GameManager.Instance.GamePaused)
        {
            inputs.Menu.Enable();
            inputs.Gameplay.Disable();

        }
        else
        {
            inputs.Gameplay.Enable();

        }
    }


    private void onJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            player.isJumping = true;
        }
    }

    private void onAttack(InputAction.CallbackContext context)
    {
        if (context.performed && GameManager.Instance.PowerUpPoints >= 5)
        {
            
            GameManager.Instance.PowerUpPoints = 0;
            player.Attack();
        }
        
    }

    /**
     * 
     * used by the pause button in the game when clicked will call this function to disable/enable gameplay controls
     */
    public void PauseGame()
    {
 

        if (GameManager.Instance.GamePaused)
        {
            inputs.Menu.Enable();
            inputs.Gameplay.Disable();

        }
        else
        {
            inputs.Gameplay.Enable();

        }
    }

    public void EnableGameplayControls()
    {
        inputs.Gameplay.Enable();
    }
    public void DisableGameplayControls()
    {
        inputs.Gameplay.Disable();
    }
    public void EnableMenuControls()
    {
        inputs.Menu.Enable();
    }
    public void DisableMenuControls()
    {
        inputs.Menu.Disable();
    }
}

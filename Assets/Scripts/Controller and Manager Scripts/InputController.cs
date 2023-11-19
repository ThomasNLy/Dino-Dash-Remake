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
        inputs.Menu.Exit.performed += ctx =>
        {

            pauseGame = !pauseGame;
            UIManager.Instance.ShowPauseMenu(pauseGame);
            if (pauseGame)
            {
                inputs.Menu.Enable();
                inputs.Gameplay.Disable();
                GameManager.Instance.PauseGame();
            }
            else
            {
                inputs.Gameplay.Enable();
                GameManager.Instance.ResumeGame();
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        player.UpdateSprite();
        player.HandleAttack();
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
}

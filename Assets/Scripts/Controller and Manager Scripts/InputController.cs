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
        inputs.Gameplay.Jump.performed += onJump;
        inputs.Gameplay.Attack.performed += onAttack;
    }

    // Update is called once per frame
    void Update()
    {
        player.UpdateSprite();
        player.laser.SetActive(player.isAttacking);
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
        if (context.performed)
        {
            Debug.Log("Attack");
            player.laser.SetActive(true);
            player.isAttacking = true;
        }
        
    }
}

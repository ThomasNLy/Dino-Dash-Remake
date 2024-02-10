using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteObject : SpriteObject
{
    [Header("Animation and animator components")]
    [SerializeField]
    Animator animator;

    [Header("Animation obj with animation finished Handler script")]
    [SerializeField]
    HandleAnimationEnded animEndedHandler;

    [Header("Laser beam GameObject")]
    public GameObject laser;


    private void Awake()
    {
        animEndedHandler.animFinishedDelegate += AttackAnimationFinished;
    }


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void UpdateSprite()
    {
        if (this.isJumping)
        {
            AudioManager.Instance.PlayJumpSoundeffect();
        }
        HandleAnimations();
        base.UpdateSprite();
        

    }


    void HandleAnimations()
    {
        isInAir = rb.velocity.y != 0;
        animator.SetBool(AnimationStates.attacking, isAttacking);
        animator.SetBool(AnimationStates.jumping, this.isJumping);
        animator.SetBool(AnimationStates.grounded, grounded);
    }

    public void AttackAnimationFinished()
    {
      
        isAttacking = false;
        
    }

    public void Attack()
    {
        isAttacking = true;
        laser.SetActive(true);
        AudioManager.Instance.soundEffects[0].Play();
    }
    public void HandleAttack()
    {
        laser.SetActive(isAttacking);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.obstacle))
        {
            Debug.Log("Player got hit");
            //GameManager.Instance.IsGameOver = true;
            //UIManager.Instance.TurnOnGameOverScreen();
            GameManager.Instance.GameOver();
        }
       

       
    }

}

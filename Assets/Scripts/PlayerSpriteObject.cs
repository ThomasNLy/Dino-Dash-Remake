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
        HandleAnimations();
        base.UpdateSprite();
        

    }


    void HandleAnimations()
    {
        isInAir = rb.velocity.y != 0;
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetBool("IsJumping", this.isJumping);
        animator.SetBool("IsGrounded", grounded);
    }

    public void AttackAnimationFinished()
    {
      
        isAttacking = false;
        
    }

    public void Attack()
    {
        isAttacking = true;
        laser.SetActive(true);
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
        }

       
    }

}

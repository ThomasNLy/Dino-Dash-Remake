using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteObject : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private SpriteStatsScriptableObject stats;

    [SerializeField]
    protected float feetOffset;


   

    [Header("States")]
    public bool grounded = false;
    public bool isJumping = false;
    public bool canDoubleJump = false;
    public bool isAttacking = false;
    public bool isInAir = false;



    [Header("Collision LayerMasks")]
    [SerializeField]
    protected LayerMask ground;

    protected Rigidbody2D rb;



    private void Start()
    {
        Init();

    }

    public virtual void Init()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public virtual void Move()
    {
        this.transform.Translate(Vector3.right * stats.xspeed * Time.deltaTime);
        this.transform.Translate(Vector3.up * stats.yspeed * Time.deltaTime); // for anything that moves not affected by gravity
    }

    public virtual void Jump()
    {
        if (grounded)
        { 
            rb.AddForce(Vector2.up * stats.jumpForce, ForceMode2D.Impulse);
            
        }
       
       
        
        
    }
    public virtual void SecondJump()
    {
        rb.AddForce(Vector2.up * stats.jumpForce * 2, ForceMode2D.Impulse);  
    }

    public virtual void HandleJumping()
    {

        if (canDoubleJump && grounded)
        {
            canDoubleJump = false;
        }
        
        if (canDoubleJump)
        {
            canDoubleJump = false;
            SecondJump();
        }
        else if(grounded)
        {
            Jump();
            canDoubleJump = true;
        }
    }

    public virtual void UpdateSprite()
    {
        Move();
        if (isJumping)
        {
            isJumping = false;
            HandleJumping();
            
        }
        
        CheckOnGround();
        
       
    }

  

    public virtual void CheckOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down *  feetOffset, Vector2.down, 0.3f, ground);


        if (hit.collider != null)
        {
            grounded = true;
           

        }
        else { grounded = false; }
      
      
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 dir = Vector2.down * 0.3f;
        Gizmos.DrawRay(transform.position + Vector3.down * feetOffset, dir);
    }



}

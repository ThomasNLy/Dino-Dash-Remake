using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpriteObject : ObstacleSpriteObject
{
    // Start is called before the first frame update
    void Start()
    {
        base.Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
    }

    public override void UpdateSprite()
    {
        
        Move();
    }

    /**
    * used mmainly for power up items colliding with the player
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {

      
        if (collision.gameObject.CompareTag(Tags.player))
        {
            GameManager.Instance.PowerUpPoints += 1;
            GameManager.Instance.PowerUpPoints = Mathf.Clamp(GameManager.Instance.PowerUpPoints, 0, 5);
            this.Spawn(PowerUpManager.Instance.spawnLoc.position + Vector3.down * 20);
             
            AudioManager.Instance.soundEffects[1].Play();
          
        }
    }
}

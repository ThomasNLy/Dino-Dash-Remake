using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpriteObject : SpriteObject
{
    
    // Start is called before the first frame update
    void Start()
    {
        base.Init();
    }

    //Update is called once per frame
    void Update()
    {
        UpdateSprite();
    }

    public override void UpdateSprite()
    {
        Move();
    }
    public void Init(Vector3 spawnLoc)
    {
        this.transform.position = spawnLoc;
    }

    public void Spawn(Vector3 pos)
    {
        this.transform.position = pos;
    }


    /**
     * used mmainly for power up items colliding with the player
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("player hit");
        if (collision.gameObject.CompareTag(Tags.player))
        {

            this.Spawn(PowerUpManager.Instance.spawnLoc.position + Vector3.down * 20);

        }
    }
}

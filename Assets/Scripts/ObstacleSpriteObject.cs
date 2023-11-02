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
        stats.xspeed = GameManager.Instance.scrollingSpeed;
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


   
}

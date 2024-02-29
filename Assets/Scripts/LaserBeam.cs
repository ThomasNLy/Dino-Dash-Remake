using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
         ObstacleSpriteObject hitItem = collision.gameObject.GetComponentInParent<ObstacleSpriteObject>();
        if (collision.gameObject.CompareTag(Tags.obstacle))
        {
          
            hitItem.Spawn(ObstacleManager.Instance.despawnLocation.position);
        }
    }
}

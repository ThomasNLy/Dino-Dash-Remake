using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public GameObject background;
    private float bgTextureWidth;
    private float bgTextureWidthHalf;

    [Header("Scrolling Speed")]
    [SerializeField]
    private int bgScrollingSpeed = -5;
    
    // Start is called before the first frame update
    void Start()
    {
        
        bgTextureWidth = background.GetComponent<SpriteRenderer>().sprite.bounds.size.x * background.transform.localScale.x;
        bgTextureWidthHalf = bgTextureWidth / 2;
    }

    // Update is called once per frame
    void Update()
    {
        background.transform.Translate(new Vector3(bgScrollingSpeed, 0, 0) * Time.deltaTime);
        if (background.transform.position.x + bgTextureWidthHalf < -30)
        {
            background.transform.position = new Vector3(30 + bgTextureWidthHalf, 0, 0);
        }
        
        
    }

   
}

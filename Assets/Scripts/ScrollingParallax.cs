using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingParallax : MonoBehaviour
{
    public GameObject image;
    private float imageTextureWidth;
    private float imageTextureWidthHalf;

    [Header("Scrolling Speed")]
    [SerializeField]
    private int scrollingSpeed = -5;

    // Start is called before the first frame update
    void Start()
    {

        imageTextureWidth = image.GetComponent<SpriteRenderer>().sprite.bounds.size.x * image.transform.localScale.x;
        imageTextureWidthHalf = imageTextureWidth / 2;
    }

    // Update is called once per frame
    void Update()
    {
        image.transform.Translate(new Vector3(scrollingSpeed, 0, 0) * Time.deltaTime);
        if (image.transform.position.x + imageTextureWidthHalf < -30)
        {
            image.transform.position = new Vector3(imageTextureWidthHalf + 2, image.transform.position.y, 0);
        }


    }

    public int ScrollingSpeed
    { 
        get { return scrollingSpeed; } 
        set { scrollingSpeed = value; } 
    }

   


}

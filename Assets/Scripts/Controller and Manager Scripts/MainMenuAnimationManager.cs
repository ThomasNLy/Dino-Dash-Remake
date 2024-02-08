using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationManager : MonoBehaviour
{
    public Animator dinoAnimator;
   
    public void RandomizeDinoAnimation()
    {
        int randNum = (int)Random.Range(0, 2);
        dinoAnimator.SetFloat("type", randNum);

    }
}

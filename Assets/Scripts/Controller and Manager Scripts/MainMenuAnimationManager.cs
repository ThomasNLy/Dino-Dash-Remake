using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimationManager : MonoBehaviour
{
    public Animator dinoAnimator;
    public GameObject behindBush;
    public GameObject infrontOfBush;

    public void RandomizeDinoAnimation()
    {
        int randNum = (int)Random.Range(0, 2);
        dinoAnimator.SetFloat("type", randNum);

    }

    public void RunInFrontOfBush() {
        this.transform.SetParent(infrontOfBush.transform);
    }
    public void HideBehindBush()
    {
        this.transform.SetParent(behindBush.transform);
    }
}

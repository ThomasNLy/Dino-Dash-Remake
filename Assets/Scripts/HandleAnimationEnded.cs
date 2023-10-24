using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimationEnded : MonoBehaviour
{
    public delegate void handleAnimationFinishedDelegate();
    public handleAnimationFinishedDelegate animFinishedDelegate;
    public void AnimationFinished()
    {

        animFinishedDelegate();
       
    }
}

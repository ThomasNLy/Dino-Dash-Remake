using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sprite Stats", menuName = "DinoDash/SpriteStats")]
public class SpriteStatsScriptableObject : ScriptableObject
{
    public float xspeed, yspeed, jumpForce;
}

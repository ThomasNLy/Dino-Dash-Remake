using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public static class Tags
{
    public static string player = "Player";
    public static string obstacle = "Obstacle";
    public static string powerup = "Powerup";

}

public static class AnimationStates
{
    public static string attacking = "IsAttacking";
    public static string jumping = "IsJumping";
    public static string grounded = "IsGrounded";
}

namespace Utility {
    public static class SaveData
    {
        public static int score;
        public static int highScore;
    }

    public struct SaveDataInfo
    {
        public int score;
        public int highScore;
    }
}


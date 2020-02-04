using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatePlayer {

    public static void GetInitialState(Character c)
    {
        c.SetState(new Walk());
    }
    public abstract Vector2 Action(Character c);
    protected abstract bool CorrectAnimation(Character c);
    public static void SetState(Character c,StatePlayer sp)
    {
        c.SetState(sp);
    }

    public float Duration(string s)
    {
        switch (s)
        {
            case "Walk":
            case "ReverseWalk":
                return 2f;
            case "Jump":
                return 1.2f;
            case "DoubleJump":
                return 1.35f;
            case "WallJump":
                return 1.4f;
            case "ClimbRight":
            case "ClimbLeft":
                return 2.15f;
            case "Push":
                return 4f;
            case "Button":
                return 2.2f;
            case "Lever":
                return 1.4f;
            case "Fall":
            case "ReverseFall":
                return 2.2f;
            case "Can't":
                return 2f;
            default:
                return 1f;
        }
    }
}

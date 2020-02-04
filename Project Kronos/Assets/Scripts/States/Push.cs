using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : StatePlayer
{
    public override Vector2 Action(Character c)
    {
        if (CorrectAnimation(c))
        {
            c.Speed = 0.04f;
            c.SetAnimation("Push");
            c.IsMoving = true;
            return new Vector2(1, 0);
        }
        else
        {
            c.SetAnimation("Can't");
            c.IsMoving = true;
            return new Vector2(0, 0);
        }

    }

    protected override bool CorrectAnimation(Character c)
    {
        int function1 = c.TheGrid[c.Actual.Pos_x + 1, c.Actual.Pos_y].Function;
        int function2 = c.TheGrid[c.Actual.Pos_x+2, c.Actual.Pos_y].Function;
        int function3 = c.TheGrid[c.Actual.Pos_x + 2, c.Actual.Pos_y-1].Function;

        return (function1 == 0 || function1 == 3) && (function2 == 0||(function2==7&&function3==6));
    }
}
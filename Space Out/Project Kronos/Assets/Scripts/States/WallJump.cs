using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : StatePlayer
{
    public override Vector2 Action(Character c)
    {
        if (CorrectAnimation(c))
        {
            c.Speed = 0.04f;
            c.SetAnimation("WallJump");
            c.IsMoving = true;
            return new Vector2(0, 1);
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
        int function1 = c.TheGrid[c.Actual.Pos_x+ 2, c.Actual.Pos_y+1].Function;
        int function2 = c.TheGrid[c.Actual.Pos_x , c.Actual.Pos_y+1].Function;

        return function1 == 6 && function2 == 0;
    }
}

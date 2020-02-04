using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : StatePlayer
{
    private int function;
    public override Vector2 Action(Character c)
    {
        if (CorrectAnimation(c))
        {
            c.Speed = 0.04f;
            c.SetAnimation("Walk");
            c.IsMoving = true;
            return new Vector2(1, 0);
        }
        else
        {
            if(function==7)
            {
                function = c.TheGrid[c.Actual.Pos_x + 1, c.Actual.Pos_y-1].Function;
                if (function == 0|| (function == 7 && c.TheGrid[c.Actual.Pos_x + 1, c.Actual.Pos_y - 2].Function == 3))
                {
                    c.Speed = 0.04f;
                    c.SetAnimation("Fall");
                    c.IsMoving = true;
                    return new Vector2(1, -1);
                }
            }
            c.SetAnimation("Can't");
            c.IsMoving = true;
            return new Vector2(0, 0);
        }

    }

    protected override bool CorrectAnimation(Character c)
    {
        function = c.TheGrid[c.Actual.Pos_x + 1, c.Actual.Pos_y].Function;

        return function == 0 || function == 2 || function == 4 || function == 5;
    }
}

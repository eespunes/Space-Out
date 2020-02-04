using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : StatePlayer
{
    public override Vector2 Action(Character c)
    {
        if (CorrectAnimation(c))
        {
            c.Speed = 0.04f;
        c.SetAnimation("DoubleJump");
        c.IsMoving = true;
        return new Vector2(3, 0);
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
    int function1 = c.TheGrid[c.Actual.Pos_x , c.Actual.Pos_y+1].Function;
        int function2 = c.TheGrid[c.Actual.Pos_x + 1, c.Actual.Pos_y+1].Function;
        int function3 = c.TheGrid[c.Actual.Pos_x + 1, c.Actual.Pos_y+2].Function;
        int function4 = c.TheGrid[c.Actual.Pos_x + 2, c.Actual.Pos_y+2].Function;
        int function5 = c.TheGrid[c.Actual.Pos_x + 3, c.Actual.Pos_y+2].Function;
        int function6 = c.TheGrid[c.Actual.Pos_x + 3, c.Actual.Pos_y+1].Function;
        int function7 = c.TheGrid[c.Actual.Pos_x + 3, c.Actual.Pos_y].Function;

    return function1==7&&(function2 == 0 || function2 == 2 || function2 == 4 || function2 == 5 || function2 == 7) && function3==7&&(function4 == 0 || function4 == 2 || function4 == 4 || function4 == 5||function4==7) && function5==7&&function6==7&&(function7 == 0|| function7 == 2|| function7 == 4|| function7 ==5);
}
}


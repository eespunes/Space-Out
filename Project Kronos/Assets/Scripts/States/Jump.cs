using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : StatePlayer
{
    public override Vector2 Action(Character c)
    {
        if (CorrectAnimation(c))
        {
            c.Speed = 0.04f;
        c.SetAnimation("Jump");
        c.IsMoving = true;
        return new Vector2(2, 0);
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
    int function2 = c.TheGrid[c.Actual.Pos_x + 2, c.Actual.Pos_y].Function;

    return (function1 == 0 || function1 == 1 || function1 == 2 || function1 == 4 || function1 == 7) && (function2 == 0 || function2 == 2 || function2 == 4);
}
}

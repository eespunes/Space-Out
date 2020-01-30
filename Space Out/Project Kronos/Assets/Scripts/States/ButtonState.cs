using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState : StatePlayer
{
    public override Vector2 Action(Character c)
    {
        if (CorrectAnimation(c))
        {
            c.Speed = 0.04f;
        c.SetAnimation("Button");
        return new Vector2(0, 0);
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
        int function = c.TheGrid[c.Actual.Pos_x, c.Actual.Pos_y].Function;

        return function == 4;
    }
}
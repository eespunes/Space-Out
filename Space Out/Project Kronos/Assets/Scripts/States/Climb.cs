using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : StatePlayer {
    private string position;
    public override Vector2 Action(Character c)
    {
        if (CorrectAnimation(c))
        {
        c.Speed = 0.04f; 
        c.IsMoving = true;
            if (position.Equals("Right"))
            {
                c.SetAnimation("ClimbRight");
                return new Vector2(1, 1);
            }
            else
            {
                c.SetAnimation("ClimbLeft");
                return new Vector2(-1, 1);
            }
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
    int function2 = c.TheGrid[c.Actual.Pos_x + 1, c.Actual.Pos_y+1].Function;
        int function3 = c.TheGrid[c.Actual.Pos_x - 1, c.Actual.Pos_y].Function;
        int function4 = c.TheGrid[c.Actual.Pos_x - 1, c.Actual.Pos_y + 1].Function;
        bool left= (function3 == 3 && function4 == 7) || (function3 == 6 && function4 == 0), right= (function1 == 3 && function2 == 7) || (function1 == 6 && function2 == 0);
        if (left)
            position = "Left";
        else if(right)
            position = "Right";

        return right || left;
}
}

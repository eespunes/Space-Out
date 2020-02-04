using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject door;
    public Vector2 buttonPosition;
    public Vector2[] doorSpace,nextSpace;
    public int[] function;
    public bool isClosed;
    private LevelController level;
    private Character character;
    private int click;
    private bool clicked;
    // Use this for initialization
    void Start()
    {
        click = 0;
        level = GameObject.Find("LevelController").GetComponent<LevelController>();
        character = GameObject.Find("Stickman").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.Actual.Pos_x == buttonPosition.x && character.Actual.Pos_y == buttonPosition.y && (click == 0))
        {
            if (character.GetStateName().Equals("ButtonState") && character.SpacePressed && !character.Animation())
                clicked = true;
        }
        if (clicked)
        {
                if (isClosed)
                {
                    Open();
                    int i = 0;
                    foreach (Vector2 vector in doorSpace)
                    {
                            level.TheNodes[(int)vector.x, (int)vector.y].Function = function[i];
                        i++;
                    }
                    foreach (Vector2 vector in nextSpace)
                    {
                        level.TheNodes[(int)vector.x, (int)vector.y].Function = 6;
                    }
                    character.SpacePressed = false;
                }
        }
    }
    private void Open()
    {
        if (door.transform.position.x == level.TheNodes[(int)nextSpace[0].x, (int)nextSpace[0].y].Position.x && door.transform.position.z == level.TheNodes[(int)nextSpace[0].x, (int)nextSpace[0].y].Position.z)
        {
                clicked = false;
                click = 1;
        }
        else
            door.transform.position = Vector3.MoveTowards(door.transform.position, level.TheNodes[(int)nextSpace[0].x, (int)nextSpace[0].y].Position, 0.01f);
    }
    /*private void Close()
    {
        if (door.transform.position.x == level.TheNodes[(int)nextSpace[0].x, (int)nextSpace[0].y].Position.x && door.transform.position.z == level.TheNodes[(int)doorSpace[0].x, (int)doorSpace[0].y].Position.z)
        {
            if (nextSpace[0].x == nextSpace[1].x)
                buttonPosition = new Vector2(buttonPosition.x, buttonPosition.y + nextSpace.Length);
            else
                buttonPosition = new Vector2(buttonPosition.x + nextSpace.Length, buttonPosition.y);
        }
        else
            door.transform.position = Vector3.MoveTowards(door.transform.position, level.TheNodes[(int)nextSpace[0].x, (int)nextSpace[0].y].Position, 0.01f);
    }*/
}

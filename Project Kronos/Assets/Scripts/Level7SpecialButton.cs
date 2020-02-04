using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7SpecialButton : MonoBehaviour {

    public GameObject platform,door;
    public Vector2 buttonPosition;
    public Vector2[] platformSpace, platformNextSpace2, doorSpace, doorNextSpace;
    public int function;
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
        if (character.Actual.Pos_x == buttonPosition.x && character.Actual.Pos_y == buttonPosition.y&&(click==0||click==1))
        {
            if (character.GetStateName().Equals("ButtonState") && character.SpacePressed && !character.Animation())
                clicked = true;
        }
        if (clicked){
                if (isClosed)
                {
                    if (click == 0)
                    {
                        Open1();

                        foreach (Vector2 vector in platformSpace)
                        {
                                level.TheNodes[(int)vector.x, (int)vector.y].Function = 7;
                        }
                        foreach (Vector2 vector in doorNextSpace)
                        {
                            level.TheNodes[(int)vector.x, (int)vector.y].Function = 0;
                        }
                    }
                    else if (click == 1)
                    {
                        Open2();
                        foreach (Vector2 vector in platformNextSpace2)
                        {
                            level.TheNodes[(int)vector.x, (int)vector.y].Function = 7;
                        }
                        foreach (Vector2 vector in doorNextSpace)
                        {
                            level.TheNodes[(int)vector.x, (int)vector.y].Function = 0;
                        }
                        foreach (Vector2 vector in doorSpace)
                        {

                        if(level.TheNodes[(int)vector.x, (int)vector.y].Function!=2)
                            level.TheNodes[(int)vector.x, (int)vector.y].Function = 0;
                        }
                    }
                    character.SpacePressed = false;
                }
            }
    }
    private void Open1()
    {
        if (platform.transform.position.x == level.TheNodes[(int)doorNextSpace[0].x, (int)doorNextSpace[0].y].Position.x && platform.transform.position.z == level.TheNodes[(int)doorNextSpace[0].x, (int)doorNextSpace[0].y].Position.z)
        {
            clicked = false;
            click = 1;
        }
        else
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, level.TheNodes[(int)doorNextSpace[0].x, (int)doorNextSpace[0].y].Position, 0.01f);
    }
    private void Open2()
    {
        if (platform.transform.position.x == level.TheNodes[(int)platformNextSpace2[0].x, (int)platformNextSpace2[0].y].Position.x && platform.transform.position.z == level.TheNodes[(int)platformNextSpace2[0].x, (int)platformNextSpace2[0].y].Position.z)
        {
            if (door.transform.position.x == level.TheNodes[(int)doorNextSpace[0].x, (int)doorNextSpace[0].y].Position.x && door.transform.position.z == level.TheNodes[(int)doorNextSpace[0].x, (int)doorNextSpace[0].y].Position.z)
            {
                clicked = false;
                click = 2;
            }
            else
                door.transform.position = Vector3.MoveTowards(door.transform.position, level.TheNodes[(int)doorNextSpace[0].x, (int)doorNextSpace[0].y].Position, 0.01f);
        }
        else
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, level.TheNodes[(int)platformNextSpace2[0].x, (int)platformNextSpace2[0].y].Position, 0.01f);
    }
}

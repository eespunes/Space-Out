using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public Vector2 source, destiny;
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
        if (character.Actual.Pos_x == source.x && character.Actual.Pos_y == source.y && (click == 0))
        {
            if (character.GetStateName().Equals("LeverState") && character.SpacePressed && !character.Animation())
                clicked = true;
        }
        if (clicked)
        {
            Invoke("Teleportation", 1.4f);
        }
    }
    public void Teleportation()
    {
        character.gameObject.transform.position = new Vector3(level.TheNodes[(int)destiny.x, (int)destiny.y].Position.x, level.TheNodes[(int)destiny.x, (int)destiny.y].Position.y, level.TheNodes[(int)destiny.x, (int)destiny.y].Position.z + 0.25f);
        character.Actual = level.TheNodes[(int)destiny.x, (int)destiny.y];
        character.SpacePressed = false;
        clicked = false;
        click =1;
    }
}

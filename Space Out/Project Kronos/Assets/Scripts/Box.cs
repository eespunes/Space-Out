using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    public Vector2 boxPosition;
    private LevelController level;
    private Character character;
    private Node next;
    public GameObject one, two;
    private bool isMoving;
	// Use this for initialization
	void Start () {
        level = GameObject.Find("LevelController").GetComponent<LevelController>();
        character = GameObject.Find("Stickman").GetComponent<Character>();
        transform.position=level.TheNodes[(int)boxPosition.x, (int)boxPosition.y].Position;
        next = level.TheNodes[(int)boxPosition.x+1, (int)boxPosition.y];
        isMoving = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(character.Actual.Pos_x==boxPosition.x-1&& character.Actual.Pos_y == boxPosition.y)
        {
            if (isMoving||character.GetStateName().Equals("Push") && character.SpacePressed&&!character.Animation())
            {
                isMoving = true;
                if (next.Function == 0)
                    Move();
                else if (next.Function == 7)
                    Fall();
            }
        }
	}
    private void Move()
    {
        if (transform.position.x == level.TheNodes[(int)boxPosition.x+1, (int)boxPosition.y].Position.x && transform.position.z == level.TheNodes[(int)boxPosition.x+1, (int)boxPosition.y].Position.z)
        {
            level.TheNodes[(int)boxPosition.x, (int)boxPosition.y].Function = 0;
            boxPosition = new Vector2(boxPosition.x + 1, boxPosition.y);
            next = level.TheNodes[(int)boxPosition.x + 1, (int)boxPosition.y];
            level.TheNodes[(int)boxPosition.x, (int)boxPosition.y].Function = 3;
            isMoving = false;
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, level.TheNodes[(int)boxPosition.x+1, (int)boxPosition.y].Position, 0.005f);
    }
    private void Fall()
    {
        if (transform.position.x == level.TheNodes[(int)boxPosition.x + 1, (int)boxPosition.y].Position.x && transform.position.z == level.TheNodes[(int)boxPosition.x + 1, (int)boxPosition.y].Position.z)
        {
            level.TheNodes[(int)boxPosition.x, (int)boxPosition.y].Function = 0;
            boxPosition = new Vector2(boxPosition.x + 1, boxPosition.y);
            level.TheNodes[(int)boxPosition.x, (int)boxPosition.y].Function = 3;
            one.SetActive(true);
            two.SetActive(false);
            isMoving = false;
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, level.TheNodes[(int)boxPosition.x + 1, (int)boxPosition.y].Position, 0.005f);
    }
}

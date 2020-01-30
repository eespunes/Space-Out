using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    private StatePlayer statePlayer;
    public Animator animator;
    Vector2 nextNode;
    Node next;
    int index;
    LevelController level;

    public float Speed { get; set; }

    public bool IsMoving { get; set; }

    public Node Actual { get; set; }

    public Node[,] TheGrid { get; private set; }

    public bool SpacePressed { get; set; }
    private Pause pause;

    void Start () {
        level =GameObject.Find("LevelController").GetComponent<LevelController>();
        TheGrid = level.TheNodes;
        Actual = TheGrid[(int)level.playerPos.x, (int)level.playerPos.y];
        transform.position = new Vector3(Actual.Position.x,  Actual.Position.y,Actual.Position.z+0.25f);
        IsMoving = false;
        StatePlayer.GetInitialState(this);
        pause = GameObject.Find("Canvas").transform.Find("Pause Menu").GetComponent<Pause>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.Paused)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !IsMoving && !SpacePressed)
            {
                nextNode = statePlayer.Action(this);
                index = 0;
                next = TheGrid[(int)(Actual.Pos_x + nextNode.x), (int)(Actual.Pos_y + nextNode.y)];
                index++;
                level.DecreaseMoves();
            }
            if (Animation())
                if (IsMoving)
                    Move();
        }
	}
    private void Move()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        if (transform.position.x == next.Position.x&&transform.position.z == (next.Position.z+0.25))
        {
            Actual = next;
            level.Victory(Actual);
            IsMoving = false;
            SpacePressed = false;
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(next.Position.x, next.Position.y, next.Position.z + 0.25f), Speed);
    }
    public void SetState(StatePlayer sp)
    {
        statePlayer = sp;
    }
    public string GetStateName()
    {
        return statePlayer.ToString();
    }
    public void SetAnimation(string v)
    {
        animator.SetTrigger(v);
        if(!v.Equals("Can't"))
            SpacePressed = true;
    }
    public bool Animation()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0);
    }

}

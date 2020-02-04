using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public int sizeX, sizeY;
    public int moves;
    public LayerMask[] platforms;
    public Vector2 playerPos,winPos;
    [Header("Max 6 abilities")]
    public GameObject[] abilities;
    public Moves movesUI;

    public Node[,] TheNodes { get; private set; }

    void Awake()
    {
        LevelManager.SetLastLevel(SceneManager.GetActiveScene().name);
        movesUI.ChangeMoves(moves);
        Vector3 position;
        int middleX = sizeX / 2, middleY = sizeY / 2;
        TheNodes = new Node[sizeX, sizeY];
        int func;
        GameObject parent = GameObject.Find("Canvas");
        for (int i = 0; i < abilities.Length; i++)
        {
            Instantiate(abilities[i], parent.transform.Find("Ability (" + (i+1) + ")"));
        }
        for (int x = 0; x < sizeX; x++)
            for (int y = 0; y < sizeY; y++)
            {
                position = new Vector3((transform.position.x + (x - middleX)), 0, (transform.position.z + (y - middleY)));
                if (Physics.CheckSphere(position, 0.5f, platforms[0]))
                {
                    func = 0;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[1]))
                {
                    func = 1;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[2]))
                {
                    func = 2;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[3]))
                {
                    func = 3;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[4]))
                {
                    func = 4;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[5]))
                {
                    func = 5;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[6]))
                {
                    func = 6;
                }
                else
                {
                    func = 7;
                }
                TheNodes[x, y] = new Node(position, x, y, func);
            }
    }
    /*
    private void OnDrawGizmos()
    {
        int middleX = sizeX / 2, middleY = sizeY / 2;
        for (int x = 0; x < sizeX; x++)
            for (int y = 0; y < sizeY; y++)
            {
                Vector3 position = new Vector3((transform.position.x + (x - middleX)), 0, (transform.position.z + (y - middleY)));
                if (Physics.CheckSphere(position, 0.5f, platforms[0]))
                {
                    Gizmos.color = Color.black;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[1]))
                {
                    Gizmos.color = Color.red;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[2]))
                {
                    Gizmos.color = Color.blue;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[3]))
                {
                    Gizmos.color = Color.gray;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[4]))
                {
                    Gizmos.color = Color.green;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[5]))
                {
                    Gizmos.color = Color.cyan;
                }
                else if (Physics.CheckSphere(position, 0.5f, platforms[6]))
                {
                    Gizmos.color = Color.magenta;
                }
                else
                {
                    Gizmos.color = Color.white;
                }
                Handles.Label(position, x+","+y);
                Gizmos.DrawWireCube(position, Vector3.one);
            }
    }*/
    public void DecreaseMoves()
    {
        moves--;
        movesUI.ChangeMoves(moves);
    }
    public void Victory(Node n) {
        if(n.Pos_x==winPos.x&&n.Pos_y==winPos.y)
            SceneManager.LoadScene("Win Scene");
        else if (moves <= 0)
            SceneManager.LoadScene("Lose Scene");
    }
}
public class Node
{
    public Node(Vector3 c, int px, int py, int funct)
    {
        Pos_x = px;
        Pos_y = py;
        Function = funct;
        Position = c;
    }

    //Gets and setters
    public int Function { get; set; }

    public int Pos_x { get; set; }

    public int Pos_y { get; set; }
    public Vector3 Position { get; set; }

}

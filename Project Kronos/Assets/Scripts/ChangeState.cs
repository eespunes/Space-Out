using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour {

    public string state;
    private Character character;
    private void Start()
    {
        character = GameObject.Find("Stickman").GetComponent<Character>();
    }
    public void SetState() {
                StatePlayer.SetState(character, (StatePlayer)System.Activator.CreateInstance(System.Type.GetType(state)));
        }
}

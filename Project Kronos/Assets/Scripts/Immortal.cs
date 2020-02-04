using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immortal : MonoBehaviour {

    private string sceneName;
	void Start () {
        DontDestroyOnLoad(this);
	}

	void Update () {
		
	}
}

using UnityEngine;

public class Camera : MonoBehaviour {

    public int size;
    private Transform character;
	// Use this for initialization
	void Start () {
        UnityEngine.Camera.main.orthographicSize = size * 0.5f;
        character = GameObject.Find("Stickman").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = new Vector3(character.position.x, transform.position.y, character.position.z+2);
    }
}

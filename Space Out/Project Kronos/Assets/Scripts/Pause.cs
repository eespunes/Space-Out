using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public GameObject[] buttons;
    public Sprite pause, resume;
    private Image image;

    public bool Paused { get; private set; }

    private void Start()
    {
        image = GetComponent<Image>();
        Paused = false;
    }
    public void Pausa()
    {
        if(Paused)
            DesactivateButtons();
        else
        ActivateButtons();
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }
    private void ActivateButtons()
    {
        image.sprite = resume;
        image.color = Color.green;
        foreach(GameObject go in buttons)
        {
            go.SetActive(true);
        }
        Paused = true;
    }
    private void DesactivateButtons()
    {
        image.sprite = pause;
        image.color = Color.red;
        foreach (GameObject go in buttons)
        {
            go.SetActive(false);
        }
        Paused = false;
    }
}

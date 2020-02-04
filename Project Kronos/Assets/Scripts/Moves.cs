using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Moves : MonoBehaviour {

    public Image unit,ten;
    public Sprite[] numbers;
    public void ChangeMoves(int n)
    {
        ten.sprite = numbers[n / 10];
        unit.sprite = numbers[n % 10];
    }
}

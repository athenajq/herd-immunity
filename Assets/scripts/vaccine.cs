using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class vaccine : MonoBehaviour
{
    public static vaccine instance;
    public int richShots = 16;
    public int middleShots = 5;
    public int poorShots = 0;
    [SerializeField] TMP_Text richButton;
    [SerializeField] TMP_Text middleButton;
    [SerializeField] TMP_Text poorButton;

    private void Awake()
    {
        instance = this;
    }
    public void rich()
    {
        richShots--;
        richButton.text = richShots + " SHOTS";
    }

    public void middle()
    {
        middleShots--;
        middleButton.text = middleShots + " SHOTS";
    }

    public void poor()
    {
        poorShots--;
        poorButton.text = poorShots + " SHOTS";
    }
}

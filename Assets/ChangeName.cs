using UnityEngine;
using System.Collections;
using System;
public class ChangeName : MonoBehaviour
{
    public string oyuncuName;
    //Kendi methodlar!!!
    void OnMouseDown()
    {
        Debug.Log("Mouse clicked:Oyuncu " + oyuncuName);

    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("Game Started");
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log("Show FPS:" + DateTime.Now);
       // Debug.Log("Show FPS");
    }
}

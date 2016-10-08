using UnityEngine;
using System.Collections;
using System;
using WoLfulus.UI.Modal;

public class ChangeName : MonoBehaviour
{
    public string oyuncuName;
    public GameObject prefab;
    //Kendi methodlar!!!
    void OnMouseDown()
    {
        Debug.Log("Mouse clicked:Oyuncu " + oyuncuName + DateTime.Now + " giriyor.");

        ModalDialog.Create(prefab);

        //ModalDialog.Create(prefab).SetTextText("title", "Buy Item")
        //           .SetTextText("message", "Are you sure you want to buy 500 credits?");
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

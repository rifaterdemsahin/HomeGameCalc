﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/// <summary>
/// Modal namespace
/// </summary>
namespace WoLfulus.UI.Modal
{


    /// <summary>
    /// Modal result button
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ModalButton : MonoBehaviour
    {
        public GameObject closedBackGround;
        /// <summary>
        /// Current button result
        /// </summary>
        public ModalResult result = ModalResult.Cancel;

        /// <summary>
        /// Start
        /// </summary>
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(this.OnClick);
        }

        /// <summary>
        /// Destroy
        /// </summary>
        void Destroy()
        {
            this.GetComponent<Button>().onClick.RemoveListener(this.OnClick);
        }

        /// <summary>
        /// Click handler
        /// </summary>
        void OnClick()
        {
            this.GetComponentInParent<ModalDialog>().Dismiss(this.result);
            Debug.Log("Clicked and saved person name");
            closedBackGround.SetActive(true);
            var obj = GameObject.Find("oyuncu1");
            obj.GetComponent<Text>().text = "Kerem";
        }

    }
}
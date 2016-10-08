using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

/// <summary>
/// Modal namespace
/// </summary>
namespace WoLfulus.UI.Modal
{
    /// <summary>
    /// Configuration helpers
    /// </summary>
    public partial class ModalDialog
    {
        /// <summary>
        /// Sets control
        /// </summary>
        /// <param name="name">Control name</param>
        /// <param name="value">Text value</param>
        /// <returns></returns>
        public ModalDialog SetTextText(string name, string value)
        {
            return this.Control<Text>(name, (Text component) =>
            {
                component.text = value;
            });
        }

        /// <summary>
        /// Sets control
        /// </summary>
        /// <param name="name">Control name</param>
        /// <param name="value">Modal result</param>
        /// <returns></returns>
        public ModalDialog SetButtonModalResult(string name, ModalResult value)
        {
            return this.Control<ModalButton>(name, (ModalButton button) =>
            {
                button.result = value;
            }, true);
        }

        /// <summary>
        /// Sets control
        /// </summary>
        /// <param name="name">Control name</param>
        /// <param name="value">Text value</param>
        /// <returns></returns>
        public ModalDialog SetButtonText(string name, string value)
        {
            return this.Control(name, (GameObject button) =>
            {
                var text = button.GetComponentInChildren<Text>();
                if (text == null)
                {
                    Debug.LogError("Failed to find Text component in modal button", button);
                    return;
                }
                text.text = value;
            });
        }
    }
}

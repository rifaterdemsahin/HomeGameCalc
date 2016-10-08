using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Modal namespace
/// </summary>
namespace WoLfulus.UI.Modal
{
    /// <summary>
    /// Modal control setup
    /// </summary>
    [Serializable]
    public struct ModalControl
    {
        /// <summary>
        /// Control name
        /// </summary>
        public string name;

        /// <summary>
        /// Control reference
        /// </summary>
        public GameObject control;
    }
}
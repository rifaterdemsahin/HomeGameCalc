using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Modal namespace
/// </summary>
namespace WoLfulus.UI.Modal
{
    /// <summary>
    /// Modal dialog instance
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public partial class ModalDialog : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        [Tooltip("Forces the canvas to be sorted above any other canvases on the screen at the time the dialog is invoked.")]
        public bool forceModal = true;

        /// <summary>
        /// Controls
        /// </summary>
        [Tooltip("Control names are case insensitive!")]
        public ModalControl[] controls;

        /// <summary>
        /// Control map
        /// </summary>
        private Dictionary<string, GameObject> controlInstances = new Dictionary<string, GameObject>();

        /// <summary>
        /// Result callback
        /// </summary>
        private Func<ModalResult, bool> callback;

        /// <summary>
        /// Setup
        /// </summary>
        public void Awake()
        {
            for (int i = 0; i < this.controls.Length; i++)
            {
                try
                {
                    controlInstances.Add(this.controls[i].name.ToLower(), this.controls[i].control);
                }
                catch (Exception)
                {
                    Debug.LogError("Duplicated control name: " + this.controls[i].name);
                }
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            if (forceModal)
            {
                Canvas canvas = this.GetComponent<Canvas>();

                int sortingOrder = canvas.sortingOrder;

                Canvas[] canvases = GameObject.FindObjectsOfType<Canvas>();
                foreach (var c in canvases)
                {
                    if (c.GetInstanceID() == canvas.GetInstanceID())
                    {
                        continue;
                    }

                    if (c.sortingOrder > sortingOrder)
                    {
                        sortingOrder = c.sortingOrder;
                    }
                }

                canvas.sortingOrder = sortingOrder + 1;
            }
        }

        #region Control Management

        /// <summary>
        /// Gets an object from the dialog.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject GetControl(string name)
        {
            GameObject ret = null;
            if (!this.controlInstances.TryGetValue(name.ToLower(), out ret))
            {
                return null;
            }
            return ret;
        }

        /// <summary>
        /// Control configuration
        /// </summary>
        /// <param name="name"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public ModalDialog Control(string name, Action<GameObject> callback)
        {
            GameObject target = GetControl(name);
            if (target == null)
            {
                Debug.LogError("Failed to retrieve control named '" + name + "' in modal dialog", gameObject);
                return this;
            }

            callback(target);
            return this;
        }

        /// <summary>
        /// Control's component configuration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="add"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public ModalDialog Control<T>(string name, Action<T> callback)
            where T : MonoBehaviour
        {
            return Control<T>(name, callback, false);
        }

        /// <summary>
        /// Control's component configuration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public ModalDialog Control<T>(string name, Action<T> callback, bool add)
            where T : MonoBehaviour
        {
            GameObject target = GetControl(name);
            if (target == null)
            {
                Debug.LogError("Failed to retrieve control named '" + name + "' in modal dialog", gameObject);
                return this;
            }

            var component = target.GetComponent<T>();
            if (component == null)
            {
                if (!add)
                {
                    Debug.LogError("Failed to retrieve component '" + typeof(T).Name + "' in control '" + name + "'", gameObject);
                    return this;
                }
                else
                {
                    component = target.AddComponent<T>();
                }
            }

            callback(component);
            return this;
        }

        #endregion

        /// <summary>
        /// Close
        /// </summary>
        public void Dismiss()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// Close with result
        /// </summary>
        /// <param name="result"></param>
        public void Dismiss(ModalResult result)
        {
            if (this.callback != null)
            {
                if (!this.callback(result))
                {
                    return;
                }
            }
            Destroy(gameObject);
        }

        /// <summary>
        /// Creates a modal dialog from a prefab
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="forceModal"></param>
        /// <returns></returns>
        public static ModalDialog Create(GameObject prefab, bool forceModal = true)
        {
            var modal = Instantiate(prefab) as GameObject;
            var dialog = modal.GetComponent<ModalDialog>();
            dialog.forceModal = forceModal;
            return dialog;
        }

        #region Common Settings

        /// <summary>
        /// Set dialog's sort order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ModalDialog SetSortOrder(int order)
        {
            this.GetComponent<Canvas>().sortingOrder = order;
            return this;
        }

        /// <summary>
        /// Sets the result callback
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public ModalDialog Result(Func<ModalResult, bool> callback)
        {
            this.callback = callback;
            return this;
        }

        #endregion
    }
}
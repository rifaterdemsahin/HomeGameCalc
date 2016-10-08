using UnityEngine;
using WoLfulus.UI.Modal;

public class ShowDialogDefault : MonoBehaviour
{
    /// <summary>
    /// Prefab
    /// </summary>
    public GameObject dialog;

    public void Clicked()
    {
        ModalDialog
            .Create(this.dialog);
    }
}

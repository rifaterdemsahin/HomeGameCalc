using UnityEngine;
using WoLfulus.UI.Modal;

public class ShowDialogWithCustomText : MonoBehaviour
{
    /// <summary>
    /// Prefab
    /// </summary>
    public GameObject dialog;

    /// <summary>
    /// Button handler
    /// </summary>
    public void Clicked()
    {
        ModalDialog
            .Create(this.dialog)
            .SetTextText("text", "Hello, this is a custom <b>text</b>!");
    }
}

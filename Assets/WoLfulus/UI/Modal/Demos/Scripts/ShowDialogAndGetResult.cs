using UnityEngine;
using WoLfulus.UI.Modal;

public class ShowDialogAndGetResult : MonoBehaviour
{
    /// <summary>
    /// Prefab
    /// </summary>
    public GameObject message;
    public GameObject question;

    public void Clicked()
    {
        ModalDialog
            .Create(this.question)
            .SetTextText("text", "Do you really want to buy this item?")
            .Result((result) =>
            {
                ModalDialog.Create(this.message)
                    .SetTextText("text", "The answer to the question was: " + result);
                return true;
            });
    }
}

using UnityEngine;
using UnityEngine.UI;
using WoLfulus.UI.Modal;

public class ShowDialogAndRetrieveData : MonoBehaviour {

    /// <summary>
    /// Prefab
    /// </summary>
    public GameObject message;
    public GameObject question;

    public void Clicked()
    {

#if false

        // Method 1 (full implementation)

        var modal = ModalDialog.Create(this.question);
        modal.Result((result) =>
            {
                var name = modal.GetInputFieldText("name");
                if (name.Trim() == "")
                {
                    ModalDialog.Create(this.message)
                        .SetTextText("text", "Please, tell me your name!");
                    return false; // Cancel the dialog dismiss
                }

                modal.Control<InputField>("name", (input) =>
                {
                    ModalDialog.Create(this.message)
                        .SetTextText("text", "Hello, " + input.text);
                });
                return true;
            });

#else 

        // Method 2 (custom helper - extension)

        var modal = ModalDialog.Create(this.question);
        modal.Result((result) =>
        {
            var name = modal.GetInputFieldText("name");
            if (name.Trim() == "")
            {
                ModalDialog.Create(this.message)
                    .SetTextText("text", "Please, tell me your name!");
                return false; // Cancel the dialog dismiss
            }

            ModalDialog.Create(this.message)
                    .SetTextText("text", "Hello, " + modal.GetInputFieldText("name") + "!");
            return true;
        });

#endif
    }
}

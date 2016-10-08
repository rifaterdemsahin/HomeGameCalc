using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace WoLfulus.UI.Modal
{
    public static class InputFieldExtensions
    {
        public static string GetInputFieldText(this ModalDialog dialog, string control)
        {
            string value = "";
            dialog.Control<InputField>(control, (input) =>
            {
                value = input.text;
            });
            return value;
        }
    }
}

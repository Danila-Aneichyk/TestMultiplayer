using TMPro;
using UnityEngine;

namespace Shared
{
    public class BoundsForCreateButton : InputFieldBounds
    {
        [SerializeField] private TMP_InputField _nameField;

        private void Update()
        {
            CreateButtonInteractable();
        }

        private void CreateButtonInteractable()
        {
            if (_nameField.text.Length == 0)
            {
                Button.interactable = false;
            }
            else
            {
                Button.interactable = true;
            }
        }
    }
}
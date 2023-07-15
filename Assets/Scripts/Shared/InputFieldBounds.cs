using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shared
{
    public class InputFieldBounds : MonoBehaviour
    {
        [Header("Input field to set limits")]
        public TMP_InputField InputField;

        [Header("Characters limit in IF")]
        [SerializeField] private int _maxAmountOfCharacters;

        [Header("Buttons that interacts with IF")]
        public Button Button;

        private void Start()
        {
            InputField.characterLimit = _maxAmountOfCharacters;
        }

        private void Update()
        {
            SetButtonInteractable();
        }

        private void SetButtonInteractable()
        {
            if (InputField.text.Length == 0)
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
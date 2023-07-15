using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shared
{
    public class InputFieldBounds : MonoBehaviour
    {
        [Header("Input field to set limits")]
        [SerializeField] private TMP_InputField _inputField;

        [Header("Characters limit in IF")]
        [SerializeField] private int _maxAmountOfCharacters;

        [Header("Buttons that interacts with IF")]
        [SerializeField] private Button _button;

        private void Start()
        {
            _inputField.characterLimit = _maxAmountOfCharacters;
        }

        private void Update()
        {
            SetButtonInteractable();
        }

        private void SetButtonInteractable()
        {
            if (_inputField.text.Length == 0)
            {
                _button.interactable = false;
            }
            else
            {
                _button.interactable = true;
            }
        }
    }
}
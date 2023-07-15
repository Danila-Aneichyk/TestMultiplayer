using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SetNicknameScreen : MonoBehaviour
    {
        [Header("Button")]
        [SerializeField] private Button _setNicknameButton;

        [Header("Set nickname IF")]
        [SerializeField] private TMP_InputField _inputField;

        [Header("Logic component")]
        [SerializeField] private SetPlayerNickname _playerName;

        private void Start()
        {
            _setNicknameButton.onClick.AddListener(_playerName.SetName);
            _inputField.onValueChanged.AddListener(_playerName.NicknameChanged);
        }
    }
}
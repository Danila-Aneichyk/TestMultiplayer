using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Player
{
    public class SetPlayerNickname : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Button _setNicknameButton;

        public void NicknameChanged(string nickname)
        {
            if (nickname.Length > 0)
            {
                _setNicknameButton.interactable = true;
            }
        }

        public void SetName()
        {
            PhotonNetwork.NickName = _nameInputField.text;
        }
    }
}
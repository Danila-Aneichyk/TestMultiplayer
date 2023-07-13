using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CreateJoinScreen : MonoBehaviour
    {
        [Header("Logic script that buttons implement")]
        [SerializeField] private CreateAndJoinRooms _createJoin;

        [Header("Buttons")]
        [SerializeField] private Button _createButton;
        [SerializeField] private Button _joinButton;

        private void Awake()
        {
            _createButton.onClick.AddListener(_createJoin.CreateRooms);
            _joinButton.onClick.AddListener(_createJoin.JoinRoom);
        }
    }
}
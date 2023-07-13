using Photon.Pun;
using TMPro;
using UnityEngine;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _createInputField;
    [SerializeField] private TMP_InputField _joinInputField;

    public void CreateRooms()
    {
        PhotonNetwork.CreateRoom(_createInputField.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinInputField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
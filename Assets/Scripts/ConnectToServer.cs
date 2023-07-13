using Photon.Pun;
using UnityEngine;

public class ConnectToServer : MonoBehaviour
{
    private void Start()
    {
        Connect();
    }

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}

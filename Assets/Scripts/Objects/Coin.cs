using Definitions;
using Photon.Pun;
using UnityEngine;

namespace Objects
{
    public class Coin : MonoBehaviourPun
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Player))
            {
                Debug.Log("Collision detected");
                CoinsScreen.CoinsAmount++;
                GetComponent<PhotonView>().RPC("CoinCollected", RpcTarget.AllBuffered);
            }
        }

        [PunRPC]
        private void CoinCollected()
        {
            Destroy(gameObject);
        }
    }
}
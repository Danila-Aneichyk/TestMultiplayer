using Photon.Pun;
using Player;
using UnityEngine;

namespace PopUp_s
{
    public class FindAWinner : MonoBehaviour
    {
        private void Update()
        {
            CheckRemainingPlayers();
        }

        private void CheckRemainingPlayers()
        {
            
            Photon.Realtime.Player[] otherPlayers = PhotonNetwork.PlayerListOthers;

            
            foreach (Photon.Realtime.Player player in otherPlayers)
            {
                
                GameObject playerObject = player.TagObject as GameObject;

                if (playerObject != null)
                {
                   
                    PlayerDeath playerDeath = playerObject.GetComponent<PlayerDeath>();

                    
                    if (playerDeath != null)
                    {
                        if (playerDeath.IsDead == false)
                        {
                            
                        }
                    }
                }
            }
        }
    }
}
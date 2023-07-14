using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviourPun
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnRight;
        [SerializeField] private Transform _bulletSpawnLeft;
        [SerializeField] private PlayerMovement _playerMovement;

        public void Shoot()
        {
            if (_playerMovement.IsFacingRight)
            {
                GameObject bullet =
                    PhotonNetwork.Instantiate(_bulletPrefab.name, _bulletSpawnRight.position, Quaternion.identity);
            }
            else
            {
                GameObject bullet =
                    PhotonNetwork.Instantiate(_bulletPrefab.name, _bulletSpawnLeft.position, Quaternion.identity);
                bullet.GetComponent<PhotonView>().RPC("ChangeDirection", RpcTarget.AllBuffered);
            }
        }
    }
}
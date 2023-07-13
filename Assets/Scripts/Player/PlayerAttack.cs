using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviourPun
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawn;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Shoot()
        {
            GameObject bullet =
                PhotonNetwork.Instantiate(_bulletPrefab.name, _bulletSpawn.position, Quaternion.identity);
            if (_spriteRenderer.flipX)
            {
                bullet.GetComponent<PhotonView>().RPC("ChangeDirection", RpcTarget.AllBuffered);
            }
        }
    }
}
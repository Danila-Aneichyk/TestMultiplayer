using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviourPun
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 0.3f;
        [SerializeField] private int _damage = 3;
        private bool _isShootLeft = false;

        private void Start()
        {
            StartCoroutine("LifeTimeTimer");
        }

        private void Update()
        {
            Shoot();
        }

        IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);

            GetComponent<PhotonView>().RPC("EndOfLifeTime", RpcTarget.AllBuffered);
        }

        private void Shoot()
        {
            if (!_isShootLeft)
                transform.Translate(Vector2.right * Time.deltaTime * _speed);
            else
                transform.Translate(Vector2.left * Time.deltaTime * _speed);
        }

        [PunRPC]
        private void EndOfLifeTime()
        {
            Destroy(gameObject);
        }

        [PunRPC]
        private void ChangeDirection()
        {
            _isShootLeft = true;
        }
    }
}
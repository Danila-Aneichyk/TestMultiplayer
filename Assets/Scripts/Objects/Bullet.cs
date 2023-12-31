﻿using System.Collections;
using Definitions;
using Photon.Pun;
using Player;
using UnityEngine;

namespace Objects
{
    public class Bullet : MonoBehaviourPun
    {
        [Header("Bullet values")]
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 0.3f;
        [SerializeField] private int _damage = 3;
        private bool _isShootLeft = false;

        private void Start()
        {
            StartCoroutine(nameof(LifeTimeTimer));
        }

        private void Update()
        {
            Shoot();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(Tags.Player))
            {
                PlayerHp health = col.gameObject.GetComponent<PlayerHp>();
                health.ApplyDamage(_damage);
            }
        }

        IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);

            GetComponent<PhotonView>().RPC("EndOfLifeTime", RpcTarget.AllBuffered);
        }

        private void Shoot()
        {
            if (!_isShootLeft)
                transform.Translate(Vector2.right * (Time.deltaTime * _speed));
            else
                transform.Translate(Vector2.left * (Time.deltaTime * _speed));
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
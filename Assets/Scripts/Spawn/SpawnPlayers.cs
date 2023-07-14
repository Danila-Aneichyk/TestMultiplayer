using System;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class SpawnPlayers : MonoBehaviour
    {
        [Header("Player prefab")]
        [SerializeField] private GameObject _playerPrefab;

        [Header("Level bounds")]
        private float _minX = -7.72f;
        private float _maxX = 7.23f;
        private float _minY = -3.66f;
        private float _maxY = 3.98f;

        private void Awake()
        {
            Vector2 randomPosition = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            PhotonNetwork.Instantiate(_playerPrefab.name, randomPosition, Quaternion.identity);
        }
    }
}
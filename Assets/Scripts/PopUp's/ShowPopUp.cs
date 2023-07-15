using System;
using System.Collections;
using Player;
using UnityEngine;

namespace PopUp_s
{
    public class ShowPopUp : MonoBehaviour
    {
        [Header("Loose screen")]
        [SerializeField] private GameObject _looseScreen;

        private PlayerDeath _playerDeath;

        private float _popUpDuration = 3f;

        private void Awake()
        {
            _playerDeath = FindObjectOfType<PlayerDeath>();
        }

        private void Update()
        {
            if (_playerDeath.IsDead)
            {
                StartCoroutine(ShowPopUpScreen());
            }
        }

        private IEnumerator ShowPopUpScreen()
        {
            _looseScreen.SetActive(true);

            yield return new WaitForSeconds(_popUpDuration);

            _looseScreen.SetActive(false);
        }
    }
}
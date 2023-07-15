using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [Header("Player component to disable")]
        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;

        [Header("UI to shown")]
        [SerializeField] private GameObject _looseScreen;

        public bool IsDead { get; private set; }

        private void Start()
        {
            _playerHp.OnChanged += OnHpChanged;
        }

        private void OnHpChanged(int hp)
        {
            if (IsDead || hp > 0)
                return;

            IsDead = true;


            Debug.Log("Player is dead");
            _playerMovement.enabled = false;
            _playerAttack.enabled = false;
        }
    }
}
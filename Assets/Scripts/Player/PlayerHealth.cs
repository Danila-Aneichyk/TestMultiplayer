using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : MonoBehaviourPun
    {
        [SerializeField] private float _health = 100;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private float _minHealth = 100;
        [SerializeField] private float _startHealth = 100;
        [SerializeField] private Image _healthBar;

        [PunRPC]
        public void TakeDamage(float _damage)
        {
            _health -= _damage;
            _healthBar.fillAmount = _health / _startHealth;
            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.LogError("Player died");
        }
    }
}
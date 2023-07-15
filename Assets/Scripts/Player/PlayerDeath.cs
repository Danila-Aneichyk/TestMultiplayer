using Definitions;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [Header("Player component to disable")]
        [SerializeField] private PlayerHp _playerHp;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;

       // private Button _attackButton;

        public bool IsDead { get; private set; }

        private void Awake()
        {
            //_attackButton = GameObject.FindWithTag(Tags.AttackButton).GetComponent<Button>();
        }

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
//            _attackButton.enabled = false;
        }
    }
}
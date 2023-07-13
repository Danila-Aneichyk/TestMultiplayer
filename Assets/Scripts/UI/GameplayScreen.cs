using Player;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace UI
{
    public class GameplayScreen : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _shotButton;

        [Header("Components to implement")]
        [SerializeField] private PlayerAttack _playerAttack;

        private void Awake()
        {
            _playerAttack = FindObjectOfType<PlayerAttack>();
            _shotButton.onClick.AddListener(_playerAttack.Shoot);
        }
    }
}
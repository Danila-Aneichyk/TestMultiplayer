using Objects;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PopUpScreen : MonoBehaviour
    {
        [Header("Text to edit")]
        [SerializeField] private TextMeshProUGUI _coinsCounter;

        [Header("Component to off")]
        [SerializeField] private GameObject _collectedCoins;

        private void Start()
        {
            _collectedCoins.SetActive(false);
            _coinsCounter.text = $"You collected: {CoinsScreen.CoinsAmount}";
        }
    }
}
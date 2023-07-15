using TMPro;
using UnityEngine;

namespace Objects
{
    public class CoinsScreen : MonoBehaviour
    {
        [Header("Text on coin counter panel")]
        [SerializeField] private TextMeshProUGUI _coinCollectedText;

        public static int CoinsAmount;

        private void Update()
        {
            _coinCollectedText.text = CoinsAmount.ToString();
        }
    }
}
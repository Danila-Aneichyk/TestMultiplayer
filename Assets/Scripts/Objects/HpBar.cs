using UnityEngine;
using UnityEngine.UI;

namespace Objects
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;

        public void SetFill(float fillAmount) =>
            _fillImage.fillAmount = fillAmount;
    }
}
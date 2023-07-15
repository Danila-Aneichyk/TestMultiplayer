using Objects;
using Photon.Pun;
using UnityEngine;

namespace Shared
{
    public class CharacterUI : MonoBehaviourPun
    {
        [Header("HP bar UI")]
        [SerializeField] private HpBar _hpBar;
        private IHealth _health;

        [SerializeField] private PhotonView _hpBarPhotonView;
        private Canvas _worldSpaceCanvas;

        private void Awake()
        {
            _worldSpaceCanvas = gameObject.GetComponentInChildren<Canvas>();
            _worldSpaceCanvas.worldCamera = FindObjectOfType<Camera>();
        }

        private void Start()
        {
            Construct(GetComponent<IHealth>());
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.OnChanged -= HpChanged;
            }
        }

        private void Construct(IHealth health)
        {
            _health = health;

            if (_health != null)
            {
                _health.OnChanged += HpChanged;
                HpChanged(health.CurrentHp);
            }
        }

        private void HpChanged(int currentHp)
        {
            float fillAmount = (float) currentHp / _health.MaxHp;
            _hpBarPhotonView.RPC("SetFillHpBar", RpcTarget.AllBuffered, fillAmount);
        }

        [PunRPC]
        private void SetFillHpBar(float fillAmount)
        {
           _hpBar.SetFill(fillAmount);
        }
    }
}
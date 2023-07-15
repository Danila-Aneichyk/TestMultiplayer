using Objects;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Shared
{
    public class CharacterUI : MonoBehaviourPun
    {
        [Header("HP bar UI")]
        [SerializeField] private TextMeshProUGUI _nicknameText;
        [SerializeField] private HpBar _hpBar;
        private IHealth _health;

        private PhotonView _view;
        private Canvas _worldSpaceCanvas;

        private void Awake()
        {
            _worldSpaceCanvas = gameObject.GetComponentInChildren<Canvas>();
            _worldSpaceCanvas.worldCamera = FindObjectOfType<Camera>();
            _view = GetComponent<PhotonView>();
        }

        private void Start()
        {
            if (_view.IsMine)
            {
                _nicknameText.text = PhotonNetwork.NickName;
            }
            else
            {
                _nicknameText.text = _view.Owner.NickName;
            }

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
            _view.RPC("SetFillHpBar", RpcTarget.AllBuffered, fillAmount);
        }

        [PunRPC]
        private void SetFillHpBar(float fillAmount)
        {
            _hpBar.SetFill(fillAmount);
        }
    }
}
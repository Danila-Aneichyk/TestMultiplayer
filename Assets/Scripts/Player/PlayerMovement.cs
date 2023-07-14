using Definitions;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPun
{
    [Header("Directions")]
    private float _directionX;
    private float _directionY;

    [Header("Components for movement")]
    private Joystick _joystick;
    private Rigidbody2D _rb;
    [HideInInspector]
    public bool IsFacingRight = true;

    [Header("Movement values")]
    [SerializeField] private float _speed;

    [Header("Multiplayer gameplay")]
    private PhotonView _view;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _view = GetComponent<PhotonView>();
        _joystick = GameObject.FindGameObjectWithTag(Tags.Joystick).GetComponent<Joystick>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        CheckJoystickRotation();

        if (_view.IsMine)
        {
            _rb.velocity = new Vector2(_directionX, _directionY);
        }
    }

    private void Rotate()
    {
        float horizontalInput = _joystick.Horizontal;

        if (_view.IsMine)
        {
            if ((horizontalInput < 0 && IsFacingRight) || (horizontalInput > 0 && !IsFacingRight))
            {
                IsFacingRight = !IsFacingRight;
                _view.RPC("RotateCharacter", RpcTarget.AllBuffered, IsFacingRight);
            }
        }
    }

    private void CheckJoystickRotation()
    {
        _directionX = _joystick.Horizontal * _speed;
        _directionY = _joystick.Vertical * _speed;
    }

    [PunRPC]
    private void RotateCharacter(bool isFacingRight)
    {
        IsFacingRight = isFacingRight;
        transform.Rotate(0, 180f, 0);
    }
}
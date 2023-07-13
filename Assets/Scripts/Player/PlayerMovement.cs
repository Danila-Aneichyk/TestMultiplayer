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
    private bool _isFacingRight = true;

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

        if (!_view.IsMine)
            return;

        _rb.velocity = new Vector2(_directionX, _directionY);
    }

    private void Rotate()
    {
        float horizontalInput = _joystick.Horizontal;

        if (!_view.IsMine)
            return;

        if ((horizontalInput < 0 && _isFacingRight) || (horizontalInput > 0 && !_isFacingRight))
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void CheckJoystickRotation()
    {
        _directionX = _joystick.Horizontal * _speed;
        _directionY = _joystick.Vertical * _speed;
    }
}
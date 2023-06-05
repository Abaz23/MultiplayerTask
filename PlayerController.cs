using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private Joystick _joystick;
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    private bool _facingRight;
    public PhotonView _photonView;
    
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_photonView.IsMine)
        _joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }


    void Update()
    {
        if (_photonView.IsMine)
        {
            _moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            _moveVelocity = _moveInput.normalized * _speed;
        }

        if (_facingRight && _moveInput.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            FlipPlayer();
        }
        else if (!_facingRight && _moveInput.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            FlipPlayer();
        }
    }

    private void FlipPlayer()
    {
        _facingRight = !_facingRight;
    }
    
    private void FixedUpdate()
    {
        if (_photonView.IsMine)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _moveVelocity * Time.fixedDeltaTime);
        }
        
    }
}

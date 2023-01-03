using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _velocity;

    [SerializeField] private CharacterController _characterController;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _turnSmoothTime = 0.1f;


    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 Direction = transform.right * x + transform.forward * z;


        if (_characterController.isGrounded)
        {
            _velocity.y = -1f;

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    _velocity.y = _jumpForce;
            //}
        }
        else
        {
            _velocity.y -= _gravity * -2f * Time.deltaTime;
        }


        _characterController.Move(Direction * _speed * Time.deltaTime);
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}

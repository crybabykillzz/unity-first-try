using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 10.0f;
    private float _horizontalInput;
    private float _verticalInput;
    private CharacterController _controller;
    private Animator _animator;
    private Vector3 inputVector;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        Movement();
    }

    void Movement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");


        if (_controller.isGrounded)
        {
            inputVector = new Vector3(_horizontalInput, 0, _verticalInput);
            if (_horizontalInput != 0 || _verticalInput != 0)
            {
                _animator.SetInteger("idleRun", 1);
                _animator.SetInteger("idleJump", 0);
            }
            else
            {
                _animator.SetInteger("idleRun", 0);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _animator.SetInteger("idleJump", 1);
                    inputVector.y = 1f;
                }
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _animator.SetInteger("runJump", 1);
                inputVector.y = 0.7f;
            }
            else
            {
                _animator.SetInteger("runJump", 0);
            }

        }

        inputVector.y -= 0.5f * Time.deltaTime;
        _controller.Move(inputVector * Time.deltaTime * _speed);
        if (inputVector != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(new Vector3(inputVector.x, 0, inputVector.z));
    }


}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(1, 100)] 
        [SerializeField] private float _moveSpeed;
        [Range(1, 50)] 
        [SerializeField] private float _rotationTime = 1f;
        [SerializeField] private Transform _cameraHolder;
        [SerializeField] private Animator _animator;
        public Vector2 MoveInput { get => _moveInput; set => _moveInput = value; }
        public bool suspendMovement;
        private Vector2 _moveInput;
        private Vector2 _rotationInput;
        private Vector3 _moveDirection;
        private Rigidbody _rigidbody;
        private float _rotationVelocity;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rotationInput += _moveInput;
            _rotationInput.Normalize();

            float targetAngle = Mathf.Atan2(_rotationInput.x, _rotationInput.y) * Mathf.Rad2Deg + _cameraHolder.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _rotationVelocity,
                _rotationTime / 100);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            _moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _moveDirection.Normalize();
        }

        private void FixedUpdate()
        {
            if (IsMoving())
            {
                _rigidbody.velocity = _moveDirection * _moveSpeed;
            }
        }

        public bool IsMoving()
        {
            if (_moveInput == Vector2.zero || suspendMovement)
            {
                _animator.SetBool("isMoving", false);
                return false;
            }

            _animator.SetBool("isMoving", true);
            return true;
        }
    }
}
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform _cameraHolder;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationTime = 1f;
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashTime;
        public Vector2 MoveInput { get => _moveInput; set => _moveInput = value; }
        private PlayerAttack _playerAttack;
        private Rigidbody _rigidbody;
        private Vector2 _moveInput;
        private Vector2 _rotationInput;
        private Vector3 _moveDirection;
        private float _rotationVelocity;
        private bool _isDashing;
        private bool _suspendMovement;
        private bool _suspendRotation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerAttack = GetComponent<PlayerAttack>();
        }

        private void Update()
        {
            _rotationInput += _moveInput;
            _rotationInput.Normalize();

            float targetAngle = Mathf.Atan2(_rotationInput.x, _rotationInput.y) * Mathf.Rad2Deg + _cameraHolder.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _rotationVelocity, _rotationTime / 100);
            
            if (!_suspendRotation)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }

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

        public void Dash()
        {
            if (!_isDashing)
            {
                StartCoroutine(DashCoroutine());
            }
        }

        private IEnumerator DashCoroutine()
        {
            _isDashing = true;
            _playerAttack.EndCombo();
            _playerAttack.SuspendAttack();
            SuspendRotation();
            SuspendMovement();

            _rigidbody.velocity = _moveDirection * (_moveSpeed + _dashSpeed);
            
            yield return new WaitForSeconds(_dashTime);
            
            _isDashing = false;
            _playerAttack.RegainAttack();
            RegainRotation();
            RegainMovement();
        }

        public bool IsMoving()
        {
            if (_moveInput == Vector2.zero || _suspendMovement)
            {
                _animator.SetBool("isMoving", false);
                return false;
            }

            _animator.SetBool("isMoving", true);
            return true;
        }

        public void SuspendRotation()
        {
            _suspendRotation = true;
        }

        public void SuspendMovement()
        {
            _suspendMovement = true;
        }
        
        public void RegainRotation()
        {
            _suspendRotation = false;
        }

        public void RegainMovement()
        {
            _suspendMovement = false;
        }
    }
}
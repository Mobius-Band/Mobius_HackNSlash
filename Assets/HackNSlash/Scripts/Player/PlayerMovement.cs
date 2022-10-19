using System;
using System.Collections;
using Unity.VisualScripting;
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
        [HideInInspector] public bool suspendMovement;
        [HideInInspector] public bool suspendRotation;
        public Vector2 MoveInput { get => _moveInput; set => _moveInput = value; }
        private Rigidbody _rigidbody;
        private Vector2 _moveInput;
        private Vector2 _rotationInput;
        private Vector3 _moveDirection;
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
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _rotationVelocity, _rotationTime / 100);
            
            if (!suspendRotation)
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
            StartCoroutine(DashCoroutine());
        }

        private IEnumerator DashCoroutine()
        {
            SuspendRotation();
            SuspendMovement();

            _rigidbody.velocity = transform.forward * (_moveSpeed + _dashSpeed);
            yield return new WaitForSeconds(_dashTime);
            
            RegainRotation();
            RegainMovement();
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

        public void SuspendRotation()
        {
            suspendRotation = true;
        }

        private void SuspendMovement()
        {
            suspendMovement = true;
        }
        
        public void RegainRotation()
        {
            suspendRotation = false;
        }

        private void RegainMovement()
        {
            suspendMovement = false;
        }
    }
}
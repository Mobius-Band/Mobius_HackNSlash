using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(1, 100)] 
        [SerializeField] private float _moveSpeed;
        [Range(1, 50)] 
        [SerializeField] private float _rotationTime = 1f;
        // [SerializeField] private Transform _perspectiveCameraHolder;
        // [SerializeField] private Transform _isometricCameraHolder;
        [SerializeField] private Transform _cameraHolder;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _dashSpeed;
        [SerializeField] private float _dashTime;
        public Vector2 MoveInput { get => _moveInput; set => _moveInput = value; }
        private PlayerAttack _playerAttack;
        private Rigidbody _rigidbody;
        private Vector2 _moveInput;
        // private Vector2 _rotationInput;
        private Vector3 _moveDirection;
        private float _rotationVelocity;
        private bool _isDashing;
        private bool _isMovementSuspended;
        private bool _isRotationSuspended;
        private float _rotationAngle;
        private float movementAngle;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerAttack = GetComponent<PlayerAttack>();
        }

        private void Update()
        {
            if (_isMovementSuspended)
            {
                return;
            }
            DefineMovementAngle(out movementAngle, ref _moveDirection);

            if (_moveInput == Vector2.zero)
            {
                return;
            }
            if (_isMovementSuspended)
            {
                return;
            }
            LerpRotate(movementAngle);
        }

        private void FixedUpdate()
        {
            if (SetMovingAnimation())
            {
                _rigidbody.velocity = _moveDirection * _moveSpeed;
            }
        }
        
        private void LerpRotate(float movementAngle)
        {
            _rotationAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, movementAngle, ref _rotationVelocity,
                _rotationTime / 100);
            transform.rotation = Quaternion.Euler(0f, _rotationAngle, 0f);
        }

        private void DefineMovementAngle(out float movementAngle, ref Vector3 moveDirection)
        {
            movementAngle = Mathf.Atan2(_moveInput.x, _moveInput.y) * Mathf.Rad2Deg + _cameraHolder.eulerAngles.y;

            moveDirection = Quaternion.Euler(0f, movementAngle, 0f) * Vector3.forward;
            moveDirection.Normalize();
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

            transform.rotation = Quaternion.Euler(0f, movementAngle, 0f);
            var direction = transform.forward;
            _rigidbody.velocity = direction * (_moveSpeed + _dashSpeed);

            
            yield return new WaitForSeconds(_dashTime);
            
            _isDashing = false;
            _playerAttack.RegainAttack();
            RegainRotation();
            RegainMovement();
        }

        public bool SetMovingAnimation()
        {
            if (_moveInput == Vector2.zero || _isMovementSuspended)
            {
                _animator.SetBool("isMoving", false);
                return false;
            }

            _animator.SetBool("isMoving", true);
            return true;
        }

        public void SuspendRotation()
        {
            _isRotationSuspended = true;
        }

        public void SuspendMovement()
        {
            _isMovementSuspended = true;
        }
        
        public void RegainRotation()
        {
            _isRotationSuspended = false;
        }

        public void RegainMovement()
        {
            _isMovementSuspended = false;
        }
    }
}
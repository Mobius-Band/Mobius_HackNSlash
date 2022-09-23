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
        private Vector2 _moveInput;
        private float _rotationVelocity;
        private bool _canMove;
        private void Update()
        {
            if (_moveInput == Vector2.zero | !_canMove)
            {
                _animator.SetBool("isMoving", false);
                return;
            }
            
            _animator.SetBool("isMoving", true);
        
            float targetAngle = Mathf.Atan2(_moveInput.x, _moveInput.y) * Mathf.Rad2Deg + _cameraHolder.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _rotationVelocity, _rotationTime/100);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.position += moveDirection.normalized * _moveSpeed * Time.deltaTime;
        }

        public void SuspendMovement()
        {
            _canMove = false;
        }

        public void RegainMovement()
        {
            _canMove = true;
        }
    }
}
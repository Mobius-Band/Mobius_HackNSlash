using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(1, 100)] 
        [SerializeField] private float _moveSpeed;
        [Range(1, 50)] 
        [SerializeField] private float _rotationTime = 1f;
        [SerializeField] private Transform _cameraHolder;
        
        private float _rotationVelocity;
        private float _targetAngle;
        private Vector2 _moveInput;
        
        
        private Rigidbody _rb;
        
        public Vector2 MoveInput { get => _moveInput; set => _moveInput = value; }
        public Vector3 MoveDirection { get; private set; }

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            if (_moveInput == Vector2.zero)
                return;
            
            _targetAngle = Mathf.Atan2(_moveInput.x, _moveInput.y) * Mathf.Rad2Deg + _cameraHolder.eulerAngles.y;
            _targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _rotationVelocity, _rotationTime/100);
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
        
            MoveDirection = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            MoveDirection.Normalize();
            
        }

        private void FixedUpdate()
        {
            if (_moveInput == Vector2.zero)
                return;
            
            _rb.MovePosition(transform.position + MoveDirection * (_moveSpeed * Time.fixedDeltaTime));
        }
    }
}
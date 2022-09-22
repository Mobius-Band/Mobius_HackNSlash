using UnityEngine;
using UnityEngine.InputSystem;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [Range(0, 100)]
        [SerializeField] private float _sensitivity;
        [SerializeField] private Transform _cameraHolder;
        [SerializeField] private LayerMask _collisionMask;
        private Transform _camera;
        private Vector3 rayDirection;
        private Vector2 _input;
        private Vector2 _fixedInput;
        private float distance;

        public Vector2 Input { set => _input = value; }
        
        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _camera = _cameraHolder.GetChild(0);
        }

        private void LateUpdate()
        {
            _camera.transform.LookAt(_cameraHolder);
        
            _fixedInput += _input * _sensitivity * Time.deltaTime;
            _fixedInput.y = Mathf.Clamp(_fixedInput.y, -40, 20);
            
            _cameraHolder.rotation = Quaternion.Euler(_fixedInput.y, _fixedInput.x, 0);
            
            // collision
            /*
            rayDirection = (_camera.transform.position - transform.position).normalized;
            Ray ray = new Ray(_camera.transform.position, rayDirection);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 10f, out hit, 7.5f, _collisionMask))
            {
                print("hehehe");
                distance = Mathf.Clamp(hit.distance, -5.0f, 7.5f);
            }
            else
            {
                distance = 7.5f;
            }
            
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition.normalized * (distance - 0.5f), Time.deltaTime * 100);
            */
        }
    }
}
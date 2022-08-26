using UnityEngine;
using UnityEngine.InputSystem;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _cameraHolder;
        [Range(0, 100)]
        [SerializeField] private float _sensitivity;
        private Vector3 rayDirection;
        private Vector2 _input;
        private Vector2 _fixedInput;
        private Transform _camera;
        private float distance;

        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _camera = _cameraHolder.GetChild(0);
        }

        private void Update()
        {
            _camera.transform.LookAt(_cameraHolder);
        
            _fixedInput += _input * _sensitivity * Time.deltaTime;
            _cameraHolder.rotation = Quaternion.Euler(_fixedInput.y, _fixedInput.x, 0);
        }
    
        private void OnLook(InputValue value)
        {
            _input = value.Get<Vector2>();
        }
    }
}
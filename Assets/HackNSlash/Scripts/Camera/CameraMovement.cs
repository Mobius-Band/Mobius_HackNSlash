using System;
using UnityEngine;

namespace HackNSlash.Scripts.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        // [Range(0, 100)]
        // [SerializeField] private float _sensitivity;
        // [SerializeField] private CameraManager _cameraManager;
        // [SerializeField] private Transform _perspectiveCameraHolder;
        [SerializeField] private Transform _isometricCameraHolder;
        // [SerializeField] private LayerMask _collisionMask;
        [SerializeField] private float _speed;
        // public Vector3 _cameraInitialPosition;
        // private UnityEngine.Camera _camera;
        private Vector3 rayDirection;
        private Vector2 _input;
        private Vector2 _fixedInput;
        private float distance;

        // public Vector2 Input { set => _input = value; }
        
        // private void Awake()
        // {
        //     Cursor.visible = false;
        //     Cursor.lockState = CursorLockMode.Locked;
        // }

        private void LateUpdate()
        {
            IsometricCameraMovement();

            // if (_cameraManager.isCurrentCameraPerspective)
            // {
            //     PerspectiveCameraMovement();
            // }
            // else
            // {
                // IsometricCameraMovement();
            // }
        }

        // private void PerspectiveCameraMovement()
        // {
        //     _camera = _cameraManager.currentCamera;
        //     
        //     _camera.transform.LookAt(_perspectiveCameraHolder);
        //
        //     _fixedInput += _input * _sensitivity * Time.deltaTime;
        //     _fixedInput.y = Mathf.Clamp(_fixedInput.y, -40, 20);
        //     
        //     _perspectiveCameraHolder.rotation = Quaternion.Euler(_fixedInput.y, _fixedInput.x, 0);
        // }

        private void IsometricCameraMovement()
        {
            _isometricCameraHolder.transform.position = Vector3.Lerp(
                _isometricCameraHolder.transform.position,
                new Vector3(transform.position.x, _isometricCameraHolder.transform.position.y, transform.position.z),
                _speed * Time.deltaTime);
        }

        private void CameraCollision()
        {
            // collision
            /*
            rayDirection = (transform.position - _camera.transform.position).normalized;
            Ray ray = new Ray(_camera.transform.position, rayDirection);
            Debug.DrawLine(_camera.transform.position, ray.GetPoint(Vector3.Distance(_camera.transform.position, transform.position)), Color.magenta);
            if (Physics.Raycast(ray, out RaycastHit hit, 5))
            {
                print("hehehe");
                distance = Mathf.Clamp(hit.distance, -5.0f, 7.5f);
            }
            else
            {
                distance = 7.5f;
            }
            
            _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, _camera.transform.localPosition.normalized * (distance - 0.5f), Time.deltaTime * 100);
            */
        }
    }
}
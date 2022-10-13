using Player;
using UnityEngine;

namespace HackNSlash.Scripts.Camera
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera[] _cameras;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private CameraMovement _cameraMovement;
        public UnityEngine.Camera currentCamera => _cameras[_currentCameraIndex];
        public bool isCurrentCameraPerspective;
        private int _currentCameraIndex;

        private void Start()
        {
            _currentCameraIndex = 0;
        }

        private void Update()
        {
            if (_currentCameraIndex == 0)
            {
                isCurrentCameraPerspective = true;
            }
            else
            {
                isCurrentCameraPerspective = false;
            }
        }

        public void ChangeCamera()
        {
            // third person perspective camera should stay at index 0
            
            if (_currentCameraIndex < _cameras.Length - 1)
            {
                SetIsometricCamera();
            }
            else
            {
                SetPerspectiveCamera();
            }
        }

        private void SetIsometricCamera()
        {
            currentCamera.gameObject.SetActive(false);
            _currentCameraIndex += 1;
            currentCamera.gameObject.SetActive(true);
            _cameraMovement._cameraInitialPosition = currentCamera.transform.position;
        }
        
        private void SetPerspectiveCamera()
        {
            currentCamera.gameObject.SetActive(false);
            _currentCameraIndex = 0;
            currentCamera.gameObject.SetActive(true);
        }
    }
}

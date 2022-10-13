using HackNSlash.Scripts.Camera;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputManager))]
    [RequireComponent(typeof(PlayerAttack))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(CameraMovement))]
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationManager _playerAnimationManager;
        [SerializeField] private CameraManager _cameraManager;
        private PlayerInputManager _input;
        private PlayerAttack _attack;
        private PlayerMovement _movement;
        private CameraMovement _camera;
        
        void Awake()
        {
            _input = GetComponent<PlayerInputManager>();
            _attack = GetComponent<PlayerAttack>();
            _movement = GetComponent<PlayerMovement>();
            _camera = GetComponent<CameraMovement>();
        }
        
        void Start()
        {
            _input.InputActions.Player.Attack.performed += _ => _attack.Attack();
            _input.InputActions.Player.ChangeCamera.performed += _ => _cameraManager.ChangeCamera();
            _playerAnimationManager.OnAnimationEnd += _attack.EndAnimation;
            _playerAnimationManager.OnAnimationHit += _attack.Hit;
        }
        
        void Update()
        {
            _movement.MoveInput = _input.InputActions.Player.Move.ReadValue<Vector2>();
            _camera.Input = _input.InputActions.Player.Look.ReadValue<Vector2>();
        }
    }
}
using Combat;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputManager))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationManager _playerAnimationManager;
        [SerializeField] private bool _isPuzzlePlayer;
        private PlayerInputManager _input;
        private ComboManager _comboManager;
        private PlayerMovement _movement;
        
        void Awake()
        {
            _input = GetComponent<PlayerInputManager>();
            _comboManager = GetComponent<ComboManager>();
            _movement = GetComponent<PlayerMovement>();
        }
        
        void Start()
        {
            if (_isPuzzlePlayer)
            {
                // create interaction function
                _input.InputActions.PuzzlePlayer.Interact.performed += _ => _movement.Dash();
                return;
            }
            
            _input.InputActions.Player.Attack.performed += _ => _comboManager.HandleAttackInput();
            _input.InputActions.Player.Dash.performed += _ => _movement.Dash();

            if (_playerAnimationManager != null)
            {
                _playerAnimationManager.OnAnimationEndCombo += _comboManager.EndCombo;
                _playerAnimationManager.OnAnimationHit += _comboManager.ToggleHitbox;
                _playerAnimationManager.OnAnimationSuspendRotation += _movement.SuspendRotation;
                _playerAnimationManager.OnAnimationReturningToIdle += _comboManager.SetReturningToIdle;
            }
        }
        
        void Update()
        {
            if (_isPuzzlePlayer)
            {
                _movement.MoveInput = _input.InputActions.PuzzlePlayer.Move.ReadValue<Vector2>();
                return;
            }
            
            _movement.MoveInput = _input.InputActions.Player.Move.ReadValue<Vector2>();
        }
    }
}
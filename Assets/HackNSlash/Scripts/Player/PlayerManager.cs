using Combat;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputManager))]
    [RequireComponent(typeof(ComboManager))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationManager _playerAnimationManager;
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
            _input.InputActions.Player.Attack.performed += _ => _comboManager.HandleAttackInput();
            _input.InputActions.Player.Dash.performed += _ => _movement.Dash();

            _playerAnimationManager.OnAnimationEndCombo += _comboManager.EndCombo;
            _playerAnimationManager.OnAnimationHit += _comboManager.ToggleHitbox;
            _playerAnimationManager.OnAnimationSuspendRotation += _movement.SuspendRotation;
            _playerAnimationManager.OnAnimationReturningToIdle += _comboManager.SetReturningToIdle;
        }
        
        void Update()
        {
            _movement.MoveInput = _input.InputActions.Player.Move.ReadValue<Vector2>();
        }
    }
}
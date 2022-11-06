using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputManager))]
    [RequireComponent(typeof(PlayerAttack))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerAnimationManager _playerAnimationManager;
        private PlayerInputManager _input;
        private PlayerAttack _attack;
        private PlayerMovement _movement;
        
        void Awake()
        {
            _input = GetComponent<PlayerInputManager>();
            _attack = GetComponent<PlayerAttack>();
            _movement = GetComponent<PlayerMovement>();
        }
        
        void Start()
        {
            _input.InputActions.Player.Attack.performed += _ => _attack.Attack();
            _input.InputActions.Player.Dash.performed += _ => _movement.Dash();
            _playerAnimationManager.OnAnimationEnd += _attack.EndAnimation;
            _playerAnimationManager.OnAnimationHit += _attack.Hit;
            _playerAnimationManager.OnAnimationSuspendRotation += _movement.SuspendRotation;
        }
        
        void Update()
        {
            _movement.MoveInput = _input.InputActions.Player.Move.ReadValue<Vector2>();
        }
    }
}
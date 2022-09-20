using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputManager))]
    [RequireComponent(typeof(PlayerAttack))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerManager : MonoBehaviour
    {
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
        }
        
        void Update()
        {
            _movement.MoveInput = _input.InputActions.Player.Move.ReadValue<Vector2>();
        }
    }
}
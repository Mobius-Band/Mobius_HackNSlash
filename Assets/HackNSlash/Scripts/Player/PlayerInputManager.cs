using UnityEngine;

namespace Player
{
    public class PlayerInputManager : MonoBehaviour
    {
        public PlayerInputActions InputActions { get; private set; }
        private PlayerAttack _playerAttack;
        
        void Awake()
        {
            InputActions = new PlayerInputActions();
        }
        
        void OnEnable()
        {
            InputActions.Enable();
        }
        
        void OnDisable()
        {
            InputActions.Disable();
        }
        
        
    }
}
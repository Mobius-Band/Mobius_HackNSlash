using System;
using Player;
using UnityEngine;

namespace Combat
{
    public class ComboManager : MonoBehaviour
    {
        [SerializeField] private Combo[] combos;
        private AttackManager _attackManager;
        private PlayerMovement _playerMovement;
        private int _currentComboIndex;
        private int _currentAttackIndex;
        private bool _isReturningToIdle;
        
        public Attack CurrentComboAttack => combos[_currentComboIndex].comboAttacks[_currentAttackIndex];

        private void Start()
        {
            _attackManager = GetComponent<AttackManager>();
        }

        public void ComboAttack()
        {
            _playerMovement.SuspendMovement();

            if (_currentAttackIndex != 0)
            {
                _currentAttackIndex++;
            }
            
            _attackManager.Attack(_currentAttackIndex);
        }

        public void EndCombo()
        {
            _attackManager.StopAttack();
            _playerMovement.RegainMovement();
            _playerMovement.RegainRotation();
        }
    }
}
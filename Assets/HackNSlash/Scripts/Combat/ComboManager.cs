using System;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Combat
{
    public class ComboManager : AttackManager
    {
        private PlayerMovement _playerMovement;
        private bool isReturningToIdle;
        private bool _hasNextAttack;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        public void HandleAttackInput()
        {
            if (isReturningToIdle || currentAttackIndex == 0)
            {
                ComboAttack();
                
                if (!_hasNextAttack)
                {
                    SetNextAttack();
                }
            }
        }
        
        private void ComboAttack()
        {
            _playerMovement.SuspendMovement();
            _playerMovement.RegainRotation();
            Attack(currentAttackIndex);
            isReturningToIdle = false;
            _hasNextAttack = false;
        }
        
        public void SetNextAttack()
        {
            _hasNextAttack = true;
            if (currentAttackIndex < attacks.Length)
            {
                currentAttackIndex++;
            }
        }

        public void EndCombo()
        {
            isReturningToIdle = false;
            currentAttackIndex = 0;
            StopAttack();
            _playerMovement.RegainMovement();
            _playerMovement.RegainRotation();
        }

        public void SetReturningToIdle()
        {
            isReturningToIdle = true;
            _playerMovement.RegainRotation();
        }
    }
}
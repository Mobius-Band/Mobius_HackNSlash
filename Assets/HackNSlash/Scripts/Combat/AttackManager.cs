﻿using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Combat
{
    /// <summary>
    /// This script is responsible for managing a character`s attacks, using a reference to its hitbox and an array
    /// of serialized attacks
    /// </summary>
    public class AttackManager : MonoBehaviour
    {
        [Tooltip("A collection of attacks that can be used by this character.")]
        public Attack[] attacks; 
        [Tooltip("The hitbox that will be used to detect collisions with other objects - this should be a child of the character")]
        [SerializeField] private Hitbox hitbox;
        [Tooltip("An integer that represents the index of the current attack in the attacks array" +
                 "\n In editor: Click the three dots in the upper right corner of this component and " +
                 "press 'Set Current Attack' to visualize the current attack´s hitbox")]
        public int currentAttackIndex = 0;
        
        public Attack CurrentAttack => attacks[currentAttackIndex];

        [HideInInspector] public bool _isAttacking;
        public Animator animator;
        private bool _isAttackSuspended;

        [Tooltip("Apply current attack's position and size to the hitbox, for debugging. " +
                 "Use this to visualize the current attack's hitbox in the editor.")]
        [ContextMenu("Set Current Attack")]
        private void SetCurrentAttack()
        {
            if (hitbox.IsUnityNull())
            {
                hitbox = GetComponent<Hitbox>();
            }

            if (currentAttackIndex < attacks.Length - 1)
            {
                hitbox.SetValues(CurrentAttack);
            }
        }
        
        /// <summary>
        ///Automatically sets index and hitbox properties
        /// </summary>
        private void SetCurrentAttack(int index)
        {
            currentAttackIndex = index;
            SetCurrentAttack();
        }
        
        /// <summary>
        /// Called by an Animation Event to start the current attack 
        /// </summary>
        public void ToggleHitbox()
        {
            hitbox.TryHit();
        }
        
        /// <summary>
        ///  Set index for current attack and trigger it´s animation
        /// </summary>
        /// <param name="index"> Index of the attack in the attacks array</param>
        public void Attack(int index)
        {
            _isAttacking = true;
            animator.SetTrigger("goToNextAttackAnimation");
            SetCurrentAttack(index);
        }
        
        private void OnValidate()
        {
            SetCurrentAttack();
        }

        public void StopAttack()
        {
            _isAttacking = false;
        }

        public void SuspendAttack()
        {
            _isAttackSuspended = true;
        }

        public void RegainAttack()
        {
            _isAttackSuspended = false;
        }
    }
}
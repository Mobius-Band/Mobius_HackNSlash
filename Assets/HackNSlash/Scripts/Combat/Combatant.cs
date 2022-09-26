using System;
using UnityEngine;
using Util;

namespace Combat
{
    public class Combatant : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Hurtbox hurtbox;
        
        void Awake()
        {
            health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            hurtbox.OnHitReceived += health.TakeDamage;
        }
        
        private void OnDisable()
        {
            hurtbox.OnHitReceived -= health.TakeDamage;
        }
    }
}
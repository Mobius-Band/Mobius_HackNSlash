using System;
using UnityEngine;
using Util;

namespace Combat
{
    /// <summary>
    /// This class is responsible for connecting health and hurtbox for damage.
    /// </summary>
    public class HurtboxToHealthWorkflow : MonoBehaviour
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
using System;
using UnityEngine;
using Util;

namespace Combat
{
    /// <summary>
    /// This class is responsible for connecting health and hurtbox for damage.
    /// </summary>
    public class HurtboxWorkflow : MonoBehaviour
    {
        [SerializeField] private Hurtbox hurtbox;
        [SerializeField] private Health health;
        [SerializeField] private Knockback knockback;
            
        private void OnEnable()
        {
            if (health != null)
            {
                hurtbox.OnHitReceived += ctx => health.TakeDamage(ctx.Damage);
            }

            if (knockback != null)
            {
                hurtbox.OnHitReceived += ctx => knockback.ApplyKnockback(ctx.hitOriginTransform, ctx.Damage);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Util
{
    public class EnemyDamageable : MonoBehaviour, IDamageable
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public IEnumerable TakeDamage(int damage)
        {
            _health._currentHealth -= damage;
            StartCoroutine(GetComponent<EnemyTakeDamageEffect>().TakeDamageEffectCoroutine());
            StartCoroutine(GetComponent<Knockback>().ApplyKnockback(damage));
            yield break;
        }
    }
}

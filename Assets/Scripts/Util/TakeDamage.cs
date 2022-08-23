using System;
using Enemy;
using UnityEngine;

namespace Util
{
    public class TakeDamage : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void takeDamage(int damage)
        {
            _health._currentHealth -= damage;
            //print(gameObject.name + " hp: " + _health._currentHealth);
            StartCoroutine(GetComponent<EnemyTakeDamageEffect>().TakeDamageEffectCoroutine());
            StartCoroutine(GetComponent<Knockback>().ApplyKnockback(damage));
        }
    }
}

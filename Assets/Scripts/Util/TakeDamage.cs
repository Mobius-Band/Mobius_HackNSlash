using System;
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
            print("hp: " + _health._currentHealth);
            //GetComponent<Knockback>().ApplyKnockback(damage);
        }
    }
}

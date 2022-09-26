using System;
using UnityEngine;

namespace Util
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        private int _currentHealth;
        private const int MinHealth = 0;

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (value <= MinHealth)
                {
                    _currentHealth = MinHealth;
                    Die();
                }
                else if (value > maxHealth)
                {
                    _currentHealth = maxHealth;
                }
                else
                {
                    _currentHealth = value;
                }
            }
        }
        
        void Start()
        {
            _currentHealth = maxHealth;
        }
        
        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}

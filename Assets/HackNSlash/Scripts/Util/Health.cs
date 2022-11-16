using System;
using UnityEngine;

namespace Util
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int _currentHealth;
        private const int MinHealth = 0;
        
        public Action<int, int> OnHealthChanged;
        public Action OnDeath;

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
                OnHealthChanged?.Invoke(_currentHealth, maxHealth);
            }
        }

        void Start()
        {
            _currentHealth = maxHealth;
        }

        public void GainHealth(int amount)
        {
            CurrentHealth += amount;
        }
        
        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
        }

        protected abstract void Die();
    }
}

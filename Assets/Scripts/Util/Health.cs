using System;
using UnityEngine;

namespace Util
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        public int _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        private void Update()
        {
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

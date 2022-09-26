using System;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace HackNSlash.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Health health;
        private Slider _slider;
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            health.OnHealthChanged += UpdateHealthBar;
        }
        
        private void OnDisable()
        {
            health.OnHealthChanged -= UpdateHealthBar;
        }
        
        private void UpdateHealthBar(int currentHealth, int maxHealth)
        {
            _slider.value = (float) currentHealth / maxHealth;
        }
    }
}
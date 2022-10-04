using HackNSlash.Scripts.Util;
using UnityEngine;
using Util;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemyHealth : Health
    {
        [SerializeField] private Health _playerHealth;
        
        protected override void Die()
        {
            Score.scoreInstance.AddAmount(10);
            EnemyWaveManager.waveManagerInstance._enemiesLeft -= 1;
            _playerHealth.GainHealth(10);
            Destroy(gameObject);
        }
    }
}
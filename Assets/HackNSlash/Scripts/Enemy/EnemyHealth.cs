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
            //TODO: Should be handled solely by score or a bridging class
            Score.scoreInstance.AddAmount(10);
            //TODO: Should be handled solely by EnemyWaveManager or a bridging class
            EnemyWaveManager.waveManagerInstance._enemiesLeft -= 1;
            //TODO: Shouldn't need a ref to player health, as
            _playerHealth.GainHealth(10);
            Destroy(gameObject);
        }
    }
}
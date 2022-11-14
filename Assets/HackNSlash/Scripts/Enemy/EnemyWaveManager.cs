using System;
using HackNSlash.Scripts.GameManagement;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemyWaveManager : MonoBehaviour
    {
        [SerializeField] private EnemySpawner[] _enemySpawners;
        [SerializeField] private Transform _enemyParent;
        [SerializeField] private int _maximumWave;
        [SerializeField] private TextMeshProUGUI _waveText;
        [SerializeField] private Transform playerTransform;
        private int _enemiesLeft;
        private int _currentWave = 0;

        private void Awake()
        {
            SetSpawningCount();
        }

        private void Update()
        {
             _waveText.text = $"wave: {_currentWave}/{_maximumWave}";
            
            if (_enemiesLeft <= 0)
            {
                _currentWave += 1;

                if (_currentWave > _maximumWave)
                {
                    //TODO: Make it an event
                    GameManager.Instance.LoadVictoryScene();
                }
                
                StartWave(_currentWave);
            }
        }
        
        public void StartWave(int waveIndex)
        {
            for (int i = 0; i < waveIndex; i++)
            {
                var enemy = _enemySpawners[i].SpawnEnemy(_enemyParent);
                enemy.GetComponent<EnemyHealth>().OnDeath += EnemyDied;
                enemy.GetComponent<EnemyBehaviour>().target = playerTransform;
            }
        }
        
        private void EnemyDied()
        {
            _enemiesLeft--;
        }
        
        private void EnemySpawned()
        {
            _enemiesLeft++;
        }

        private void SetSpawningCount()
        {
            Array.ForEach(_enemySpawners, ctx => ctx.OnEnemySpawned += EnemySpawned);
        }
    }
}

using System;
using Unity.Mathematics;
using UnityEngine;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        
        public Action OnEnemySpawned;

        public GameObject SpawnEnemy(Transform enemyParent)
        {
            var newEnemy = Instantiate(_enemyPrefab, transform.position, quaternion.identity, enemyParent);
            newEnemy.SetActive(true);
            OnEnemySpawned?.Invoke();
            return newEnemy;
        }
    }
}

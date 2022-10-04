using Unity.Mathematics;
using UnityEngine;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemy;

        public void SpawnEnemy()
        {
            var newEnemy = Instantiate(_enemy, transform.position, quaternion.identity);
            newEnemy.SetActive(true);
            EnemyWaveManager.waveManagerInstance._enemiesLeft += 1;


        }
    }
}

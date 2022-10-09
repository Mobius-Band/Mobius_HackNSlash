using Unity.Mathematics;
using UnityEngine;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemy;

        public void SpawnEnemy()
        {
            //TODO: Make all new enemies children of the same parent
            var newEnemy = Instantiate(_enemy, transform.position, quaternion.identity);
            newEnemy.SetActive(true);
            //TODO: How can you guarantee there is a EnemyWaveManager instance in a scene?
            EnemyWaveManager.waveManagerInstance._enemiesLeft += 1;


        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using Util;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private float _attackRange = 0.5f;
        [SerializeField] private int _damage = 5;

        private void OnAttack()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<TakeDamage>().takeDamage(_damage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (_attackPoint == null)
                return;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        }
    }
}
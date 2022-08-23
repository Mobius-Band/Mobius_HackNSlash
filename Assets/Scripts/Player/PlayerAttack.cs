using System;
using System.Collections;
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
        [SerializeField] private float[] _comboDelay;
        private bool _isAttacking = false;
        private bool _isComboing = false;

        private void OnAttack()
        {
            if (!_isComboing)
            {
                StartCoroutine(Combo());
            }

            _isAttacking = true;
        }

        private IEnumerator Combo()
        {
            _isComboing = true;
            
            print("1");
            BasicAttack();

            yield return new WaitForSeconds(_comboDelay[0]);

            if (!_isAttacking)
            {
                _isComboing = false;
                yield break;
            }
            
            print("2");
            BasicAttack();
            
            yield return new WaitForSeconds(_comboDelay[1]);
            
            if (!_isAttacking)
            {
                _isComboing = false;
                yield break;
            }
            
            print("3");
            SpecialAttack();

            yield return new WaitForSeconds(_comboDelay[2]);
            
            _isComboing = false;
        }

        private void BasicAttack()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<TakeDamage>().takeDamage(_damage);
            }

            _isAttacking = false;
        }

        private void SpecialAttack()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, _attackRange + 1.5f, _enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<TakeDamage>().takeDamage(_damage * 2);
            }
            
            _isAttacking = false;
        }

        private void OnDrawGizmosSelected()
        {
            if (_attackPoint == null)
                return;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        }
    }
}
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
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private float _attackRange = 0.5f;
        [SerializeField] private int _damage = 5;
        [SerializeField] private float[] _comboDelay;
        private Color _originalColor;
        private bool _isAttacking = false;
        private bool _isComboing = false;

        private void Start()
        {
            _originalColor = _meshRenderer.material.color;
        }

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
                _meshRenderer.material.color = _originalColor;
                yield break;
            }
            
            print("2");
            BasicAttack();
            
            yield return new WaitForSeconds(_comboDelay[1]);
            
            if (!_isAttacking)
            {
                _isComboing = false;
                _meshRenderer.material.color = _originalColor;
                yield break;
            }
            
            print("3");
            SpecialAttack();

            yield return new WaitForSeconds(_comboDelay[2]);

            _meshRenderer.material.color = _originalColor;
            _isComboing = false;
        }

        private void BasicAttack()
        {
            _meshRenderer.material.color = Color.yellow;
            
            Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<TakeDamage>().takeDamage(_damage);
            }

            _isAttacking = false;
        }

        private void SpecialAttack()
        {
            _meshRenderer.material.color = Color.green;
            
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
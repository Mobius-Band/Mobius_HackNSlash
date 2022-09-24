using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _chasePeriod = 1f;
    [SerializeField] private float _attackEnablingAngle = 30f;

    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private bool _canAttack = false;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(CheckForTarget());
    }

    private void Update()
    {
        _canAttack = Vector3.SqrMagnitude(_player.position - transform.position) <=
                      Mathf.Pow(_navMeshAgent.stoppingDistance, 2); 
        _animator.SetBool("CanAttack", _canAttack);
        
    }

    private IEnumerator CheckForTarget()
    {
        while (true)
        {
            _navMeshAgent.SetDestination(_player.position);
            yield return new WaitForSeconds(_chasePeriod);
        }
    }
}

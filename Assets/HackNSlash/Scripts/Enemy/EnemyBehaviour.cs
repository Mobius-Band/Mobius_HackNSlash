using System;
using System.Collections;
using Combat;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AttackManager))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _chasePeriod = 1f;
    [SerializeField] private float _attackEnablingAngle = 30f;

    private NavMeshAgent _navMeshAgent;
    private AttackManager _attackManager;
    
    private bool _canAttack = false;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _attackManager = GetComponent<AttackManager>();
    }

    void Start()
    {
        StartCoroutine(CheckForTarget());
    }

    private void Update()
    {
        _canAttack = Vector3.SqrMagnitude(_player.position - transform.position) <=
                      Mathf.Pow(_navMeshAgent.stoppingDistance, 2);
        if (_canAttack)
        {
            _attackManager.Attack(0);
        }
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

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _chasePeriod = 1f;

    private NavMeshAgent _navMeshAgent;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private IEnumerable CheckForTarget()
    {
        while (true)
        {
            _navMeshAgent.SetDestination(_player.position);
            yield return new WaitForSeconds(_chasePeriod);
        }
    }
}

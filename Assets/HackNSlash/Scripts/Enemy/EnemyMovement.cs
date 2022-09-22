using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _chasePeriod = 1f;

    private NavMeshAgent _navMeshAgent;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        StartCoroutine(CheckForTarget());
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

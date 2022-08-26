using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 5f;
    
    private void Update()
    {
        transform.LookAt(_player);
        transform.position += transform.forward * (_speed * Time.deltaTime);
    }
}

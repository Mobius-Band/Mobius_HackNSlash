using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _speed = 5f;
    
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z), 
            _speed * Time.deltaTime
            );
    }
}

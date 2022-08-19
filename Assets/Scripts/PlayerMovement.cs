using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 100)] 
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _model;
    [SerializeField] private Transform _cameraHolder;
    [SerializeField] private float _rotationSpeed;
    private Vector2 _moveInput;

    private void Update()
    {
        if (_moveInput == Vector2.zero)
        {
            return;
        }
        
        transform.position += new Vector3(_moveInput.x * _moveSpeed/100 * Time.deltaTime, 0, _moveInput.y * _moveSpeed/100 * Time.deltaTime);
        
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(_moveInput.x, 0, _moveInput.y), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(_model.rotation, lookRotation, _rotationSpeed);
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
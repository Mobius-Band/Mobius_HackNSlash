using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 100)] 
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _model;
    [SerializeField] private float _rotationSpeed;
    private Vector2 _moveInput;

    private void FixedUpdate()
    {
        transform.position += new Vector3(_moveInput.x * _moveSpeed/100, 0, _moveInput.y * _moveSpeed/100);
        
        /*
        transform.rotation = Quaternion.Lerp(transform.rotation, _cameraHolder.rotation, 5.0f * Time.deltaTime);
        if (_moveInput == Vector2.zero) return;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(_moveInput.x, 0, _moveInput.y), Vector3.up);
        _model.rotation = Quaternion.RotateTowards(_model.rotation, lookRotation, _rotationSpeed);
        */
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
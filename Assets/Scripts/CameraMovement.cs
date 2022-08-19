using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraHolder;
    [Range(0, 100)]
    [SerializeField] private float Sensitivity;
    private Vector3 rayDirection;
    private Vector2 _input;
    private Vector2 _fixedInput;
    private Transform _camera;
    private float distance;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _camera = _cameraHolder.GetChild(0);
    }

    private void Update()
    {
        _fixedInput.x = _input.x * Sensitivity * Time.deltaTime;
        _fixedInput.y = _input.y * Sensitivity * Time.deltaTime;

        if (_input == Vector2.zero)
        {
            return;
        }
        
        transform.LookAt(_cameraHolder);
        _cameraHolder.rotation = Quaternion.Euler(-_input.y, _input.x, 0);
    }
    
    private void OnLook(InputValue value)
    {
        _input += value.Get<Vector2>();
    }
}
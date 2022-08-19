using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraHolder;
    [Range(0, 100)]
    [SerializeField] private float _sensitivity;
    private Transform _camera;
    private Vector2 _input;
    private PlayerInput _playerInput;
    private const float _threshold = 0.01f;
    private bool IsCurrentDeviceMouse
    {
        get
        {
            return _playerInput.currentControlScheme == "Keyboard&Mouse";
        }
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _camera = _cameraHolder.GetChild(0);
    }

    private void LateUpdate()
    {
        /*
        _camera.LookAt(_cameraHolder);
        float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;
        var treatedInput = _input * _sensitivity * deltaTimeMultiplier;
        _cameraHolder.rotation = Quaternion.Euler(-treatedInput.y, treatedInput.x, 0);
        */
        CameraRotation();
    }

    private void OnLook(InputValue value)
    {
        _input += value.Get<Vector2>();
    }
    
    private void CameraRotation()
    {
        _camera.LookAt(_cameraHolder);
        
        if (_input.sqrMagnitude >= _threshold)
        {
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;
            var treatedInput = _input * _sensitivity * deltaTimeMultiplier;
            
            _cameraHolder.rotation = Quaternion.Euler(-treatedInput.y, treatedInput.x, 0);
        }
    }
}

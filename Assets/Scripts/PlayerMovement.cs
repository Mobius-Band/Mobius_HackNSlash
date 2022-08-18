using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Range(1, 100)] 
    [SerializeField] private float moveSpeed;
    private Vector2 moveInput;

    private void FixedUpdate()
    {
        transform.position += new Vector3(moveInput.x * moveSpeed/100, 0, moveInput.y * moveSpeed/100);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}

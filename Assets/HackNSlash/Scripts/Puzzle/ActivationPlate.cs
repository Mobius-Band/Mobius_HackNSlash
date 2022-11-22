using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPlate : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    public bool isActivated;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isActivated = true;
            StartCoroutine(DeactivationTimer());
        }

        if (other.gameObject.CompareTag("Movable"))
        {
            isActivated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Movable"))
        {
            isActivated = false;
        }
    }

    private IEnumerator DeactivationTimer()
    {
        yield return new WaitForSeconds(timer);
        isActivated = false;
    }
}

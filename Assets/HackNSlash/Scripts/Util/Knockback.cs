using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Util
{
    public class Knockback : MonoBehaviour
    {
        [SerializeField] private float _knockbackForce = 50;
        
        public void ApplyKnockback(Transform hitObject, int amount)
        {
            transform.GetComponent<Rigidbody>().AddForce(hitObject.forward * amount * _knockbackForce, ForceMode.Acceleration);
        }
    }
}

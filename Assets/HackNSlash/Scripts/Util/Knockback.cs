using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Util
{
    public class Knockback : MonoBehaviour
    {
        [SerializeField] private Transform _knocker;
        [SerializeField] private float _knockbackForce = 50;
        public IEnumerator ApplyKnockback(int amount)
        {
            GetComponent<Rigidbody>().AddForce(_knocker.forward * amount * _knockbackForce, ForceMode.Acceleration);
            yield break;
        }
    }
}

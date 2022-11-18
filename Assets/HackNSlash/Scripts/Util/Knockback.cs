using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Util
{
    public class Knockback : MonoBehaviour
    {
        [SerializeField] private float _knockbackForce = 50;
        
        public IEnumerator ApplyKnockback(Transform hitObject, int amount)
        {
            hitObject.GetComponent<Rigidbody>().AddForce(transform.forward * amount * _knockbackForce, ForceMode.Acceleration);
            yield break;
        }
    }
}

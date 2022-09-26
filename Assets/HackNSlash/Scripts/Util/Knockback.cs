using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Util
{
    public class Knockback : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _knockbackForce = 50;
        public IEnumerator ApplyKnockback(int amount)
        {
            GetComponent<Rigidbody>().AddForce(_player.forward * amount * _knockbackForce, ForceMode.Acceleration);
            yield break;
        }
    }
}

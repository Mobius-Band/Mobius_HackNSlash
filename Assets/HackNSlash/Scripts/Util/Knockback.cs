using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Util
{
    public class Knockback : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        public IEnumerator ApplyKnockback(int amount)
        {
            GetComponent<Rigidbody>().AddForce(_player.forward * amount * 75, ForceMode.Acceleration);
            yield break;
        }
    }
}

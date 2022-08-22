using UnityEngine;
using UnityEngine.InputSystem;

namespace Util
{
    public class Knockback : MonoBehaviour
    {
        public void ApplyKnockback(int amount)
        {
            transform.position = Vector3.Lerp(transform.position, -transform.forward * amount, 0.5f);
        }
    }
}

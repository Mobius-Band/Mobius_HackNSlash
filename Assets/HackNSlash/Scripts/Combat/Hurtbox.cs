using System.Collections;
using UnityEngine;

namespace Combat
{
    public class Hurtbox : MonoBehaviour, IHitResponder
    {
        public event IHitResponder.HitReceived OnHitReceived;

        public IEnumerable HitRespond(int damage)
        { 
            OnHitReceived?.Invoke(damage);
            yield break;
        }
    }
}
using System.Collections;
using Enemy;
using Ez;
using UnityEngine;
using Util;

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
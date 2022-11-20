using System.Collections;
using UnityEngine;

namespace Combat
{

    public class Hurtbox : MonoBehaviour, IHitResponder
    {
        public event IHitResponder.HitReceived OnHitReceived;

        public IEnumerable HitRespond(HitEventArgs hitEventArgs)
        { 
            OnHitReceived?.Invoke(hitEventArgs);
            yield break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Util
{
    public interface IDamageable : IEventSystemHandler
    {
        public IEnumerable TakeDamage(int damage);
    }
}
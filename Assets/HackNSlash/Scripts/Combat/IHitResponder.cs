using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Combat
{
    public interface IHitResponder : IEventSystemHandler
    {
        public delegate void HitReceived(int damage = 0);
        public event HitReceived OnHitReceived;
        public IEnumerable HitRespond(int damage = 0);
    }
}
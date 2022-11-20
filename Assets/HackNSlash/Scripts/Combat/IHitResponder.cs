using System.Collections;
using UnityEngine.EventSystems;

namespace Combat
{
    public interface IHitResponder : IEventSystemHandler
    {
        public delegate void HitReceived(HitEventArgs e);
        public IEnumerable HitRespond(HitEventArgs e);
    }

}
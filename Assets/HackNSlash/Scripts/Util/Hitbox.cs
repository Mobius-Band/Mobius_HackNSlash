using System;
using UnityEngine;

namespace Util
{
    public enum ColliderState
    {
        Inactive,
        Active,
        Hit
    }
    
    public class Hitbox : MonoBehaviour
    {
        public LayerMask mask;
        public Vector3 position;
        public Vector3 hitboxSize = Vector3.one;
        [Header("Debugging Colors")]
        public Color inactiveColor = Color.gray;
        public Color activeColor = Color.blue;
        public Color hitColor = Color.red;
        
        private ColliderState _state = ColliderState.Inactive;
        private Collider[] _hitColliders;

        private Color StateColor =>
            _state switch
            {
                ColliderState.Inactive => inactiveColor,
                ColliderState.Active => activeColor,
                ColliderState.Hit => hitColor,
                _ => Color.white
            };

        void Update()
        {
            if (_state == ColliderState.Inactive)
            {
                return;
            }
            
            Physics.OverlapBoxNonAlloc(position, hitboxSize/2, _hitColliders, Quaternion.identity, mask);
            
            if (_hitColliders.Length > 0)
            {
                _state = ColliderState.Hit;
            }
            else
            {
                _state = ColliderState.Active;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = StateColor;
            Gizmos.DrawWireCube(position, hitboxSize);
        }
    }
}
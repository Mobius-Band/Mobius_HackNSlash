using System;
using Ez;
using Ez.Msg.Demos;
using Unity.VisualScripting;
using UnityEngine;

namespace Combat
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
        [HideInInspector] public int damage;
        [Header("Debugging Colors")]
        public Color inactiveColor = Color.gray;
        public Color activeColor = Color.blue;
        public Color hitColor = Color.red;
        
        private ColliderState _state = ColliderState.Inactive;
        private Collider[] _hitColliders = {};
        
        private Vector3 position => transform.position;

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
            TryHitUpdate();
        }

        private void TryHitUpdate()
        {
            Physics.OverlapBoxNonAlloc(transform.position, transform.localScale/2, _hitColliders, transform.localRotation, mask);
            if (_hitColliders.Length > 0)
            {
                _state = ColliderState.Hit;
                //TODO Put damage response here
            }
            else
            {
                _state = ColliderState.Active;
            }
        }
        
        public void TryHit()
        {
            // int results = Physics.OverlapBoxNonAlloc(
                // transform.position, transform.localScale/2,  _hitColliders, transform.localRotation, mask);

            _hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.localRotation,
                mask);
            
            if (_hitColliders.Length <= 0) 
                return;
            
            foreach (var hitCollider in _hitColliders)
            {
                hitCollider.gameObject.Send<IHitResponder>(_=>_.HitRespond(damage));
            }
        }
        
        public void SetValues(Attack attack)
        {
            SetValues(attack.hitboxPosition, attack.hitboxSize, attack.damage);
        }
        
        public void SetValues(Vector3 localPosition, Vector3 dimensions, int damage)
        {
            transform.localPosition = localPosition;
            transform.localScale = dimensions;
            this.damage = damage;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = StateColor;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, transform.localScale);
        }
    }
}
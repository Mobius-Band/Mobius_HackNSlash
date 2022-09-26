using Unity.VisualScripting;
using UnityEngine;

namespace Combat
{
    public class AttackManager : MonoBehaviour
    {
        [SerializeField] Attack[] attacks;
        [SerializeField] private Hitbox hitbox;
        [SerializeField] private int currentAttackIndex = 0;
        
        private Animator _animator;
        
        public Attack CurrentAttack => attacks[currentAttackIndex];

        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        [ContextMenu("Set Current Attack")]
        private void SetCurrentAttack()
        {
            if (hitbox.IsUnityNull())
            {
                hitbox = GetComponent<Hitbox>();
            }
            hitbox.SetValues(CurrentAttack);
        }
        
        private void SetCurrentAttack(int index)
        {
            currentAttackIndex = index;
            SetCurrentAttack();
        }
        
        //TODO ToggleHitbox with boolean to activate and deactivate hitbox
        public void ToggleHitbox()
        {
            hitbox.TryHit();
        }
        
        public void Attack(int index)
        {
            SetCurrentAttack(index);
            _animator.SetTrigger(CurrentAttack.animationName);
        }
        
        
        //TODO change to a more performant method
        private void OnDrawGizmosSelected()
        {
            SetCurrentAttack();
        }
    }
}
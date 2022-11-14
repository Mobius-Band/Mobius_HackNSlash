using HackNSlash.Scripts.Util;
using UnityEngine;
using Util;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemyHealth : Health
    {
        protected override void Die()
        {
            //TODO: Should be handled solely by score or a bridging class
            // Score.scoreInstance.AddAmount(10);
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
using HackNSlash.Scripts.Util;
using Util;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemyHealth : Health
    {
        protected override void Die()
        {
            Score.scoreInstance.AddAmount(10);
            Destroy(gameObject);
        }
    }
}
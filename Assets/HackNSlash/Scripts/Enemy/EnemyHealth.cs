using Util;

namespace HackNSlash.Scripts.Enemy
{
    public class EnemyHealth : Health
    {
        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}
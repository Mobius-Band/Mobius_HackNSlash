using UnityEngine.SceneManagement;
using Util;

namespace HackNSlash.Scripts.Player
{
    public class PlayerHealth : Health
    {
        protected override void Die()
        {
            // game over scene
            SceneManager.LoadScene(2);
        }
    }
}
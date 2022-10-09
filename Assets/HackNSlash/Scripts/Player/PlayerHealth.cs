using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace HackNSlash.Scripts.Player
{
    public class PlayerHealth : Health
    {
        //TODO: Use sceneReference
        [SerializeField] private SceneReference gameOverSceneReference;
        protected override void Die()
        {
            //TODO: Create a scene transition manager
            // game over scene
            SceneManager.LoadScene(2);
        }
    }
}
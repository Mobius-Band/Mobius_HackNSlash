using Eflatun.SceneReference;
using HackNSlash.Scripts.GameManagement;
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
            GameManager.Instance.LoadGameOverScene();
        }
    }
}
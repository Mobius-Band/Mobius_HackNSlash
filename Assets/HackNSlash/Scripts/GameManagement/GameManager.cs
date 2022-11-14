using UnityEngine;
using UnityEngine.SceneManagement;

namespace HackNSlash.Scripts.GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int victorySceneIndex = 3;

        public void LoadVictoryScene()
        {
            SceneManager.LoadScene(victorySceneIndex);
        }
    }
}
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Utilities;

namespace HackNSlash.Scripts.GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        [FormerlySerializedAs("mainScene")] [SerializeField] private SceneReference combatScene0;
        [SerializeField] private SceneReference victorySceneIndex;

        public void LoadVictoryScene()
        {
            SceneManager.LoadScene(victorySceneIndex.BuildIndex);
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(combatScene0.BuildIndex);
        }
        
        public void PauseGame()
        {
            Time.timeScale= 0;
        }
    
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void Quit()
        {
            AppHelper.Quit();
        }
    }
}
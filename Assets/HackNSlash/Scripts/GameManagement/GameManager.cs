using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Utilities;

namespace HackNSlash.Scripts.GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private SceneReference _mainMenuScene;
        [FormerlySerializedAs("mainScene")] [SerializeField] private SceneReference combatScene0;
        [SerializeField] private SceneReference victorySceneReference;

        public bool isBooting = true;
        
        public void LoadVictoryScene()
        {
            SceneManager.LoadScene(victorySceneReference.BuildIndex);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(_mainMenuScene.Name);
        }
        
        public void LoadFirstCombatScene()
        {
            SceneManager.LoadScene(combatScene0.BuildIndex);
        }

        public void ReloadGame()
        {
            isBooting = true;
            SceneManager.LoadScene(_mainMenuScene.BuildIndex);
        }
        
        public void PauseGame()
        {
            Time.timeScale= 0;
            SetMousePointerForGameplay(false);
        }
    
        public void ResumeGame()
        {
            Time.timeScale = 1;
            SetMousePointerForGameplay(true);
        }

        public void Quit()
        {
            AppHelper.Quit();
        }

        public void SetMousePointerForGameplay(bool doIt)
        {
            Cursor.visible = !doIt;
            Cursor.lockState = !doIt ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
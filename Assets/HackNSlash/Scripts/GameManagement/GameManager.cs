using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Utilities;

namespace HackNSlash.Scripts.GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private int _mainMenuSceneIndex;
        [FormerlySerializedAs("mainScene")] [SerializeField] private int combatScene0Index;
        [SerializeField] private int victorySceneReferenceIndex;
        [FormerlySerializedAs("defeatSceneReference")] [SerializeField] private int gameOverSceneReferenceIndex;

        public bool isBooting = true;
        public bool isPaused = false;
        
        public void LoadVictoryScene()
        {
            SceneManager.LoadScene(victorySceneReferenceIndex);
        }

        public void LoadGameOverScene()
        {
            SceneManager.LoadScene(gameOverSceneReferenceIndex);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(_mainMenuSceneIndex);
        }
        
        public void LoadFirstCombatScene()
        {
            SceneManager.LoadScene(combatScene0Index);
        }

        public void ReloadGame()
        {
            isBooting = true;
            SceneManager.LoadScene(_mainMenuSceneIndex);
        }
        
        public void PauseGame()
        {
            Time.timeScale= 0;
            isPaused = true;
            SetMousePointerForGameplay(false);
        }
    
        public void ResumeGame()
        {
            Time.timeScale = 1;
            isPaused = false;
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
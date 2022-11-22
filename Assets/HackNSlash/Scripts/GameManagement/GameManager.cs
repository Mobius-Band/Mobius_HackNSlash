using UnityEngine;
using UnityEngine.SceneManagement;

namespace HackNSlash.Scripts.GameManagement
{
    public class GameManager : Singleton<GameManager>
    {
        private int menuSceneIndex = 0;
        private int combatSceneIndex = 1;
        private int puzzleSceneIndex = 2;
        private int gameOverSceneIndex = 3;
        private int victorySceneIndex = 4;

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(menuSceneIndex);
        }
        
        public void LoadCombatScene()
        {
            SceneManager.LoadScene(combatSceneIndex);
        }
        
        public void LoadPuzzleScene()
        {
            SceneManager.LoadScene(puzzleSceneIndex);
        }
        
        public void LoadGameOverScene()
        {
            SceneManager.LoadScene(victorySceneIndex);
        }
        
        public void LoadVictoryScene()
        {
            SceneManager.LoadScene(victorySceneIndex);
        }
    }
}
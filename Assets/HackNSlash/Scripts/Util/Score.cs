using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HackNSlash.Scripts.Util
{
    public class Score : MonoBehaviour
    {
        public static Score scoreInstance;
            
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _amount;

        private void Awake()
        {
            scoreInstance = this;
        }

        public void AddAmount(int amount)
        {
            _amount += amount;
            _scoreText.text = "score: " + _amount;
        }
    }
}
using HackNSlash.Scripts.GameManagement;
using TMPro;
using UnityEngine;

namespace HackNSlash.Scripts.Stats
{
    public class ResultScreenManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthValueText;
        [SerializeField] private TMP_Text _rankText;

        void Start()
        {
            float health = PlayerStatsManager.Instance.GetHealthPercentage();
            _healthValueText.text = health.ToString("0") + "%";
            _rankText.text = Ranker.CalculateRank(health).ToString();
        }
    }
}
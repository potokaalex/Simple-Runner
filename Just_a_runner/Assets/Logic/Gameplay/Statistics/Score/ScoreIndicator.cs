using UnityEngine;
using Zenject;
using TMPro;

namespace Statistics
{
    public class ScoreIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _indicator;

        [Inject]
        private void Constructor(StatisticsData data)
            => data.CharacterScore.OnScoreChanging += UpdateScore;

        public void Show()
            => _indicator.gameObject.SetActive(true);

        public void Hide()
            => _indicator.gameObject.SetActive(false);

        public void ClearScore()
            => _indicator.text = "";

        private void UpdateScore(uint score)
            => _indicator.text = score.ToString();
    }
}
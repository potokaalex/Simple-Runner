using UnityEngine;
using Zenject;
using TMPro;

namespace Statistics
{
    public class ScoreIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _indicator;

        [Inject]
        private void Constructor(CharacterScore score)
            => score.OnScoreChanging += UpdateScore;

        public void Show()
            => _indicator.gameObject.SetActive(true);

        public void Hide()
            => _indicator.gameObject.SetActive(false);

        private void UpdateScore(uint score)
            => _indicator.text = score.ToString();
    }
}
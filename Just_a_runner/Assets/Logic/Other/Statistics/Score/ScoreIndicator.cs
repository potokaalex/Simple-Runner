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

        private void UpdateScore(uint score)
            => _indicator.text = score.ToString();
    }
}
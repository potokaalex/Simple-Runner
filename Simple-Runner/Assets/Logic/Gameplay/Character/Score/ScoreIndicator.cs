using Infrastructure;
using UnityEngine;
using Zenject;
using TMPro;

namespace Character
{
    public class ScoreIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _indicator;

        [Inject]
        private void Constructor(DataProvider data)
            => data.CharacterData.Score.OnScoreChanging += UpdateScore;

        private void UpdateScore(uint score)
            => _indicator.text = score <= 0 ? "" : score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PedometerUI : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private List<TextMeshProUGUI> scores;

    public void UpdateScoreText()
    {
        foreach (var score in scores)
            score.text = character.GetScore().ToString();
    }

}

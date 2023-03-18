using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zenject;
using Ecs;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Infrastructure;

public class DefeatMenu : MonoBehaviour //mediator
{
    //[SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _maxScore;
    //[SerializeField] private Image _replay;
    //[SerializeField] private Image _home;
    //[SerializeField] private Image _share;
    [SerializeField] private GameObject Window;

    private GlobalStateMachine _stateMachine;

    [Inject]
    private void Construcor(GlobalStateMachine stateMachine)
        => _stateMachine = stateMachine;

    public void SetCurrentScore(uint score)
        => _currentScore.text = score.ToString();

    public void SetMaxScore(uint score)
        => _maxScore.text = score.ToString();

    public void Open()
    {
        Window.SetActive(true);
    }

    public void Close()
    {
        Window.SetActive(false);
    }

    public void Restart()
    {
        _stateMachine.SwitchTo<LevelLoadingState>();
    }

    public void Menu()
    {
        _stateMachine.SwitchTo<MainMenuState>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Restart();
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zenject;
using Ecs;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Infrastructure.StateMachine;

public class DefeatMenu : MonoBehaviour //mediator
{
    //[SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _score;
    //[SerializeField] private Image _replay;
    //[SerializeField] private Image _home;
    //[SerializeField] private Image _share;
    [SerializeField] private GameObject Window;

    private GlobalStateMachine _stateMachine;

    [Inject]
    private void Construcor(GlobalStateMachine stateMachine)
        => _stateMachine = stateMachine;

    public void SetScore(int value)
    {
        _score.SetText("Score: " + value.ToString());
    }

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
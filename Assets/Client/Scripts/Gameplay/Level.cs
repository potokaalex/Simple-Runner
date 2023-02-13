using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

//нужен компонент 
public class Level : MonoBehaviour, IAloneInScene
{
    [SerializeField] private DefeatMenu _defeatMenu;

    public bool IsPaused { get; private set; }

    public void Defeat()
    {
        Pause(true);

        _defeatMenu.Active(true);
    }

    public void Pause(bool isPaused)
    {
        Time.timeScale = isPaused == true ? 0f : 1f;

        IsPaused = isPaused;
    }
}

public interface IDontDestroyedOnLoad
{ }
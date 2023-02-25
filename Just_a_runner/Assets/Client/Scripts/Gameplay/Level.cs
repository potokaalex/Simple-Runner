using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;
using System.Threading.Tasks;

/*
public class LevelProgress : MonoBehaviour, IAloneInScene
{
    [SerializeField] private DefeatMenu _defeatMenu;

    public bool IsPaused { get; private set; }

    public async void Defeat()
    {
        Pause(true);

        //ожидание пользовательского ввода ?

        Debug.Log("UserInput delay");

        await D();

        _defeatMenu.Active(true);
    }

    public async Task D()
    {
        await Task.Delay(5000);
    }

    //public

    public void Pause(bool isPaused)
    {
        Time.timeScale = isPaused == true ? 0f : 1f;

        IsPaused = isPaused;
    }
}

public interface IDontDestroyedOnLoad
{ }

public interface IPausing
{ }
*/
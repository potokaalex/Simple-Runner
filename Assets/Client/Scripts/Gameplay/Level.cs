using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

public class Level : MonoBehaviour, IAloneInScene
{
    [SerializeField] private DefeatMenu _defeatMenu;


    public bool IsPaused { get; private set; }


    public void Defeat()
    {
        //при поражении игра отправляется на "паузу".

        //тоесть: происходит time-scale = 0, вызывается меню поражения.

        Pause(true);
    }

    public void Pause(bool isPaused)
    {
        Time.timeScale = isPaused == true ? 0f : 1f;

        IsPaused = isPaused;
    }
}

public class DefeatMenu // медиатор 
{


}
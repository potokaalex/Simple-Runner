using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private Menu menu;

    public void Pause(bool isPause) => Time.timeScale = isPause ? 0 : 1;

    public void Exit() => Application.Quit();

    public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void GameOver()
    {
        Time.timeScale = 0;

        menu.PauseUIActive(false);
        menu.GameOverUIActive(true);
        menu.BackgroundUIActive(true);
    }
}
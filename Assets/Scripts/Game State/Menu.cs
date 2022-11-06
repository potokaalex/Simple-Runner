using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject pause;

    public void GameOverUIActive(bool isActive)
        => gameOver.SetActive(isActive);

    public void PauseUIActive(bool isActive)
        => pause.SetActive(isActive);

    public void BackgroundUIActive(bool isActive)
        => background.SetActive(isActive);

}
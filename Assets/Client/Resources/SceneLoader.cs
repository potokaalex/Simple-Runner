using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private void Constructor()
    {

    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
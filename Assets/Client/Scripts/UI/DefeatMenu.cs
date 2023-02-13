using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecs;
using UnityEngine;
using Singleton;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Image _replay;
    [SerializeField] private Image _home;
    [SerializeField] private Image _share;

    public void Active(bool isActive)
    {
        _background.enabled = isActive;
        _score.enabled = isActive;
        _replay.enabled = isActive;
        _home.enabled = isActive;
        _share.enabled = isActive;
    }

    public void Replay() //перезагрузка сцены
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Singleton<Level>.Instance.Pause(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Replay();
    }
}
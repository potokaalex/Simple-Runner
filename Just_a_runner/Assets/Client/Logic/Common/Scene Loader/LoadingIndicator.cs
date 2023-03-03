using System.Collections;
using UnityEngine;
using Zenject;

public class LoadingIndicator : MonoBehaviour
{
    [SerializeField] private RectTransform _indicator;
    [SerializeField] [Tooltip("Angle per second")] private float _velocity;

    private ISceneLoader _sceneLoader;
    private int _loadingCount;
    private bool _isAnimationStarted;

    [Inject]
    private void Construcor(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;

        _sceneLoader.OnLoadingStart += StartAnimation;
        _sceneLoader.OnLoadingEnd += StopAnimation;
    }

    private void OnDisable()
    {
        _sceneLoader.OnLoadingStart -= StartAnimation;
        _sceneLoader.OnLoadingEnd -= StopAnimation;
    }

    private void StartAnimation(AsyncOperation loadingOperation)
    {
        _loadingCount++;

        if (!_isAnimationStarted)
            StartCoroutine(Animation());
    }

    private void StopAnimation(AsyncOperation loadingOperation)
    {
        _loadingCount--;

        if (_loadingCount > 0)
            return;

        StopAllCoroutines();
        _isAnimationStarted = false;
        _indicator.gameObject.SetActive(false);
    }

    private IEnumerator Animation()
    {
        var deltaTime = Time.fixedDeltaTime;

        _isAnimationStarted = true;
        _indicator.gameObject.SetActive(true);

        while (_loadingCount > 0)
        {
            _indicator.Rotate(Vector3.back, _velocity * deltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
}
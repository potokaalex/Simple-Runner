using System.Collections;
using UnityEngine;
using Zenject;

public class LoadingIndicator : MonoBehaviour
{
    [SerializeField] private RectTransform _indicator;
    [SerializeField][Tooltip("Angle per second")] private float _velocity;

    private SceneLoader _sceneLoader;

    [Inject]
    private void Construcor(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;

        _sceneLoader.OnLoadingStart += StartAnimation;
        _sceneLoader.OnLoadingEnd += StopAnimation;
    }

    private void StartAnimation() 
        => StartCoroutine(Animation());

    private void StopAnimation()
    {
        _indicator.gameObject.SetActive(false);

        StopAllCoroutines();
    }

    private IEnumerator Animation()
    {
        var deltaTime = Time.fixedDeltaTime;

        _indicator.gameObject.SetActive(true);

        while (true)
        {
            _indicator.Rotate(Vector3.back, _velocity * deltaTime);

            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDestroy()
    {
        _sceneLoader.OnLoadingStart -= StartAnimation;
        _sceneLoader.OnLoadingEnd -= StopAnimation;
    }
}

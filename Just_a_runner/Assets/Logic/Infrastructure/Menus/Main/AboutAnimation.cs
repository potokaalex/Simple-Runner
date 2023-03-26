using System.Collections;
using UnityEngine;
using System;

namespace Infrastructure.Menus
{
    public class AboutAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _mainMenuWindow;
        [SerializeField] private RectTransform _aboutWindow;
        [SerializeField] private Vector2 _windowDistance;
        [SerializeField] private float _animationTime;

        private Vector2 _menuStartPosition;
        private bool isAboutWindowOpen;

        private void Awake()
            => _menuStartPosition = _mainMenuWindow.anchoredPosition;

        public void AnimationToggle()
        {
            if (isAboutWindowOpen)
            {
                StopAllCoroutines();
                StartCoroutine(ClosingAnimation());
            }
            else
                StartCoroutine(OpeningAnimation());

            isAboutWindowOpen = !isAboutWindowOpen;
        }

        public IEnumerator OpeningAnimation()
        {
            var mainMenuFinalPosition = _windowDistance / -2;
            var aboutMenuFinalPosition = _windowDistance / 2;

            yield return Move(_mainMenuWindow, mainMenuFinalPosition, _animationTime);

            _aboutWindow.anchoredPosition = aboutMenuFinalPosition;
            _aboutWindow.gameObject.SetActive(true);
        }

        public IEnumerator ClosingAnimation()
        {
            _aboutWindow.gameObject.SetActive(false);

            yield return Move(_mainMenuWindow, _menuStartPosition, _animationTime);
        }

        private IEnumerator Move(RectTransform window, Vector2 position, float drivingTime)
        {
            if (drivingTime < 0)
                throw new ArgumentException("The value of the argument must not be less than 0 !");

            var deltaTime = Time.deltaTime;
            var displacement = position - window.anchoredPosition;
            var speed = displacement / drivingTime;

            for (var time = deltaTime; time < drivingTime - deltaTime; time += deltaTime)
            {
                var step = speed * deltaTime;
                window.anchoredPosition += step;

                yield return null;
            }

            window.anchoredPosition = position;
        }
    }
}

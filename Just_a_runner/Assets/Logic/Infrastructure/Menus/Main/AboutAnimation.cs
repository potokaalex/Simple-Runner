using System.Collections;
using UnityEngine;
using System;

namespace Infrastructure.Menus
{
    public class AboutAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _mainMenuWindow;
        [SerializeField] private GameObject _aboutWindow;
        [SerializeField] private Vector2 _menuStartPosition;
        [SerializeField] private Vector2 _menuFinalPosition;
        [SerializeField] private float _animationTime;

        private bool isAboutWindowOpen;

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
            yield return RigidMove(_mainMenuWindow, _menuFinalPosition, _animationTime);

            _aboutWindow.SetActive(true);
        }

        public IEnumerator ClosingAnimation()
        {
            _aboutWindow.SetActive(false);

            yield return RigidMove(_mainMenuWindow, _menuStartPosition, _animationTime);
        }

        private IEnumerator RigidMove(RectTransform window, Vector2 position, float drivingTime)
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

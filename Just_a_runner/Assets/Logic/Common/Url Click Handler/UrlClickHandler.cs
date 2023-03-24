using UnityEngine.EventSystems;
using UnityEngine;

namespace TMPro
{
    public class UrlClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Canvas _textCanvas;
        [SerializeField] private Camera _camera;

        public void OnPointerClick(PointerEventData eventData)
        {
            var mousePosition = new Vector3(eventData.position.x, eventData.position.y, 0);
            var linksCount =
                TMP_TextUtilities.FindIntersectingLink(_text, mousePosition, _camera);

            if (linksCount < 0)
                return;

            var linkInfo = _text.textInfo.linkInfo[linksCount];
            var url = linkInfo.GetLinkID();

            if (url.StartsWith("http://") ||
                url.StartsWith("https://") ||
                url.StartsWith("www"))
                Application.OpenURL(url);
        }
    }
}
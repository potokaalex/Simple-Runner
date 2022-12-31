using UnityEngine;

namespace CustomInspectorGraph.Renderer
{
    public class AxisLines
    {
        private Vector3[] lines;
        private Rect rectangle;

        public Vector3[] GetAxisLines(Rect rectangle)
        {
            if (this.rectangle == rectangle)
                return lines;

            this.rectangle = rectangle;

            var endPositionForY = rectangle.position + Vector2.up * rectangle.height;
            var endPositionForX = endPositionForY + Vector2.right * rectangle.width;

            return lines = new Vector3[]
            {
                rectangle.position, endPositionForY,
                endPositionForY,endPositionForX
            };
        }
    }
}

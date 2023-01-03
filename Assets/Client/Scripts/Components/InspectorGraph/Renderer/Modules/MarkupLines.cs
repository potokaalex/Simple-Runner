using UnityEngine;
using System.Linq;
using System;

namespace CustomInspectorGraph.Renderer
{
    public class MarkupLines
    {
        private Vector3[] lines;
        private Rect position;
        private Vector2 divisionValue;
        private int divisionsOfX;
        private int divisionsOfY;

        public Vector3[] GetMarkupLines(Rect position, int divisionsOfX, int divisionsOfY, Vector2 divisionValue)
        {
            if (this.position == position &&
                this.divisionsOfX == divisionsOfX &&
                this.divisionsOfY == divisionsOfY &&
                this.divisionValue == divisionValue)
                return lines;

            if (divisionsOfX < 0 || divisionsOfY < 0)
                return Array.Empty<Vector3>();

            this.position = position;
            this.divisionsOfX = divisionsOfX;
            this.divisionsOfY = divisionsOfY;
            this.divisionValue = divisionValue;

            var displacementForY = Vector2.right * position.width;
            var stepForY = Vector2.down * divisionValue.y;

            var displacementForX = Vector2.down * position.height;
            var stepForX = Vector2.right * divisionValue.x;

            lines = Markup(divisionsOfY, stepForY, displacementForY).Concat(Markup(divisionsOfX, stepForX, displacementForX)).ToArray();

            return lines;

            Vector3[] Markup(int divisionsNumber, Vector2 step, Vector2 displacement)
            {
                var _lines = new Vector3[divisionsNumber * 2];
                var _currentLineIndex = 0;

                for (var _currentDivision = 1; _currentDivision <= divisionsNumber; _currentDivision++, _currentLineIndex += 2)
                {
                    var _startingPosition = position.position + Vector2.up * position.height + step * _currentDivision;
                    var _endPosition = _startingPosition + displacement;

                    _lines[_currentLineIndex] = _startingPosition;
                    _lines[_currentLineIndex + 1] = _endPosition;
                }
                return _lines;
            }
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using System;

namespace CustomInspectorGraph.Renderer
{
    public class MarkupNumbers
    {
        private (Vector3, string)[] numbers;
        private Rect position;
        private Vector2 divisionValue;
        private int divisionsOfX;
        private int divisionsOfY;

        public (Vector3, string)[] GetMarkupNumbers(Rect position, int divisionsOfX, int divisionsOfY, Vector2 divisionValue)
        {
            if (this.position == position &&
                this.divisionsOfX == divisionsOfX &&
                this.divisionsOfY == divisionsOfY &&
                this.divisionValue == divisionValue)
                return numbers;

            if (divisionsOfX < 0 || divisionsOfY < 0)
                return Array.Empty<(Vector3, string)>();

            this.position = position;
            this.divisionsOfX = divisionsOfX;
            this.divisionsOfY = divisionsOfY;
            this.divisionValue = divisionValue;

            var _numbers = new List<(Vector3, string)>(divisionsOfX + divisionsOfY + 1);

            var _initialOffset = new Vector2(-18f, 5f);

            var _markupStepForY = new Vector2(0f, -divisionValue.y);
            var _markupOffsetForY = new Vector2(_initialOffset.x, 0f);

            var _markupStepForX = new Vector2(divisionValue.x, 0f);
            var _markupOffsetForX = new Vector2(0f, _initialOffset.y);

            Markup(divisionsOfY, _markupStepForY, _markupOffsetForY);
            _numbers.Add((position.position + new Vector2(0f, position.height) + _initialOffset / 2f, "0"));
            Markup(divisionsOfX, _markupStepForX, _markupOffsetForX);

            return numbers = _numbers.ToArray();

            void Markup(int divisionsNumber, Vector2 step, Vector2 offset)
            {
                for (var _currentDivision = 1f; _currentDivision <= divisionsNumber; _currentDivision++)
                {
                    var _numberPosition = position.position + new Vector2(0f, position.height) + offset + step * _currentDivision;

                    _numbers.Add((_numberPosition, _currentDivision.ToString()));
                }
            }
        }
    }
}

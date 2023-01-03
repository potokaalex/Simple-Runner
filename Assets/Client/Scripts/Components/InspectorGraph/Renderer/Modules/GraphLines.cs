using System.Collections.Generic;
using UnityEngine;

namespace CustomInspectorGraph.Renderer
{
    public class GraphLines
    {
        private bool isCalculated = false;
        private List<Vector3[]> lines = new();

        public List<Vector3[]> GetGraphLines(Rect position, IFunction function, int divisionsOfX, int divisionsOfY, int accuracy)
        {
            if (isCalculated)
            {
                return lines;
            }

            //isCalculated = true;
            //

            if (accuracy < 1 ||
                divisionsOfX < 0 ||
                divisionsOfY < 0)
                return new List<Vector3[]>();

            var _divisionValue = new Vector2(position.width / divisionsOfX, position.height / divisionsOfY);
            var _startingPosition = position.position + new Vector2(0, position.height);
            var _lines = new List<Vector3[]>(accuracy);
            var _points = new List<Vector3>(accuracy);
            var _step = 1f / accuracy;
            var _upperBound = divisionsOfY;
            var _lowerBound = 0;

            for (var _xPoint = 0f; _xPoint < divisionsOfX; _xPoint += _step)
            {
                var _yPoint = function.GetFunctionValue(_xPoint);

                if (_yPoint > _upperBound || _yPoint < _lowerBound)
                {
                    if (_points.Count > 0)
                    {
                        _lines.Add(_points.ToArray());
                        _points.Clear();
                    }

                    continue;
                }

                _points.Add(_startingPosition + new Vector2(_xPoint, -_yPoint) * _divisionValue);
            }

            _lines.Add(_points.ToArray());

            return lines = _lines;
        }

    }
}

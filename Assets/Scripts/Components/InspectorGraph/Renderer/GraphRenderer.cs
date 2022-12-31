using UnityEditor;
using UnityEngine;
using System;

#if UNITY_EDITOR

namespace CustomInspectorGraph.Renderer
{
    [CustomPropertyDrawer(typeof(Graph))]
    public class GraphRenderer : PropertyDrawer
    {
        private AxisLines axisLines = new();
        private MarkupLines markupLines = new();
        private MarkupNumbers markupNumbers = new();
        private GraphLines graphLines = new();

        private Graph graph;
        private IFunction function;
        private float additionalHeight;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            InitializeFields(property);

            return EditorGUI.GetPropertyHeight(property, true) + additionalHeight + 6f;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            additionalHeight = 0f;

            DrawProperty(GetHeaderRectangle(position.position), property, label, false);

            if (!property.isExpanded)
                return;

            additionalHeight = graph.DisplayData.GraphHeight + 20f;

            var _displayData = graph.DisplayData;

            var _graphRectangle = new Rect(position.position + new Vector2(10f, 25f),
                new Vector2Int(graph.DisplayData.GraphWidth, graph.DisplayData.GraphHeight));

            var _displayDataRectangle = new Rect(position.position + new Vector2(10f, _displayData.GraphHeight + 44f),
                new Vector2(GetPropertyWidth() - 10f, 18f));

            DrawAxis(_graphRectangle, axisLines, graph.DisplayData.Axis);

            MarkupWithLines(_graphRectangle, markupLines, _displayData.DivisionsOfX,
                _displayData.DivisionsOfY, _displayData.DivisionValue, _displayData.MarkupLines);

            MarkupWithNumbers(_graphRectangle, markupNumbers, _displayData.DivisionsOfX,
                _displayData.DivisionsOfY, _displayData.DivisionValue, _displayData.MarkupNumbers);

            DrawProperty(_displayDataRectangle, property.FindPropertyRelative("DisplayData"),
                new GUIContent("GraphDisplayData"), true);

            DrawGraph(_graphRectangle, function, _displayData.DivisionsOfX, _displayData.DivisionsOfY,
                _displayData.GraphAccuracy, _displayData.Graph);
        }

        private void InitializeFields(SerializedProperty property)
        {
            graph ??= (Graph)fieldInfo.GetValue(property.serializedObject.targetObject);
            
            if (function == null)
            {
                if (property.serializedObject.targetObject is IFunction)
                    function = property.serializedObject.targetObject as IFunction;
                else
                    throw new Exception(property.serializedObject.targetObject.GetType() + " script does not inherit from IFunction");

            }
        }

        private float GetPropertyWidth()
            => Screen.width - 37f;

        private Rect GetHeaderRectangle(Vector2 position)
            => new(position, new Vector2(GetPropertyWidth(), 18f));

        private void DrawProperty(Rect position, SerializedProperty property, GUIContent label, bool isIncludeChildren = false)
            => EditorGUI.PropertyField(position, property, label, isIncludeChildren);

        private void DrawAxis(Rect position, AxisLines calculator, Color color)
        {
            var _lines = calculator.GetAxisLines(position);
            var _previousColor = Handles.color;

            Handles.color = color;

            for (var currentLineIndex = 0; currentLineIndex < _lines.Length; currentLineIndex += 2)
                Handles.DrawLine(_lines[currentLineIndex], _lines[currentLineIndex + 1]);

            Handles.color = _previousColor;
        }

        private void MarkupWithLines(Rect position, MarkupLines calculator, int divisionsOfX, int divisionsOfY, Vector2 divisionValue, Color color)
        {
            var _lines = calculator.GetMarkupLines(position, divisionsOfX, divisionsOfY, divisionValue);
            var _previousColor = Handles.color;

            Handles.color = color;

            for (var currentLineIndex = 0; currentLineIndex < _lines.Length; currentLineIndex += 2)
                Handles.DrawLine(_lines[currentLineIndex], _lines[currentLineIndex + 1]);

            Handles.color = _previousColor;
        }

        private void MarkupWithNumbers(Rect position, MarkupNumbers calculator, int divisionsOfX, int divisionsOfY, Vector2 divisionValue, Color color)
        {
            var _numbers = calculator.GetMarkupNumbers(position, divisionsOfX, divisionsOfY, divisionValue);
            var _numberStyle = new GUIStyle
            {
                normal =
                {
                    textColor = color
                }
            };

            foreach (var _number in _numbers)
                Handles.Label(_number.Item1, _number.Item2, _numberStyle);
        }

        private void DrawGraph(Rect position, IFunction function, int divisionsOfX, int divisionsOfY, int graphAccuracy, Color color)
        {
            var _lines = graphLines.GetGraphLines(position, function, divisionsOfX, divisionsOfY, graphAccuracy);
            var _previousColor = Handles.color;
            Handles.color = color;

            foreach (var line in _lines)
                Handles.DrawAAPolyLine(line);

            Handles.color = _previousColor;
        }
    }
}

#endif
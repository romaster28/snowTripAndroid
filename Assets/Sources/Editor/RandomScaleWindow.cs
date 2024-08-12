using System;
using UnityEditor;
using UnityEngine;

namespace Sources.Editor
{
    public class RandomScaleWindow : EditorWindow
    {
        private static float _min;

        private static float _max;
        
        [MenuItem("Tools/Random Scale")]
        private static void ShowWindow()
        {
            var window = GetWindow<RandomScaleWindow>();
            window.titleContent = new GUIContent("Random scale");
            window.Show();
        }

        private void OnGUI()
        {
            _min = EditorGUILayout.FloatField("Min: ", _min);

            _max = EditorGUILayout.FloatField("Max: ", _max);
        }
    }
}
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Test))]
public class YourScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Test script = (Test)target;

        GUILayout.Label("Neighbours:");

        EditorGUILayout.BeginHorizontal();

        // Отобразить кнопку для выбора соседних тайлов
        for (int i = 0; i < script.neighbours.Count; i++)
        {
            script.neighbours[i] = EditorGUILayout.Toggle(script.neighbours[i]);
        }

        EditorGUILayout.EndHorizontal();
    }
}
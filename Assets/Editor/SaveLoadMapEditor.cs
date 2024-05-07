//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(SaveLoadMap))]
//public class SaveLoadMapEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();
//        SaveLoadMap saveLoadMap = (SaveLoadMap)target;

//        if (GUILayout.Button("Load"))
//        {
//            Debug.Log("Карта загружена");
//            saveLoadMap.Load();
//        }

//        if (GUILayout.Button("Save"))
//        {
//            Debug.Log("Карта сохранена");
//            saveLoadMap.Save();
//        }
//    }
//}

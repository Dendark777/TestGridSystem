//using UnityEngine;
//using UnityEditor;
//using Assets.Scripts.Items;

//[CustomEditor(typeof(Item))]
//public class ItemEditor : Editor
//{
//    private SerializedProperty itemNameProp;
//    private SerializedProperty itemDescriptionProp;
//    private SerializedProperty itemTypeProp;
//    private SerializedProperty attackDiceRollProp;
//    private SerializedProperty attackResultProp;
//    private SerializedProperty explosionRadiusProp;
//    private SerializedProperty actionsProp;

//    private void OnEnable()
//    {
//        itemNameProp = serializedObject.FindProperty("itemName");
//        itemDescriptionProp = serializedObject.FindProperty("itemDescription");
//        itemTypeProp = serializedObject.FindProperty("itemType");
//        attackDiceRollProp = serializedObject.FindProperty("attackDiceRoll");
//        attackResultProp = serializedObject.FindProperty("attackResult");
//        explosionRadiusProp = serializedObject.FindProperty("explosionRadius");
//        actionsProp = serializedObject.FindProperty("actions");
//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        EditorGUILayout.PropertyField(itemNameProp);
//        EditorGUILayout.PropertyField(itemDescriptionProp);
//        EditorGUILayout.PropertyField(itemTypeProp);
//        EditorGUILayout.PropertyField(attackDiceRollProp);
//        EditorGUILayout.PropertyField(attackResultProp);
//        EditorGUILayout.PropertyField(explosionRadiusProp);

//        EditorGUILayout.LabelField("Actions", EditorStyles.boldLabel);
//        EditorGUI.indentLevel++;

//        for (int i = 0; i < actionsProp.arraySize; i++)
//        {
//            SerializedProperty actionProp = actionsProp.GetArrayElementAtIndex(i);
//            EditorGUILayout.PropertyField(actionProp);
//        }

//        EditorGUI.indentLevel--;

//        if (GUILayout.Button("Add Action"))
//        {
//            actionsProp.arraySize++;
//        }

//        serializedObject.ApplyModifiedProperties();
//    }
//}
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CreateMap : EditorWindow
{
    private GameObject mapObject;
    private GameObject[,] tiles;
    private Object[] prefabs;

    private int rows = 24;
    private int columns = 20;
    private float tileSize = 1.0f;

    private int currentPrefabIndex = 0;

    [MenuItem("Tools/Create Map")]
    public static void ShowWindow()
    {
        GetWindow<CreateMap>("Create Map");
    }

    private void OnGUI()
    {
        rows = EditorGUILayout.IntField("Rows", rows);
        columns = EditorGUILayout.IntField("Columns", columns);
        tileSize = EditorGUILayout.FloatField("Tile Size", tileSize);

        if (GUILayout.Button("Create Map"))
        {
            CreateMapFunction();
        }
    }

    private void CreateMapFunction()
    {
        mapObject = new GameObject("Map");
        prefabs = Resources.LoadAll("Prefabs/Map1", typeof(GameObject));
        System.Array.Sort(prefabs, (x, y) => GetNumberFromPrefabName(x.name).CompareTo(GetNumberFromPrefabName(y.name)));

        tiles = new GameObject[columns, rows];

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject tile = (GameObject)PrefabUtility.InstantiatePrefab(prefabs[currentPrefabIndex]);
                tile.transform.parent = mapObject.transform;
                tile.transform.position = new Vector3(x * tileSize, y * tileSize, 0);

                tiles[x, y] = tile;

                // Индекс следующего префаба
                currentPrefabIndex++;
                if (currentPrefabIndex >= prefabs.Length)
                    currentPrefabIndex = 0;
            }
        }
    }

    private int GetNumberFromPrefabName(string prefabName)
    {
        string numberString = System.Text.RegularExpressions.Regex.Replace(prefabName, "[^0-9]", "");
        int number;
        int.TryParse(numberString, out number);
        return number;
    }
}
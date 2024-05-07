using UnityEngine;
using UnityEditor;

public class SpriteToPrefab : EditorWindow
{
    [MenuItem("Tools/Create Prefabs from Sprites")]
    static void CreatePrefabs()
    {
        // �������� ��� ���������� ������� � ���� �������
        Object[] selectedObjects = Selection.GetFiltered(typeof(Sprite), SelectionMode.DeepAssets);

        // ���������� ������ ������
        foreach (Object obj in selectedObjects)
        {
            // ���������, �������� �� ������ ��������
            if (obj is Sprite)
            {
                // ������� ������ �� �������
                GameObject prefab = new GameObject();
                SpriteRenderer spriteRenderer = prefab.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = (Sprite)obj;
                string spriteName = obj.name;
                string prefabPath = "Assets/Prefabs/" + spriteName + ".prefab";
                prefab.name = spriteName;
                // ������� ������
                PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
                DestroyImmediate(prefab);
            }
        }
        // ��������� ���� �������
        AssetDatabase.Refresh();
    }
}
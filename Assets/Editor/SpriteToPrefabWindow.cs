using UnityEngine;
using UnityEditor;

public class SpriteToPrefabWindow : EditorWindow
{
    private Texture2D _spriteSheet;

    [MenuItem("Tools/Create Prefabs from Sprites")]
    public static void ShowWindow()
    {
        GetWindow<SpriteToPrefabWindow>("Create Prefabs");
    }

    private void OnGUI()
    {
        _spriteSheet = EditorGUILayout.ObjectField("Sprite Sheet", _spriteSheet, typeof(Texture2D), false) as Texture2D;

        if (GUILayout.Button("Create Prefabs"))
        {
            if (_spriteSheet != null)
            {
                string path = AssetDatabase.GetAssetPath(_spriteSheet);
                Object[] sprites = AssetDatabase.LoadAllAssetsAtPath(path);

                foreach (Object obj in sprites)
                {
                    if (obj is Sprite)
                    {
                        Sprite sprite = obj as Sprite;
                        GameObject prefab = new GameObject(sprite.name);
                        SpriteRenderer spriteRenderer = prefab.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = sprite;

                        string prefabPath = "Assets/Prefabs/" + sprite.name + ".prefab";
                        PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
                        DestroyImmediate(prefab);
                    }
                }

                AssetDatabase.Refresh();
                Debug.Log("Prefabs created successfully!");
            }
            else
            {
                Debug.LogWarning("Sprite sheet not selected!");
            }
        }
    }
}
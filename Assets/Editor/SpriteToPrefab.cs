using UnityEngine;
using UnityEditor;

public class SpriteToPrefab : EditorWindow
{
    [MenuItem("Tools/Create Prefabs from Sprites")]
    static void CreatePrefabs()
    {
        // Получаем все выделенные объекты в окне проекта
        Object[] selectedObjects = Selection.GetFiltered(typeof(Sprite), SelectionMode.DeepAssets);

        // Перебираем каждый объект
        foreach (Object obj in selectedObjects)
        {
            // Проверяем, является ли объект спрайтом
            if (obj is Sprite)
            {
                // Создаем префаб из спрайта
                GameObject prefab = new GameObject();
                SpriteRenderer spriteRenderer = prefab.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = (Sprite)obj;
                string spriteName = obj.name;
                string prefabPath = "Assets/Prefabs/" + spriteName + ".prefab";
                prefab.name = spriteName;
                // Создаем префаб
                PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
                DestroyImmediate(prefab);
            }
        }
        // Обновляем окно проекта
        AssetDatabase.Refresh();
    }
}
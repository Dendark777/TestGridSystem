using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Persistent
{
    [InitializeOnLoad]
    public class DefaultSceneLoader
    {
        static DefaultSceneLoader()
        {
            EditorApplication.playModeStateChanged += LoadDefaultScene;
        }

        private static void LoadDefaultScene(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
            {
                // Замените "Assets/Scenes/MyDefaultScene.unity" на путь к вашей сцене
                string defaultScenePath = "Assets/Scenes/PersistentScene.unity";

                if (!EditorSceneManager.GetActiveScene().path.Equals(defaultScenePath))
                {
                    SceneManager.LoadScene(defaultScenePath);
                    //EditorSceneManager.OpenScene(defaultScenePath);
                }
            }
        }
    }
}

using Assets.Scripts.EventsBus.GlobalGameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persistent
{
    internal class SceneLoader
    {
        public SceneLoader()
        {
            var bus = EventBus.Instance;
            bus.Subscribe<IOnChangeScene>(OnChangeScene);
        }

        private void OnChangeScene(object evenData)
        {
            var sceneName = evenData as string;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            UnityEngine.Debug.Log($"Load scene {sceneName}");
        }
 
    }
}

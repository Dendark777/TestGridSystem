using Assets.Scripts.EventsBus.GlobalGameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persistent
{
    internal class TestOnChangeSceneMainMenu
    {
        public TestOnChangeSceneMainMenu()
        { 
            var bus = EventBus.Instance;
            bus.Subscribe<IOnChangeSceneMainMenu>(OnChangeSceneMainMenu);
        }


        private void OnChangeSceneMainMenu(object evenData)
        {
            UnityEngine.Debug.Log($"OnChangeSceneMainMenu");
        }
    }
}

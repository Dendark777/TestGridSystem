using Assets.Scripts.EventsBus.GlobalGameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persistent
{
    internal class TestOnChangeSceneHotSeatLobby
    {
        public TestOnChangeSceneHotSeatLobby()
        {
            var bus = EventBus.Instance;
            bus.Subscribe<IOnChangeSceneHotSeatLobby>(OnChangeSceneHotSeatLobby);
        }
        private void OnChangeSceneHotSeatLobby(object evenData)
        {
            UnityEngine.Debug.Log($"OnChangeSceneHotSeatLobby");
        }
    }
}

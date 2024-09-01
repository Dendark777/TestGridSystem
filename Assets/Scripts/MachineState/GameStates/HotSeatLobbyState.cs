using Assets.Scripts.EventsBus.GlobalGameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MachineState.GameStates
{
    internal class HotSeatLobbyState : LoaderSceneState<IOnChangeSceneHotSeatLobby>
    {
        public HotSeatLobbyState() : base("HotSeatLobbyScene")
        {
        }

        public override void ExitState()
        {
            UnityEngine.Debug.Log("Exited HotSeatLobby");
        }
    }
}

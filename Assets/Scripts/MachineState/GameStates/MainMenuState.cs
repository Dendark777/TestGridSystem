using Assets.Scripts.EventsBus.GlobalGameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MachineState.GameStates
{
    public class MainMenuState : LoaderSceneState<IOnChangeSceneMainMenu>
    {
        public MainMenuState() : base("MainMenuScene")
        {
        }

        public override void ExitState()
        {
            UnityEngine.Debug.Log("Exited Main Menu");
        }
    }
}

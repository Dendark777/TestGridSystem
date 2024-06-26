using Assets.Scripts.Nodes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MachineState.GameStates
{
    public class StartGame : MonoBehaviour, IState
    {
        [SerializeField]
        private GridManager _gridManager;
        public void EnterState()
        {
             
        }

        public void ExitState()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateState()
        {
            
        }
    }
}

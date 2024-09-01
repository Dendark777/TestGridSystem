using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MachineState.GameStates
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _states;
        private IState currentState;

        public void SetState(IState newState)
        {
            currentState?.ExitState();
            currentState = newState;
            currentState.EnterState();
        }
    }
}

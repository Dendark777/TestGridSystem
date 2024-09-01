using Assets.Scripts.EventsBus.GlobalGameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MachineState.GameStates
{
    public abstract class LoaderSceneState<T> : IState
    {
        private readonly string _sceneName;
        public LoaderSceneState(string sceneName)
        {
            _sceneName = sceneName;
        }

        public virtual void EnterState()
        {
            EventBus.Instance.Publish<IOnChangeScene>(_sceneName);
            EventBus.Instance.Publish<T>(_sceneName);
        }

        public abstract void ExitState();
    }
}

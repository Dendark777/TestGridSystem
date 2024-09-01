using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MachineState
{
    public abstract class PubluserState<T> : IState
    {
        protected readonly EventBus _eventBus = EventBus.Instance;
        public virtual void EnterState()
        {
            _eventBus.Publish<T>(null);
        }
        public abstract void ExitState();
    }
}

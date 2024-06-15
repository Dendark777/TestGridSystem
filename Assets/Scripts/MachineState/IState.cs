using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.MachineState
{
    public interface IState
    {
        void EnterState();
        void UpdateState();
        void ExitState();
    }
}

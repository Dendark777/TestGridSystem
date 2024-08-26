using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameStates
{
    public interface IState
    {
        void Enter();
        void Exit();
    }

    public class StateMachine
    {
        private IState _currentState;

        public void ChangeState(IState newState)
        {
            _currentState?.Exit();  // Выход из текущего состояния, если оно существует
            _currentState = newState;  // Переключение на новое состояние
            _currentState.Enter();  // Вход в новое состояние
        }
    }


}

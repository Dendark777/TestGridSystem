using Assets.Scripts.EventsBus.UIEvents;
using Assets.Scripts.MachineState;
using Assets.Scripts.MachineState.GameStates;
using Assets.Scripts.Persistent;
using Assets.Scripts.Players;
using Assets.Scripts.StartLevel;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int _startState;
        private Dictionary<int, IState> _states = new Dictionary<int, IState>
        {
            { 1, new MainMenuState() },
            { 2, new HotSeatLobbyState() },
        };
        private GameStateController _gameStateController;
        public static GameManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            StartGame();
        }

        private void StartGame()
        {
            _gameStateController = new GameStateController();
            _ = new SceneLoader();
            _ = new TestOnChangeSceneHotSeatLobby();
            _ = new TestOnChangeSceneMainMenu();
            _gameStateController.SetState(_states[_startState]);
        }
    }

}

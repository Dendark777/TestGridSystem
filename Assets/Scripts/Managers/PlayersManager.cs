using Assets.Scripts.EventsBus.PlayersEvents;
using Assets.Scripts.StartLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Players
{
    public class PlayersManager
    {
        private Player _currentPlayer;

        private List<Player> _players;
        private int _currentPlayerIndex;
        //Порядок в уровне 4
        public PlayersManager()
        {
            InitPlayers();
            EventBus.Instance.Subscribe<NextPlayer>(NextPlayer);
        }

        public void InitPlayers()
        {
            _currentPlayerIndex = -1;
            _players = new List<Player>
            {
                new Player("Jon Doe", Color.red, 1),
                new Player("Denis", Color.yellow, 3)
            };
            NextPlayer();
        }

        public Player GetCurrntPlayer()
        {
            return _currentPlayer;
        }

        public void NextPlayer(object eventData = null)
        {
            if (_currentPlayer != null)
            {
                _currentPlayer.EndTurn();
            }
            _currentPlayerIndex++;
            if (_currentPlayerIndex >= _players.Count)
            {
                _currentPlayerIndex = 0;
            }
            _currentPlayer = _players[_currentPlayerIndex];
            _currentPlayer.StartTurn();
            EventBus.Instance.Publish<StartTurnPlayer>(_currentPlayer);
        }
    }
}

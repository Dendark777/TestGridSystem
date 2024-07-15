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
        //Порядок в уровне 4
        public PlayersManager()
        {
            InitPlayers();
        }

        public void InitPlayers()
        {
            _players = new List<Player>();
            _players.Add(new Player("Jon Doe", Color.red, 1));
            _players.Add(new Player("Denis", Color.yellow, 3));
            _currentPlayer = _players[0];
        }

        public Player GetPlayer()
        {
            return _currentPlayer;
        }
        // Добавим метод для управления ходом игры
        public void PlayTurn()
        {
            // Реализация хода игры, включая ходы каждого игрока
            // Например, вызов методов для выполнения действий каждого игрока
        }
    }
}

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
    public class PlayersManager : MonoBehaviour
    {
        [SerializeField]
        private Player _currentPlayer;

        private List<Player> _players;
        //Порядок в уровне 4
        public void Init()
        {
            _currentPlayer.Init("Jon Doe", Color.red);
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

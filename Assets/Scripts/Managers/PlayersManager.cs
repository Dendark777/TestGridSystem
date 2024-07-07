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
        [SerializeField]
        private List<ChipBase> _testchips;

        private List<Player> _players;
        //Порядок в уровне 4
        public void Init()
        {
            InitChip(); 
            _currentPlayer.Init("Jon Doe", Color.black, _testchips);
        }
        public void InitChip()
        {
            var gm = LevelManager.Instance.GridManager;
            int x = 1;
            int y = 1;
            foreach (var chip in _testchips)
            {
                chip.Init(gm.GetNode(x, y), $"Chip {x}");
                x++;
                y++;
            }
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

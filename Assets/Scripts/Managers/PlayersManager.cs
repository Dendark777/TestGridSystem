using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Init()
        {
            _currentPlayer.Init("Jon Doe", Color.black, _testchips);
        }
        // Метод для получения случайной позиции на карте
        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);
            return new Vector3(x, 0f, z);
        }

        // Добавим метод для управления ходом игры
        public void PlayTurn()
        {
            // Реализация хода игры, включая ходы каждого игрока
            // Например, вызов методов для выполнения действий каждого игрока
        }
    }
}

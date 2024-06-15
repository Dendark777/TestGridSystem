using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Players
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject humanPrefab; // Префаб для создания человека
        public GameObject zombiePrefab; // Префаб для создания зомби

        private List<GameObject> humans = new List<GameObject>(); // Список человек
        private List<GameObject> zombies = new List<GameObject>(); // Список зомби

        void Start()
        {
            // Создаем игроков
            CreateHumans();
            CreateZombies();
        }

        // Метод для создания человеков
        private void CreateHumans()
        {
            // Создаем двух человек
            for (int i = 0; i < 2; i++)
            {
                GameObject human = Instantiate(humanPrefab, GetRandomPosition(), Quaternion.identity);
                humans.Add(human);
            }
        }

        // Метод для создания зомби
        private void CreateZombies()
        {
            // Создаем одного зомби
            GameObject zombie = Instantiate(zombiePrefab, GetRandomPosition(), Quaternion.identity);
            zombies.Add(zombie);
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

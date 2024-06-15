using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Players
{

    public class Human : MonoBehaviour
    {
        public int maxHealth = 4; // Максимальное количество жизней
        public int currentHealth; // Текущее количество жизней
        public bool isConscious = true; // Сознание человека

        public bool isCarrying = false; // Переносит ли человек раненого
        public GameObject carriedHuman; // Раненый человек, который переносится

        public int numActions = 2; // Количество действий за ход

        private void Start()
        {
            currentHealth = maxHealth;
        }

        // Метод для перемещения человека
        public void Move(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        // Метод для атаки зомби
        public void AttackZombie()
        {
            // Реализация атаки зомби
        }

        // Метод для поиска
        public void Search()
        {
            // Реализация поиска
        }

        // Метод для установки баррикады
        public void SetBarricade()
        {
            // Реализация установки баррикады
        }

        // Метод для передачи предмета другому игроку
        public void PassItem(GameObject otherPlayer)
        {
            // Реализация передачи предмета
        }

        // Метод для использования предмета
        public void UseItem()
        {
            // Реализация использования предмета
        }
    }
}

using Assets.Scripts.Nodes;
using Assets.Scripts.Players.Chip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.Nodes.Node;
using static UnityEngine.UI.CanvasScaler;

namespace Assets.Scripts.Players
{
    public class ChipBase : MonoBehaviour
    {

        public static event ClickAction OnLeftClicked;

        private Node _node;

        private bool isConscious = true; // Сознание человека

        private bool isCarrying = false; // Переносит ли человек раненого
        private GameObject carriedHuman; // Раненый человек, который переносится

        private int _countMaxActions; // Количество действий за ход
        private int _countCurrentAction;
        private int _countCellPerAction;
        private ChipAnimation _animation;

        public int MaxHealth { get; private set; } // Максимальное количество жизней
        public int CurrentHealth { get; private set; } // Текущее количество жизней
        public int MaxCellMove => _countCellPerAction * _countCurrentAction;
        public string Name { get; private set; }
        public Node Node => _node;

        public virtual void Init(Node node)
        {
            Init("Joe Doy");
            SetNode(node);
        }

        protected virtual void Init(string name, int maxHealth = 4, int countMaxActions = 2,int countCellPerAction = 2)
        {
            MaxHealth = maxHealth;
            _countMaxActions = countMaxActions;
            _countCellPerAction = countCellPerAction;
            CurrentHealth = MaxHealth;
            Name = name;
            _animation = GetComponent<ChipAnimation>();
            StartTurn();
        }

        public void StartTurn()
        {
            _countCurrentAction = _countMaxActions;
        }

        public void SetNode(Node node)
        {
            _node = node;
            transform.position = node.transform.position;
        }

        public void Stop(Node node)
        {
            _animation.Stay();
            SetNode(node);
        }

        // Метод для перемещения фишки
        public void Step(Vector3 newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Constants.MoveSpeed * Time.deltaTime);
        }

        public IEnumerator Move(List<PathNode> path)
        {
            int targetIndex = path.Count - 1;
            Vector3 currentWaypoint;
            try
            {
                currentWaypoint = path[targetIndex].GetPosition();
                Roteate(currentWaypoint);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                yield break;
            }
            _animation.Move();
            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    targetIndex--;
                    if (targetIndex < 0)
                    {
                        yield break; // Завершаем корутину, если достигли конца пути
                    }
                    currentWaypoint = path[targetIndex].GetPosition();
                    Roteate(currentWaypoint);
                }
                Step(currentWaypoint);
                yield return null; // Ждем один кадр
            }
        }


        public void Roteate(Vector3 newPosition)
        {
            Vector2 direction = (newPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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


        void OnMouseDown()
        {
            OnLeftClicked.Invoke(gameObject);
        }
    }
}


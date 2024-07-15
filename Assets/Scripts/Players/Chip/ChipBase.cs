using Assets.Scripts.EventsBus.ChipEvents;
using Assets.Scripts.Items.Weapons;
using Assets.Scripts.Nodes;
using Assets.Scripts.Players.Chip;
using Assets.Scripts.Players.Chip.ChipEvents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;
using static Assets.Scripts.Nodes.Node;
using static UnityEngine.UI.CanvasScaler;

namespace Assets.Scripts.Players
{
    public class ChipBase : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer HighLightPlayerColor;
        private Node _node;
        private bool isConscious = true; // Сознание человека

        private bool isCarrying = false; // Переносит ли человек раненого
        private GameObject carriedHuman; // Раненый человек, который переносится

        private int _countMaxActions; // Количество действий за ход
        private int _countCurrentAction;
        private int _countCellPerAction;
        private ChipAnimation _animation;
        private ChipEvent _event;
        public Inventory Inventory { get; private set; }
        public int MaxHealth { get; private set; } // Максимальное количество жизней
        public int CurrentHealth { get; private set; } // Текущее количество жизней
        public int MaxCellMove => _countCellPerAction * _countCurrentAction;
        public string Name { get; private set; }
        public bool IsMove { get; private set; }

        public Node Node => _node;

        public virtual void Init(Node node, string name, Color playerColor)
        {
            HighLightPlayerColor.color = new Color(playerColor.r, playerColor.g, playerColor.b, 0.5f);
            Init(name);
            SetNode(node);
            Inventory = new Inventory();
            SelectWeapon(0);
            IsMove = false;
        }

        protected virtual void Init(string name, int maxHealth = 4, int countMaxActions = 2, int countCellPerAction = 2)
        {
            MaxHealth = maxHealth;
            _countMaxActions = countMaxActions;
            _countCellPerAction = countCellPerAction;
            CurrentHealth = MaxHealth;
            Name = name;
            _animation = GetComponent<ChipAnimation>();
            _event = GetComponent<ChipEvent>();
            StartTurn();
        }

        public void StartTurn()
        {
            _countCurrentAction = _countMaxActions;
        }

        public void SetNode(Node node)
        {
            if (_node != null)
            {
                _node.SetChip(null);
            }
            _node = node;
            node.SetChip(this);
            transform.position = node.transform.position;
        }

        public void Stop(Node node)
        {
            _animation.Stay();
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            Deselected();
            SetNode(node);
            EventBus.Instance.Publish<ChipStopEvent>(this);
            IsMove = false ;
        }

        // Метод для перемещения фишки
        public void Step(Vector3 newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Constants.MoveSpeed * Time.deltaTime);
        }

        public void StartMove(List<PathNode> path, Node lastNode)
        {
            if (path == null || path.Count == 0)
            {
                return; // Завершаем корутину, если путь пустой
            }
            IsMove = true;
            StartCoroutine(Move(path, lastNode, path.Count - 1));
        }

        public IEnumerator Move(List<PathNode> path,Node lastNode, int targetIndex)
        {
            Vector3 currentWaypoint = path[targetIndex].GetPosition();
            Rotate(currentWaypoint);
            _animation.Move();
            while (targetIndex >= 0)
            {
                if (transform.position == currentWaypoint)
                {
                    targetIndex--;
                    if (targetIndex >= 0)
                    {
                        currentWaypoint = path[targetIndex].GetPosition();
                        Rotate(currentWaypoint);
                    }
                }
                Step(currentWaypoint);
                yield return null; // Ждем один кадр
            }
            Stop(lastNode);
        }


        public void Rotate(Vector3 newPosition)
        {
            Vector2 direction = (newPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public void SelectWeapon(int index)
        {
            Inventory.SetCurrentWeapon(index);
        }

        public Weapon GetSelectedWeapon()
        {
            return Inventory.GetCurrentWeapon();
        }

        public List<string> GetNamesItem()
        {
            return Inventory.GetNamesItem();
        }

        public int GetCurrentIndex()
        {
            return Inventory.GetCurrentIndex();
        }

        public void Attack()
        {
            _animation.Attack();
        }

        public void Shoot()
        {
            print("Выстрел");
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

        internal void Deselected()
        {
            _event.Deselected();
        }
    }
}


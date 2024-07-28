using Assets.Scripts.Constants;
using Assets.Scripts.EventsBus.ChipEvents;
using Assets.Scripts.Helpers.Parameters;
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
        private Node _node;
        private ChipAnimation _animation;
        private ChipEvent _event;
        private Inventory _inventory;
        private int _countMaxActions; // Количество действий за ход
        private int _countCurrentAction;
        private int _countCellPerAction;
        public int MaxCellMove => _countCellPerAction * _countCurrentAction;
        public int MaxHealth { get; private set; } // Максимальное количество жизней
        public int CurrentHealth { get; private set; } // Текущее количество жизней
        [SerializeField]
        public string Name { get; private set; }
        public bool IsMove { get; private set; }
        public Node Node => _node;

        public virtual void Init(Node node, Color playerColor)
        {
            SetNode(node);
            IsMove = false;
            InitComponents(playerColor);
        }

        private void InitComponents(Color playerColor)
        {
            var HighLightPlayerColor = transform.GetChild(0).GetComponent<SpriteRenderer>();
            HighLightPlayerColor.color = new Color(playerColor.r, playerColor.g, playerColor.b, 0.5f);
        }

        protected void SpecificInitParameters(string name, Inventory inventory = null)
        {
            Name = name;
            _inventory = inventory ?? new Inventory();
            SelectWeapon(0);
        }

        protected void InitBaseParameters(BaseParameters parameters)
        {
            MaxHealth = parameters.MaxHealth;
            _countMaxActions = parameters.CountMaxActions;
            _countCellPerAction = parameters.CountCellPerAction;
            CurrentHealth = MaxHealth;
            _animation = GetComponent<ChipAnimation>();
            _event = GetComponent<ChipEvent>();
            _animation.SetAnimatorController(parameters.AnimatorPath);
            _countCurrentAction = _countMaxActions;
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
            IsMove = false;
        }

        // Метод для перемещения фишки
        public void Step(Vector3 newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, LevelConstants.MoveSpeed * Time.deltaTime);
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

        public IEnumerator Move(List<PathNode> path, Node lastNode, int targetIndex)
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
            _inventory.SetCurrentWeapon(index);
        }

        public Weapon GetSelectedWeapon()
        {
            return _inventory.GetCurrentWeapon();
        }

        public List<string> GetNamesItem()
        {
            return _inventory.GetNamesItem();
        }

        public int GetCurrentIndex()
        {
            return _inventory.GetCurrentIndex();
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


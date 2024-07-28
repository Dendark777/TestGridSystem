using Assets.Scripts.EventsBus.PlayersEvents;
using Assets.Scripts.Helpers;
using Assets.Scripts.Players.Chip.Humans;
using Assets.Scripts.StartLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class Player
    {
        private ChipControl _chipControl;
        //private readonly List<ChipBase> _chips;
        private readonly string prefabPath = "Prefabs/Chips/Human";
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public bool IsPlaying { get; private set; }
        private readonly int _countChip;
        private readonly int _index;
        public Player(string name, Color color, int index) : this(name, color, index, 2)
        {
            InitChip();
        }
        public Player(string name, Color color, int index, int chips)
        {
            Name = name;
            Color = color;
            IsPlaying = false;
            _index = index;
            _countChip = chips;
        }

        public void InitChip()
        {
            var _chips = new List<ChipBase>();
            GameObject humanPrefab = Resources.Load<GameObject>(prefabPath);
            for (int i = 0; i < _countChip; i++)
            {
                var human = InstantiateHelper.Instance.InstantiatePrefab(humanPrefab);
                human.transform.SetParent(LevelManager.Instance.GridManager.transform);
                human.AddComponent<Commando>();
                var component = human.GetComponent<Commando>();
                component.Init(LevelManager.Instance.GetLegalNode(i, i), Color);
                _chips.Add(human.GetComponent<Commando>());
            }
            _chipControl = new ChipControl(_chips);
        }



        public void StartTurn()
        {
            _chipControl.StartTurnPlayer();
        }

        public void EndTurn()
        {
            _chipControl.EndTurnPlayer();
        }

        public void InitChip(HumanBase chip, int x, int y)
        {
            var gm = LevelManager.Instance.GridManager;
            chip.Init(gm.GetNode(x, y), Color);
        }

    }
}

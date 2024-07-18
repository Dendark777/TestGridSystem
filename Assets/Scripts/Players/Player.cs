using Assets.Scripts.EventsBus.PlayersEvents;
using Assets.Scripts.Helpers;
using Assets.Scripts.StartLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class Player
    {
        private readonly ChipControl _chipControl;
        //private readonly List<ChipBase> _chips;
        private readonly string prefabPath = "Prefabs/Chips/Human";
        public string Name { get; private set; }
        public Color Color { get; private set; }
        public bool IsPlaying { get; private set; }

        public Player(string name, Color color, int index)
        {
            Name = name;
            Color = color;
            IsPlaying = false;
            var _chips = new List<ChipBase>();
            GameObject humanPrefab = Resources.Load<GameObject>(prefabPath);
            for (int i = 0; i < 2; i++)
            {
                var human = InstantiateHelper.Instance.InstantiatePrefab(humanPrefab);
                human.transform.SetParent(LevelManager.Instance.GridManager.transform);
                InitChip(human.GetComponent<ChipBase>(), i + index, i + index);
                _chips.Add(human.GetComponent<ChipBase>());
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

        public void InitChip(ChipBase chip, int x, int y)
        {
            var gm = LevelManager.Instance.GridManager;
            chip.Init(gm.GetNode(x, y), $"Chip {x}", Color);
        }

    }
}
